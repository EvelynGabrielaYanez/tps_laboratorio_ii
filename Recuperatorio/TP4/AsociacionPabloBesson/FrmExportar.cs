using EntidadesAsociacion;
using EntidadesAsociacion.Excepciones.Archivos;
using EntidadesAsociacion.Reportes;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace AsociacionPabloBesson
{
    public partial class FrmExportar : Form
    {
        Reporte<Usuario> reportesFiltro;
        Reporte<RegistroPorcentaje> reportesPorcentaje;

        /// <summary>
        /// Método constructor del fomrulario
        /// </summary>
        private FrmExportar()
        {
            InitializeComponent();
            this.reportesPorcentaje = null;
            this.reportesFiltro = null;
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        /// <param name="reportesFiltro">Reporte del tipo filtor a exportar</param>
        public FrmExportar(Reporte<Usuario> reportesFiltro) : this()
        {
            this.reportesFiltro = reportesFiltro;
        }

        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        /// <param name="reportesPorcentaje">Reportes del tipo porcentaje a exportar</param>
        public FrmExportar(Reporte<RegistroPorcentaje> reportesPorcentaje) : this()
        {
            this.reportesPorcentaje = reportesPorcentaje;
        }

        /// <summary>
        /// Método encargado de abrir la busqueda de carpetas e inicializar el textbox de la ruta de la carpeta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeleccionarCarpeta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog frmBuscadorCarpeta = new FolderBrowserDialog();

            if (frmBuscadorCarpeta.ShowDialog() == DialogResult.OK)
            {
                txtPathCarpeta.Text = frmBuscadorCarpeta.SelectedPath;
            }
        }

        /// <summary>
        /// Método encargado de configurar la apariencia e incializar los campos correpsondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmExportar_Load(object sender, EventArgs e)
        {
            txtPathCarpeta.Enabled = false;
            cmbTipoDeArchivo.DataSource = Enum.GetValues(typeof(ETipoExtension));
            txtPathCarpeta.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txtNombreArchivo.Text = $"Reporte-{DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss")}";
        }

        /// <summary>
        /// Método encargado de cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Método encargado de exportar archivo segun el formato seleccionado y el tipo de reporte con el que se ha inicializado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                ETipoExtension extensionSeleccionada = (ETipoExtension)cmbTipoDeArchivo.SelectedItem;
                if (extensionSeleccionada == ETipoExtension.Txt || extensionSeleccionada == ETipoExtension.Csv)
                {
                    if (reportesFiltro is not null)
                    {
                        reportesFiltro.ExportarCsvTxt((ETipoExtension)cmbTipoDeArchivo.SelectedItem, txtNombreArchivo.Text, txtNuevaCarpeta.Text, txtPathCarpeta.Text);
                    }
                    else
                    {
                        reportesPorcentaje.ExportarCsvTxt((ETipoExtension)cmbTipoDeArchivo.SelectedItem, txtNombreArchivo.Text, txtNuevaCarpeta.Text, txtPathCarpeta.Text);
                    }
                }
                else
                {
                    if (reportesFiltro is not null)
                    {
                        reportesFiltro.SerializarXmlJson((ETipoExtension)cmbTipoDeArchivo.SelectedItem, txtNombreArchivo.Text, txtNuevaCarpeta.Text, txtPathCarpeta.Text);
                    }
                    else
                    {
                        reportesPorcentaje.SerializarXmlJson((ETipoExtension)cmbTipoDeArchivo.SelectedItem, txtNombreArchivo.Text, txtNuevaCarpeta.Text, txtPathCarpeta.Text);
                    }
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ErrorDeEscritura error)
            {
                StringBuilder errorMessage = new StringBuilder();
                errorMessage.AppendLine(error.Message);
                if (error.InnerException is not null)
                    errorMessage.AppendLine(error.InnerException.Message);

                MessageBox.Show(errorMessage.ToString(), "Error al exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
