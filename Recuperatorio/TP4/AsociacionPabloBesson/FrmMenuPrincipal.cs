using EntidadesAsociacion;
using EntidadesAsociacion.CierreTurno;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.DB_Controladores;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AsociacionPabloBesson.UsuarioABM;
using static EntidadesAsociacion.Enumerados;

namespace AsociacionPabloBesson
{
    public partial class FrmMenuPrincipal : Form
    {
        ErrorProvider alertaCierreTurno;
        InfoCierreTurno informacionCierreTurno;
        CancellationTokenSource tokenDeCancelacion;

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
            // Configura y ejecuta la subtarea de control de cierre de turnos.
            this.tokenDeCancelacion = new CancellationTokenSource();
            CierreTurno cierreTurno = new CierreTurno();
            cierreTurno.AsistenciasFaltantes += CargarUsuariosFaltantes;
            cierreTurno.CambioTurno += ActualizarCambioTurno;
            cierreTurno.ControlarCierre(tokenDeCancelacion);

            pnlMenu.BackColor = Color.FromArgb(159, 94, 142);
            this.tmrHoraActual.Enabled = true;

            this.ActualizarTurno();

            lblGrupoActivo.ForeColor = Color.White;
            lblTituloGrupoActivo.ForeColor = Color.White;
            lblNombreAgrupacion.ForeColor = Color.White;
            lblListaUsuarios.ForeColor = Color.White;
            lblNombreAgrupacion.ForeColor = Color.White;

            alertaCierreTurno = new ErrorProvider();
        }

        /// <summary>
        /// Método encargado de actualizar el listado del formulario y el grupo activo.
        /// </summary>
        private void ActualizarTurno()
        {
            this.RecargarListado();
            Turno turno = TurnoControlador.BuscarTurnoAbierto();
            EGrupo? grupoALaFecha = turno is not null ? TurnoControlador.BuscarTurnoAbierto().Grupo : null;
            this.lblGrupoActivo.Text = grupoALaFecha is not null ? grupoALaFecha.ToString() : "No hay grupo activo";
        }

        /// <summary>
        /// Método encargado de habilitar el label que comunica la falta de carga de asistencias para usuarios del turno abierto
        /// y cargar el listado de registros de asistencias faltantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="info"></param>
        private void CargarUsuariosFaltantes(object sender, InfoCierreTurno informacionCierreTurno)
        {
            this.informacionCierreTurno = informacionCierreTurno;
            if (lblCierreDeTurno.InvokeRequired)
            {
                this.lblCierreDeTurno.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.lblCierreDeTurno.Visible = true;
                        alertaCierreTurno.SetError(lblCierreDeTurno, $"Hay asistencias sin cargar para la fecha {informacionCierreTurno.Turno.Fecha}.\n No se puede realizar el cierre de turno");
                    }
                );
            }
            else
            {
                this.lblCierreDeTurno.Visible = true;
                alertaCierreTurno.SetError(lblCierreDeTurno, $"Hay asistencias sin cargar para la fecha {informacionCierreTurno.Turno.Fecha}.\n No se puede realizar el cierre de turno");
            }
        }

        /// <summary>
        /// Método encargado de recargar el listado del datagrid
        /// </summary>
        private void RecargarListado()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();
            Turno turno = TurnoControlador.BuscarTurnoAbierto();
            EGrupo? grupoActivo = turno is not null ? TurnoControlador.BuscarTurnoAbierto().Grupo : null;
            if (grupoActivo is not null)
            {
                listadoUsuarios = UsuarioControlador.Filtrar(grupo:(EGrupo)grupoActivo);
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

        /// <summary>
        /// Método encargado de abrir el formulario de carga de asistencias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblCierreDeTurno_Click(object sender, EventArgs e)
        {
            FrmCierreTurno frmCierreTurno = new FrmCierreTurno(informacionCierreTurno);
            frmCierreTurno.ShowDialog();
        }

        /// <summary>
        /// Método encargado de actualizar el formulario y ocultar el label de falta de registros por cierre de turno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="informacionCierreTurno"></param>
        public void ActualizarCambioTurno(object sender, InfoCierreTurno informacionCierreTurno)
        {
            this.informacionCierreTurno = informacionCierreTurno;
            if (this.lblCierreDeTurno.InvokeRequired)
            {
                this.lblCierreDeTurno.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.ActualizarTurno();
                    this.lblCierreDeTurno.Visible = false;
                    alertaCierreTurno.SetError(this.lblCierreDeTurno, "");
                }
                );
            }
            else
            {
                this.ActualizarTurno();
                lblCierreDeTurno.Visible = false;
                alertaCierreTurno.SetError(lblCierreDeTurno, "");
            }
        }

        /// <summary>
        /// Método encargado de cancelar el token de la subtarea cuando se realice el cierre del formulario principal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.tokenDeCancelacion.Cancel();
        }

        private void tsmiAnalisisEstadistico_Click(object sender, EventArgs e)
        {
            FrmReporteEstadistico frmReporteEstadistico = new FrmReporteEstadistico();
            this.Hide();
            frmReporteEstadistico.ShowDialog();
            this.Show();
        }
    }
}
