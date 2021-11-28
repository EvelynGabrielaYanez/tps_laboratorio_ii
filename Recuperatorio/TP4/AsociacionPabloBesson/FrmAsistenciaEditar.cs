using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Excepciones.Genericas;
using System;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace AsociacionPabloBesson
{
    public partial class FrmAsistenciaEditar : FrmAsistenciaAlta
    {
        Asistencia asistencia;
        public FrmAsistenciaEditar(Asistencia asistencia) : base()
        {
            this.asistencia = asistencia;
        }

        /// <summary>
        /// Método encargado de configurar la apariencia e inicializar los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void FrmAsistenciaAlta_Load(object sender, EventArgs e)
        {
            base.FrmAsistenciaAlta_Load(sender, e);
            this.txtDniUsuario.Enabled = false;
            this.dtpFecha.Enabled = false;
            if (this.asistencia is not null)
            {
                this.txtDniUsuario.Text = this.asistencia.DniUsuario.ToString();
                this.cmbGrupo.SelectedIndex = (int)this.asistencia.Grupo;
                this.cmbTipoAsistencia.SelectedIndex = (int)this.asistencia.Presente;
                this.dtpFecha.Value = this.asistencia.Fecha;
            }
        }

        /// <summary>
        /// Método encargado de validar los campos y editar la asistencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarCampos())
                {
                    this.asistencia.Fecha = dtpFecha.Value;
                    this.asistencia.Presente = (ETipoAsistencia)cmbTipoAsistencia.SelectedItem;
                    if (AsistenciaControlador.EditarAsistencia(asistencia))
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el usuario a editar", "No se pudo editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (CampoInvalido error)
            {
                Control control = Controls.Find(error.NombreCampo, true)[0];
                this.errorCampo.SetError(control, error.Message);
            }
        }
    }
}
