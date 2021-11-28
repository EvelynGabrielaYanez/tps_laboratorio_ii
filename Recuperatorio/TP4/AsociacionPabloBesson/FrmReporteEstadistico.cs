using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Reportes;
using EntidadesAsociacion.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace AsociacionPabloBesson
{
    public partial class FrmReporteEstadistico : Form
    {
        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        public FrmReporteEstadistico()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método encargado de configurar la apariencia del formuario y correr las tareas 
        /// que inicializan los campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmReporteEstadistico_Load(object sender, EventArgs e)
        {
            // Inicalizo las tareas
            Task tareaUno = Task.Run(() => this.CalcularCantidadCausasIngreso());
            Task tareaDos = Task.Run(() => this.CalcularCausasDeIngresoUsuarioConMasDenuncias());
            Task tareaTres = Task.Run(() => this.CaracterizacionGruposPorCausaDeIngreso());

            // Configuro la apariencia
            this.BackColor = Color.FromArgb(159, 94, 142);

            // Espero que terminen las tareas
            Task.WaitAll(tareaUno, tareaDos, tareaTres);
        }

        /// <summary>
        /// Método encargado de calcular la cantidad de causas de ingreso del usuario
        /// con mas denuncias.
        /// </summary>
        public void CalcularCantidadCausasIngreso()
        {
            List<Usuario> listado = UsuarioControlador.Filtrar();

            if (listado.Count == 0)
                return;
            // Busco el número de denuncias máximo
            int maxDenunciias = listado.Max(usuario => usuario.DenunciasRegistradas);
            // Busco lel listado de usuarios que tienen esa cantidad de denuncias.
            List<Usuario> listadoMaxDenuncias = listado.FindAll(usuario => usuario.DenunciasRegistradas == maxDenunciias);

            List<string> grupos = new List<string>();
            listadoMaxDenuncias.ForEach(usuario =>
            {
                if (!grupos.Contains(usuario.Grupo.ToString()))
                    grupos.Add(usuario.Grupo.ToString());
            });

            if (txtCantidad.InvokeRequired)
            {
                this.txtCantidad.BeginInvoke((MethodInvoker)delegate ()
                {
                    if (grupos.Count > 0)
                    {
                        this.txtCantidad.Text = maxDenunciias.ToString();
                        grupos.ForEach(grupo => lstbGrupoMayorCantidadDenuncias.Items.Add(grupo));
                    }
                });
            }
            else
            {
                if (grupos.Count > 0)
                {
                    this.txtCantidad.Text = maxDenunciias.ToString();
                    grupos.ForEach(grupo => lstbGrupoMayorCantidadDenuncias.Items.Add(grupo));
                }
            }

        }

        /// <summary>
        /// Método encargado de calcular la cantidad de causas de ingreso que posee el usuario con
        /// mayor cantidad de denuncias. En caso de ser mas de uno el usuario con la cantidad máxima 
        /// de denuncias.
        /// </summary>
        public void CalcularCausasDeIngresoUsuarioConMasDenuncias()
        {
            List<Usuario> listado = UsuarioControlador.Filtrar();

            if (listado.Count == 0)
                return;
            // Busco el número de denuncias máximo
            int maxDenunciias = listado.Max(usuario => usuario.DenunciasRegistradas);
            // Busco lel listado de usuarios que tienen esa cantidad de denuncias.
            List<Usuario> listadoMaxDenuncias = listado.FindAll(usuario => usuario.DenunciasRegistradas == maxDenunciias);

            // Busco la cantidad de delitos máximo 
            int cantidadMaxDeDelitos = listadoMaxDenuncias.Max(usuario => usuario.ListadoDeDelitos.Count);
            List<Usuario> listMaxDenunciasYMaxCantidadDelitos = listado.FindAll(usuario => usuario.ListadoDeDelitos.Count == cantidadMaxDeDelitos);

            // Se construye el string que se mostrara en el listado de grupos
            List<string> grupos = new List<string>();
            listMaxDenunciasYMaxCantidadDelitos.ForEach(usuario =>
            {
                if (!grupos.Contains(usuario.Grupo.ToString()))
                    grupos.Add(usuario.Grupo.ToString());
            });

            // Se actualizan los campos
            if (this.txtNroCausasDeIngreso.InvokeRequired)
            {
                this.lstbNroCausasDeIngreso.BeginInvoke((MethodInvoker)delegate ()
                {
                    if (grupos.Count > 0)
                    {
                        this.txtNroCausasDeIngreso.Text = cantidadMaxDeDelitos.ToString();
                        grupos.ForEach(grupo => lstbNroCausasDeIngreso.Items.Add(grupo));
                    }
                });
            }
            else
            {
                if (grupos.Count > 0)
                {
                    this.txtNroCausasDeIngreso.Text = cantidadMaxDeDelitos.ToString();
                    grupos.ForEach(grupo => lstbNroCausasDeIngreso.Items.Add(grupo));
                }
            }
        }

        /// <summary>
        /// Método encargado de obtener el tipo de causa de ingreso que caracteriza a cada uno de los grupos
        /// y mostrarla en el datagrid.
        /// En caso de estar representado por más de un grupo entonces retornara todos los grupos que lo caracterizan.
        /// </summary>
        public void CaracterizacionGruposPorCausaDeIngreso()
        {
            Dictionary<EGrupo, List<Usuario>> listadoUsuariosPorGrupo = new Dictionary<EGrupo, List<Usuario>>();
            List<Usuario> listado = UsuarioControlador.Filtrar();
            listado.ForEach(usuario =>
            {
                List<Usuario> listUsuario;
                if (listadoUsuariosPorGrupo.TryGetValue(usuario.Grupo, out listUsuario))
                    listUsuario.Add(usuario);
                else
                    listadoUsuariosPorGrupo.Add(usuario.Grupo, new List<Usuario>() { usuario });
            });

            // Calculo los porcentajes máximos para cada grupo 
            Dictionary<EGrupo, string> listadoDataGrid = new Dictionary<EGrupo, string>();
            foreach (KeyValuePair<EGrupo, List<Usuario>> parClaveValor in listadoUsuariosPorGrupo)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                double porcentajeMaximo = 0;
                StringBuilder stbCausasIngreso = new StringBuilder();
                if (parClaveValor.Value.Count > 0)
                {
                    // Se obtienen los porcentajes por cada causa de ingreso.
                    List<RegistroPorcentaje> listadoPorcentaje = UsuarioControlador.CalcularPorcentajesPorCausaIngreso(parClaveValor.Value);
                    // Se obtiene el porcentaje máximo entre todas las causas de ingreso
                    porcentajeMaximo = listadoPorcentaje.Max(registro => registro.Porcentaje);
                    // Se obtienen las causas de ingreso que poseen ese porcentaje máxmo.
                    listadoPorcentaje = listadoPorcentaje.FindAll(registro => porcentajeMaximo == registro.Porcentaje);
                    // Se agregan a la cadena las causas de ingreso que caracterizan
                    listadoPorcentaje.ForEach(registro => stbCausasIngreso.AppendLine(registro.Intervalo));
                }

                // Se agregan los datos al datagrid
                listadoDataGrid.Add(parClaveValor.Key, stbCausasIngreso.ToString());
                dataGridViewRow.Cells.Add((new DataGridViewTextBoxCell { Value = parClaveValor.Key.ObtenerDescripcion() }));
                dataGridViewRow.Cells.Add((new DataGridViewTextBoxCell { Value = stbCausasIngreso.ToString() }));
                dataGridViewRow.Cells.Add((new DataGridViewTextBoxCell { Value = porcentajeMaximo }));

                if (dgvReporte.InvokeRequired)
                {
                    this.dgvReporte.BeginInvoke((MethodInvoker)delegate ()
                    {
                        dgvReporte.Rows.Add(dataGridViewRow);
                    });
                }
                else
                {
                    dgvReporte.Rows.Add(dataGridViewRow);
                }
            }

        }
    }
}
