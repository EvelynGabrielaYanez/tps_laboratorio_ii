using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Excepciones.Archivos;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace AsociacionPabloBesson
{
    public partial class FrmImportarAsistencias : Form
    {
        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        public FrmImportarAsistencias()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método encargado de cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Método encargado de improtar el archivo según la extensión seleccionada validando la ruta ingresada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@$"Ocurrio un error al importar el archivo {txtRutaArchivo.Text}\{txtNombreArchivo.Text}");
            try
            {
                ArchivosYSerializacionControlador.ImportarAsistenciasJsonXML(this.ObtenerExtension(), txtNombreArchivo.Text, txtRutaArchivo.Text);
                MessageBox.Show("Importado con éxito", "Éxtio",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            catch (ErrorDeLectura error)
            {
                StringBuilder errorMessage = new StringBuilder();
                errorMessage.AppendLine(error.Message);
                if (error.InnerException is not null)
                    errorMessage.AppendLine(error.InnerException.Message);

                MessageBox.Show(errorMessage.ToString(), "No se pudo importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método encargado de obtener la extensión seleccionada en el checkbox
        /// </summary>
        /// <returns>Tipo de extension obtenida</returns>
        private ETipoExtension ObtenerExtension()
        {
            if (rbtJson.Checked)
            {
                return ETipoExtension.Json;
            }
            else
            {
                return ETipoExtension.Xml;
            }
        }


        /// <summary>
        /// Método encargado de configurar la apariencia e incializar los campos correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmImportarAsistencias_Load(object sender, EventArgs e)
        {
            txtRutaArchivo.Text = AppDomain.CurrentDomain.BaseDirectory + $"\\Archivos_Serializacion\\ArchivosLectura";
            txtNombreArchivo.Text = "Asistencias";
            rbtXml.Checked = true;
        }

        /// <summary>
        /// Método encargado de abrir la busqueda de carpetas al usuario y guardar la ruta seleccionada en el textbox de ruta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog frmBuscadorCarpeta = new FolderBrowserDialog();

            if (frmBuscadorCarpeta.ShowDialog() == DialogResult.OK)
            {
                txtRutaArchivo.Text = frmBuscadorCarpeta.SelectedPath;
            }
        }
    }
}
