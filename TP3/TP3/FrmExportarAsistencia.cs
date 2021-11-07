using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Excepciones.Archivos;
using EntidadesAsociacion.Reportes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace TP3
{
    public partial class FrmExportarAsistencia : Form
    {
        List<Asistencia> listadoDeAsistencia;
        EGrupo grupo;
        DateTime fecha;

        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        /// <param name="listadoDeAsistencia">Listado de asistencias a exportar</param>
        /// <param name="grupo">Grupo del que se exoportara la asistencia</param>
        /// <param name="fecha">Fecha dela que se exportara la asistencia</param>
        public FrmExportarAsistencia(List<Asistencia> listadoDeAsistencia, EGrupo grupo, DateTime fecha)
        {
            InitializeComponent();
            this.listadoDeAsistencia = listadoDeAsistencia;
            this.grupo = grupo;
            this.fecha = fecha;
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Método encargargado de cerrar el fomrulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Método encargado de abrir la busqueda de carpetas al usuario y guardar la ruta seleccionada en el textbox de ruta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarCarpeta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog frmBuscadorCarpeta = new FolderBrowserDialog();

            if (frmBuscadorCarpeta.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = frmBuscadorCarpeta.SelectedPath;
            }
        }

        /// <summary>
        /// Método encargado de validar la ruta y exportar segun el tipo de archivo seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ArchivosYSerializacionControlador.ExportarAsistenciaCsvTxt(this.listadoDeAsistencia, this.ObtenerExtension(), txtNombreArchivo.Text, txtRuta.Text);

                Reporte<Asistencia> reporte = new Reporte<Asistencia>(Asociacion.ListadoAsistencias);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (PathInexistente error)
            {
                StringBuilder errorMessage = new StringBuilder();
                errorMessage.AppendLine(error.Message);
                if (error.InnerException is not null)
                    errorMessage.AppendLine(error.InnerException.Message);

                MessageBox.Show(errorMessage.ToString(), "Error al exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Método encargado de obtener el tipo de extensión seleccionada en el checkbox
        /// </summary>
        /// <returns></returns>
        private ETipoExtension ObtenerExtension()
        {
            if (rbtTxt.Checked)
            {
                return ETipoExtension.Txt;
            }
            else
            {
                return ETipoExtension.Csv;
            }
        }

        /// <summary>
        /// Método encargado de configurar los campos e inicializarlos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmExportarAsistencia_Load(object sender, EventArgs e)
        {
            txtRuta.Enabled = false;
            txtRuta.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txtNombreArchivo.Text = $"Asistencia-{this.grupo}-{fecha.ToString("ddmmyyyy")}";
            rbtTxt.Checked = true;
        }
    }
}
