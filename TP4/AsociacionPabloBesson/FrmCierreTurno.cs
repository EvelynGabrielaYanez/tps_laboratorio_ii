using EntidadesAsociacion;
using EntidadesAsociacion.CierreTurno;
using EntidadesAsociacion.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace AsociacionPabloBesson
{

    public partial class FrmCierreTurno : Form
    {
        EGrupo grupoCierreTurno;
        List<Asistencia> asistenciasFaltantes;
        DateTime fecha;

        /// <summary>
        /// Método cosntrcutor del formulario.
        /// Este recibe la ifnormacion del cierre de turno y setea los atributos grupoCierreTurno
        /// y genera las asistencias por defecto correspondiente a el listado de usuarios que tienen registros de asistencias faltantes.
        /// </summary>
        /// <param name="infoCierreTurno"></param>
        public FrmCierreTurno(InfoCierreTurno infoCierreTurno)
        {
            InitializeComponent();
            this.grupoCierreTurno = (EGrupo)infoCierreTurno.Turno.Grupo;
            this.fecha = infoCierreTurno.Turno.Fecha;
            this.asistenciasFaltantes = this.CrearAsistenciasPorDefecto(infoCierreTurno.UsuariosAsisnenciaFaltante);
        }

        /// <summary>
        /// Método encargado decrar los registros de asistencias por defecto para el listado de usuarios faltantes.
        /// </summary>
        /// <param name="listadoUsuarios">Listado de usuarios de los que se generaran los registros de asistencias</param>
        /// <returns>Listado de asistencias por defecto</returns>
        private List<Asistencia> CrearAsistenciasPorDefecto(List<Usuario> listadoUsuarios)
        {
            List<Asistencia> listadoAsistenciasTemporal = new List<Asistencia>();
            foreach (Usuario usuario in listadoUsuarios)
            {
                Asistencia asistencia = new Asistencia(usuario, fecha, this.grupoCierreTurno, ETipoAsistencia.Ausente);
                listadoAsistenciasTemporal.Add(asistencia);
            }

            return listadoAsistenciasTemporal;
        }

        /// <summary>
        /// Método encargado de terminar de configurar la apriencia del fomrulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCierreTurno_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(159, 94, 142);
            this.ActualizarDataGrid();
        }

        /// <summary>
        /// Método necargado de actualizar y configurar el datagrid
        /// Utilizadno como fuente de datos las asistencias faltantes
        /// </summary>
        private void ActualizarDataGrid()
        {

            this.dgvListado.Columns.Add(CrearUnComboBoxDePresentes());
            this.dgvListado.DataSource = this.asistenciasFaltantes;
            this.dgvListado.AutoGenerateColumns = true;

            this.dgvListado.Columns["Usuario"].Visible = false;
            this.dgvListado.Columns["DniUsuario"].ReadOnly = true;
            this.dgvListado.Columns["Fecha"].ReadOnly = true;
            this.dgvListado.Columns["Grupo"].ReadOnly = true;
        }

        /// <summary>
        /// Método encargado de crear y configurar un combobox para el datagrid que posea 
        /// como fuete de datos los tipos de presencialidades.
        /// </summary>
        /// <returns></returns>
        private DataGridViewComboBoxColumn CrearUnComboBoxDePresentes()
        {
            DataGridViewComboBoxColumn comboboxPresentes = new DataGridViewComboBoxColumn();
            comboboxPresentes.ValueType = typeof(ETipoAsistencia);
            comboboxPresentes.DataSource = Enum.GetValues(typeof(ETipoAsistencia));
            comboboxPresentes.DataPropertyName = "Presente";
            comboboxPresentes.Name = "Presente";
            return comboboxPresentes;
        }

        /// <summary>
        /// Método encargado de cargar las asistencias registradas en el datagrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarAsistencias_Click(object sender, EventArgs e)
        {
            // Se obtiene la informacion editada
            List<Asistencia> asistenciasCargadas = this.ObtenerInfoDataGrid();
            AsistenciaControlador.AgregarListadoDeAsistencias(asistenciasCargadas);

            this.Close();
        }

        /// <summary>
        /// Método encargado de obtener la informacion del datagrid.
        /// </summary>
        /// <returns></returns>
        private List<Asistencia> ObtenerInfoDataGrid()
        {
            return (List<Asistencia>)dgvListado.DataSource;
        }

        /// <summary>
        /// Método encargado de confiugrar el modo de tamaño automatico de las columnas del datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListado_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
