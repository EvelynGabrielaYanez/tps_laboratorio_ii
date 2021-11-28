using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Excepciones.Genericas;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsociacionPabloBesson
{
    public partial class FrmAutocompletar : Form
    {
        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        public FrmAutocompletar()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Metodo encargado de cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo ecnargado de obtener del tipo seleccionado e inicializarlo en el formulario de inicio de sesion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtEmpleado.Checked == true)
                {
                    FrmInicioSesion.Empleado = EmpleadoControlador.ObtenerUnUsuarioDelTipo<Empleado>();
                }
                else
                {
                    FrmInicioSesion.Empleado = EmpleadoControlador.ObtenerUnUsuarioDelTipo<Administrador>();
                }
            }
            catch (NoEncontrado error)
            {
                MessageBox.Show(error.Message, "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
