using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace AsociacionPabloBesson.UsuarioABM
{
    public partial class FrmListadoUsuarios : Form
    {
        List<Persona> fuenteDeInformacion;

        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        public FrmListadoUsuarios()
        {
            InitializeComponent();
            this.fuenteDeInformacion = new List<Persona>();
        }

        /// <summary>
        /// Metodo ecargado de terminar de configurar la apariencia e inicializar los campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmListadoUsuarios_Load(object sender, EventArgs e)
        {
            if (FrmInicioSesion.Empleado.GetType() == typeof(Administrador))
            {
                this.cmbTipoPersona.DataSource = Enum.GetValues(typeof(ETipoPersona));
            }
            else
            {
                this.cmbTipoPersona.Items.Add(ETipoPersona.Usuario);
                this.cmbTipoPersona.SelectedIndex = 0;
            }

            this.BackColor = Color.FromArgb(159, 94, 142);

            txtDni.PlaceholderText = "Inserte el Dni";
            this.CargarDatosSinFiltro((ETipoPersona)cmbTipoPersona.SelectedItem);
        }

        /// <summary>
        /// Método ecargado de cargar el data grid segun el tipo de persona de la aplicacion seleccionado.
        /// </summary>
        /// <param name="tipoPersona">Tipo de persona seleccionado</param>
        private void CargarDatosSinFiltro(ETipoPersona tipoPersona)
        {
            this.fuenteDeInformacion.Clear();

            switch (tipoPersona)
            {
                case ETipoPersona.Administrador:
                    this.fuenteDeInformacion.AddRange(Asociacion.ListaEmpleados.FiltrarPorTipoEmpleado<Administrador, Empleado>());
                    break;
                case ETipoPersona.Empleado:
                    this.fuenteDeInformacion.AddRange(Asociacion.ListaEmpleados.FiltrarPorTipoEmpleado<Empleado, Empleado>());
                    break;
                case ETipoPersona.Usuario:
                    this.fuenteDeInformacion.AddRange(UsuarioControlador.Filtrar());
                    break;
            }

            this.ActualizarTabla(this.fuenteDeInformacion);
        }

        /// <summary>
        /// Método encargado de actualizar la tabla filtrandola por aquellos registros que contengan los numeros pasados en el dni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.ActualizarTabla(this.fuenteDeInformacion.BuscarDniQueContanga(txtDni.Text));
        }

        /// <summary>
        /// Método que recibe una lista de usuarios que puede o no estar filtada y 
        /// actualiza la fuente del datagrid con la misma.
        /// </summary>
        /// <param name="datosFiltrados"></param>
        private void ActualizarTabla(List<Persona> datosFiltrados)
        {
            switch ((ETipoPersona)this.cmbTipoPersona.SelectedItem)
            {
                case ETipoPersona.Administrador:
                case ETipoPersona.Empleado:
                    dgvPersonas.DataSource = datosFiltrados.Cast<Empleado>().ToList();
                    break;
                case ETipoPersona.Usuario:
                    dgvPersonas.DataSource = datosFiltrados.Cast<Usuario>().ToList();
                    break;
            }
        }

        /// <summary>
        /// Método encargado de abrir el formulario de alta de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlta_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAltaUsuario frmAltaUsuario = new FrmAltaUsuario();
            frmAltaUsuario.ShowDialog();
            this.Show();
            this.CargarDatosSinFiltro((ETipoPersona)cmbTipoPersona.SelectedItem);
        }

        /// <summary>
        /// Método encargado de actualizar el datagrid al cambiar el valor del combobox que selecciona el tipo de persona a filtrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTipoPersona_SelectedValueChanged(object sender, EventArgs e)
        {
            // Carga los datos segun la seleccion
            this.CargarDatosSinFiltro((ETipoPersona)cmbTipoPersona.SelectedItem);
            // Configura las vistas segun la seleccion
            if ((ETipoPersona)cmbTipoPersona.SelectedItem == ETipoPersona.Usuario)
            {
                btnAlta.Visible = true;
            }
            else
            {
                btnAlta.Visible = false;
            }
        }
    }
}
