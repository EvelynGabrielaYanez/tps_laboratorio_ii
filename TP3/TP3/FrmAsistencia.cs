using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Excepciones.Usuarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace TP3
{
    public partial class FrmAsistencia : Form
    {
        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        public FrmAsistencia()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método encargado de terminar de configurar la apariencia e inicializar los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAsistencia_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(159, 94, 142);
            cmbGrupo.DataSource = Enum.GetValues(typeof(EGrupo));
            EGrupo? grupoALaFecha = Asociacion.ObtenerGrupoPorFecha();
            cmbGrupo.SelectedIndex = grupoALaFecha is not null ? (int)grupoALaFecha : (int)EGrupo.Viernes;
            dtpFechaFiltro.Value = DateTime.Now;
            this.ActualizarDataGrid();
            chbFecha.Checked = false;
            dtpFechaFiltro.Enabled = false;
        }

        /// <summary>
        /// Método encargado de actualizar el datagrid con los datos filtrados segun el checkbox seleccionado
        /// </summary>
        private void ActualizarDataGrid()
        {
            if (chbFecha.Checked)
            {
                dgvAsistencia.DataSource = AsistenciaControlador.FiltrarAsistencias(dtpFechaFiltro.Value, dtpFechaFiltro.Value, (EGrupo)cmbGrupo.SelectedItem);
            }
            else
            {
                dgvAsistencia.DataSource = AsistenciaControlador.FiltrarPorGrupo((EGrupo)cmbGrupo.SelectedItem);
            }
            dgvAsistencia.Columns["Usuario"].Visible = false;
        }

        /// <summary>
        /// Método encargado de actualziar el datagrid cuando se cambia el gurpo seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGrupo_SelectedValueChanged(object sender, EventArgs e)
        {
            this.ActualizarDataGrid();
        }

        /// <summary>
        /// Método encargado de actualziar el datagrid cuando se cambia la fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dtpFechaFiltro_ValueChanged(object sender, EventArgs e)
        {
            this.ActualizarDataGrid();
        }

        /// <summary>
        /// Método encargado de abrir el formulario de importacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportar_Click(object sender, EventArgs e)
        {

            FrmImportarAsistencias frmImportarAsistencias = new FrmImportarAsistencias();
            frmImportarAsistencias.ShowDialog();
        }

        /// <summary>
        /// Método abrir el formulario de exportacion de asistencias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportarAsistencias_Click(object sender, EventArgs e)
        {
            //Selecciona el listado de asistencias seleccionado
            List<Asistencia> listadoDeAsistencia = (List<Asistencia>)dgvAsistencia.DataSource;

            FrmExportarAsistencia frmExportarCsvTxt = new FrmExportarAsistencia(listadoDeAsistencia, (EGrupo)cmbGrupo.SelectedItem, dtpFechaFiltro.Value);

            frmExportarCsvTxt.ShowDialog();
        }

        /// <summary>
        /// Método encargado de abrir el formulario de altas de asistecnias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAsistenciaAlta frmAsistencia = new FrmAsistenciaAlta();
            this.Hide();
            frmAsistencia.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Método encargado de abrir el formulario de edicion de asistencias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Asistencia asistencia = this.ObtenerDatosDeSeleccion();

            if (asistencia is not null)
            {
                FrmAsistenciaEditar frmEditarAlta = new FrmAsistenciaEditar(asistencia);
                this.Hide();
                frmEditarAlta.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("No hay ningun registro seleccionado para editar", "Información:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Obtiene los datos seleccionados del datagred y retorna la
        /// la asistencia seleccionada
        /// </summary>
        /// <returns>Retorna la instancia de la asistencia selecionada. En caso de no haber seleccion retorna null</returns>
        private Asistencia ObtenerDatosDeSeleccion()
        {
            Asistencia asistencia = null;
            try
            {

                // En caso de no haber ninguna fila le asigno -1
                int indiceFila = dgvAsistencia.CurrentRow is null ? -1 : dgvAsistencia.CurrentRow.Index;
                if (indiceFila >= 0)
                {
                    DataGridViewRow fila = dgvAsistencia.Rows[indiceFila];
                    int dni = (int)fila.Cells["DNIUsuario"].Value;
                    DateTime fecha = Convert.ToDateTime(fila.Cells["Fecha"].Value.ToString());
                    EGrupo grupo = (EGrupo)fila.Cells["Grupo"].Value;
                    ETipoAsistencia presente = (ETipoAsistencia)fila.Cells["Presente"].Value;
                    asistencia = new Asistencia(UsuarioControlador.BuscarUsuario(dni), fecha, grupo, presente);
                }
            }
            catch (UsuarioNoEncontrado error)
            {
                MessageBox.Show(error.Message, "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return asistencia;
        }

        /// <summary>
        /// Método encargado de actualizar el datagreid segun el cambio de estado deh checkbox de fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbFecha_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbFecha.Checked)
                dtpFechaFiltro.Enabled = true;
            else
                dtpFechaFiltro.Enabled = false;

            this.ActualizarDataGrid();
        }
    }
}
