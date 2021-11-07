using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Excepciones.Genericas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace TP3.UsuarioABM
{
    public partial class FrmAltaUsuario : Form
    {
        private ErrorProvider errorEnCampo;
        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        public FrmAltaUsuario()
        {
            InitializeComponent();
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
        /// Método encargado de configurar la apariencia e inicializar los campos correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAltaUsuario_Load(object sender, EventArgs e)
        {

            this.BackColor = Color.FromArgb(159, 94, 142);
            btnAgregar.BackColor = Color.FromArgb(202, 142, 186);
            btnCancelar.BackColor = Color.FromArgb(202, 142, 186);

            cmbGrupo.DataSource = Enum.GetValues(typeof(EGrupo));
            chklstDelitosRegistrados.DataSource = Enum.GetValues(typeof(ETipoCausaIngreso));
            dtpFechaIngreso.Enabled = false;
            dtpFechaIngreso.Value = DateTime.Now;
            errorEnCampo = new ErrorProvider();
            errorEnCampo = new ErrorProvider();
        }

        /// <summary>
        /// Método encargado de agregar un usuario nuevo validando previamente los campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Se Validan los campos
                this.VaciarRegistrosDeError();
                this.ValidarCampos();

                List<ETipoCausaIngreso> listadoDeDelitos = this.ObtenerCausaDeIngreso();

                // Se agrega el usuario y se intenga agregar.
                Usuario usuario = new Usuario(txtNombre.Text, txtApellido.Text, int.Parse(txtDni.Text),
                                                DateTime.Now, (EGrupo)cmbGrupo.SelectedItem, int.Parse(txtNumeroDeDenuncias.Text),
                                                int.Parse(txtTelefono.Text), listadoDeDelitos);
                if (!UsuarioControlador.AgregarUsuario(usuario))
                {
                    MessageBox.Show("El usuario ya se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (CampoInvalido error)
            {
                Control control = Controls.Find(error.NombreCampo, true)[0];
                errorEnCampo.SetError(control, error.Message);
            }
        }

        /// <summary>
        /// Método encargad de validar si el campo pasado por parametro esta vacio
        /// </summary>
        /// <param name="valorCampo"></param>
        /// <param name="nombreControl"></param>
        /// <exception cref="CampoInvalido">Se arroja cuando el campo esta vacio</exception>
        private void ValidarVacio(string valorCampo, string nombreControl)
        {
            if (valorCampo == string.Empty)
            {
                throw new CampoInvalido("Los campos obligatorios (*) no pueden estar vacios.", nombreControl);
            }
        }

        /// <summary>
        /// Método ecargado de vaciar los registros de eror en el ErrorProvider
        /// </summary>
        private void VaciarRegistrosDeError()
        {
            // Vacia los registros de error
            errorEnCampo.SetError(txtNombre, "");
            errorEnCampo.SetError(txtApellido, "");
            errorEnCampo.SetError(txtDni, "");
            errorEnCampo.SetError(txtNumeroDeDenuncias, "");
            errorEnCampo.SetError(txtTelefono, "");
        }

        /// <summary>
        /// Método encargado de validar los campos
        /// </summary>
        /// <exception cref="CampoInvalido">Se arroja cuando algun campo  es invalido</exception>
        private void ValidarCampos()
        {
            // Se validan campos no vacios
            this.ValidarVacio(txtNombre.Text.Trim(), "txtNombre");
            this.ValidarVacio(txtApellido.Text.Trim(), "txtApellido");
            this.ValidarVacio(txtDni.Text.Trim(), "txtDni");
            this.ValidarVacio(txtNumeroDeDenuncias.Text.Trim(), "txtNumeroDeDenuncias");
            this.ValidarVacio(txtTelefono.Text.Trim(), "txtTelefono");
            this.ValidarVacio(txtNumeroDeDenuncias.Text.Trim(), "txtNumeroDeDenuncias");

            // Se validan valores de cada campo
            // Valida que el campo de nombre tenga solo letras
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZñÑ]+$"))
            {
                throw new CampoInvalido("El nombre puede contener sólo letras (mayuscula y/o minuscula)", "txtNombre");
            }
            // Valida que el campo de apellido tenga solo letras
            if (!Regex.IsMatch(txtApellido.Text, @"^[a-zA-ZñÑ]+$"))
            {
                throw new CampoInvalido("El apellido puede contener sólo letras (mayuscula y/o minuscula)", "txtApellido");
            }
            // Valida que el campo de Dni sea solo numerico y tenga un largo entre 6 y 8
            if (!Regex.IsMatch(txtDni.Text, @"^[0-9]+$") || txtDni.Text.Length > 8 || txtDni.Text.Length < 6)
            {
                throw new CampoInvalido("El Dni puede contener sólo puede contener números y debe tener un largo entre 6 y 8", "txtDni");
            }
            // Valida que el campo Numero De Denuncias sea solo numerico 
            if (!Regex.IsMatch(txtNumeroDeDenuncias.Text, @"^[0-9]+$"))
            {
                throw new CampoInvalido("El Dni puede contener sólo puede contener números y debe tener un largo entre 6 y 8", "txtNumeroDeDenuncias");
            }
            // Valida que el campo de telefono sea solo numerico y tenga un largo de 10
            if (!Regex.IsMatch(txtTelefono.Text, @"^[0-9]+$") || txtTelefono.Text.Length != 10)
            {
                throw new CampoInvalido("El Teléfono puede contener sólo puede contener números y debe tener un largo de 10", "txtTelefono");
            }
        }

        /// <summary>
        /// Mñetodo encargado de obtener las causas de ingreso seleccionadas en el check list
        /// </summary>
        private List<ETipoCausaIngreso> ObtenerCausaDeIngreso()
        {
            List<ETipoCausaIngreso> listaRetorno = new List<ETipoCausaIngreso>();

            for (int i = 0; i < chklstDelitosRegistrados.CheckedItems.Count; i++)
            {
                listaRetorno.Add((ETipoCausaIngreso)chklstDelitosRegistrados.CheckedItems[i]);
            }
            return listaRetorno;
        }
    }
}
