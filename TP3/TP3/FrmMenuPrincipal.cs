using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TP3.UsuarioABM;
using static EntidadesAsociacion.Enumerados;

namespace TP3
{
    public partial class FrmMenuPrincipal : Form
    {

        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método encargado de controlar la actualizacion de la hora y fecha actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrHoraActual_Tick(object sender, EventArgs e)
        {
            DateTime fechaHoraActual = DateTime.Now;
            lblHoraActual.Text = fechaHoraActual.ToString("hh:mm:ss");
            lblFecha.Text = fechaHoraActual.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Método encargado de condigurar la apariencia e inicalizar los campos correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            pnlMenu.BackColor = Color.FromArgb(159, 94, 142);
            this.tmrHoraActual.Enabled = true;
            this.RecargarListado();
            EGrupo? grupoALaFecha = Asociacion.ObtenerGrupoPorFecha();
            lblGrupoActivo.Text = grupoALaFecha is not null ? grupoALaFecha.ToString() : "No hay grupo activo";
 
            lblGrupoActivo.ForeColor = Color.White;
            lblTituloGrupoActivo.ForeColor = Color.White;
            lblNombreAgrupacion.ForeColor = Color.White;
            lblListaUsuarios.ForeColor = Color.White;
            lblNombreAgrupacion.ForeColor = Color.White;

        }

        /// <summary>
        /// Método encargado de recargar el listado del datagrid
        /// </summary>
        private void RecargarListado()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();
            EGrupo ? grupoActivo = Asociacion.ObtenerGrupoPorFecha();
            if (grupoActivo is not null)
            {
                listadoUsuarios = UsuarioControlador.FiltrarPorGrupo((EGrupo)grupoActivo);

            }

            dgvAsistenciaDelDia.DataSource = listadoUsuarios;
            dgvAsistenciaDelDia.Columns["FechaIngreso"].Visible = false;
            dgvAsistenciaDelDia.Columns["DenunciasRegistradas"].Visible = false;
            dgvAsistenciaDelDia.Columns["NumeroTelefonico"].Visible = false;
            dgvAsistenciaDelDia.Columns["Activo"].Visible = false;
            dgvAsistenciaDelDia.Columns["Grupo"].Visible = false;
        }

        /// <summary>
        /// Método ecnargado de abrir el formulario de asistencias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAsistencias_Click(object sender, EventArgs e)
        {
            this.tmrHoraActual.Stop();
            FrmAsistencia frmAsistencia = new FrmAsistencia();
            this.Hide();
            frmAsistencia.ShowDialog();
            this.Show();
            this.tmrHoraActual.Start();
        }

        /// <summary>
        /// Método encargado de abrir el formuario de reportes por filtros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiReportesFiltros_Click(object sender, EventArgs e)
        {
            this.tmrHoraActual.Stop();
            FrmReportesPorFiltro frmReportes = new FrmReportesPorFiltro();
            this.Hide();
            frmReportes.ShowDialog();
            this.Show();
            this.tmrHoraActual.Start();
        }

        /// <summary>
        /// Método encargado de abrir el formulario de reportes por porcentaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiReportesPorcentajes_Click(object sender, EventArgs e)
        {
            this.tmrHoraActual.Stop();
            FrmReportesPorPorcentaje frmReportes = new FrmReportesPorPorcentaje();
            this.Hide();
            frmReportes.ShowDialog();
            this.Show();
            this.tmrHoraActual.Start();
        }

        /// <summary>
        /// Método encargado de abrir el formulario de listado de personas de la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiListados_Click(object sender, EventArgs e)
        {
            this.tmrHoraActual.Stop();
            FrmListadoUsuarios frmReportes = new FrmListadoUsuarios();
            this.Hide();
            frmReportes.ShowDialog();
            this.Show();
            this.tmrHoraActual.Start();
            this.RecargarListado();
        }
    }
}
