using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Excepciones.Empleados;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsociacionPabloBesson
{
    public partial class FrmInicioSesion : Form
    {
        static Empleado empleado;

        /// <summary>
        /// Propiedad de lectura y escritura del empelado logueado
        /// </summary>
        public static Empleado Empleado
        {
            get { return FrmInicioSesion.empleado; }
            set { FrmInicioSesion.empleado = value; }
        }

        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        public FrmInicioSesion()
        {
            InitializeComponent();
            empleado = null;
        }

        /// <summary>
        /// Método encargado de configurar la apriencia e incializar los campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInicioSesion_Load(object sender, EventArgs e)
        {
            pnlEncabezado.BackColor = Color.FromArgb(159, 140, 183);
            btnIniciarSesion.BackColor = Color.FromArgb(159, 140, 183);
            this.lblUsuarioInvalido.Visible = false;
        }

        /// <summary>
        /// Método encargado de validar el nombre de cuenta y contraseña y realizar el incio de la sesion y abrir el menu principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            this.lblUsuarioInvalido.Visible = false;
            try
            {
                // Valida el empleado
                FrmInicioSesion.empleado = EmpleadoControlador.ValidarSesion(txtNombreCuenta.Text, txtContrasenia.Text);
                // Abre el formulario principal
                FrmMenuPrincipal frmMenuPrincipal = new FrmMenuPrincipal();
                this.Hide();
                frmMenuPrincipal.ShowDialog();
                // Vacia los campos y muestra el formulario de incio de sesion
                this.Show();
                this.txtContrasenia.Text = string.Empty;
                this.txtNombreCuenta.Text = string.Empty;
            }
            catch (SesionInvalida)
            {
                this.lblUsuarioInvalido.Visible = true;
            }
        }

        /// <summary>
        /// Método encargado de autocompletar el usuario y la contraseña 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAutocompletar_Click(object sender, EventArgs e)
        {
            FrmAutocompletar frmAutocompletar = new FrmAutocompletar();
            if (frmAutocompletar.ShowDialog() == DialogResult.OK)
            {
                txtNombreCuenta.Text = empleado.NombreCuenta;
                txtContrasenia.Text = empleado.Contrasenia;
            }
        }
    }
}
