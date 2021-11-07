using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Excepciones.Genericas;
using EntidadesAsociacion.Excepciones.Usuarios;
using EntidadesAsociacion.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace TP3
{
    public partial class FrmAsistenciaAlta : Form
    {
        protected ErrorProvider errorCampo;
        public FrmAsistenciaAlta()
        {
            InitializeComponent();
        }

        protected virtual void FrmAsistenciaAlta_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(159, 94, 142);
            btnAceptar.BackColor = Color.FromArgb(202, 142, 186);
            btnCancelar.BackColor = Color.FromArgb(202, 142, 186);

            cmbGrupo.DataSource = Enum.GetValues(typeof(EGrupo));
            EGrupo? grupoALaFecha = Asociacion.ObtenerGrupoPorFecha();
            cmbGrupo.SelectedItem = grupoALaFecha is not null ? (int)grupoALaFecha : (int)EGrupo.Viernes;
            cmbTipoAsistencia.DataSource = Enum.GetValues(typeof(ETipoAsistencia));
            dtpFecha.Value = DateTime.Now;
            errorCampo = new ErrorProvider();

            cmbGrupo.Enabled = false;

            AutoCompleteStringCollection fuenteDeAutoCompletado = new AutoCompleteStringCollection();
            // Busca la lista de clientes para autocompletar
            List<int> listadoDni = UsuarioControlador.BuscarListadoDni().Cast<int>().ToList();
            foreach (int dni in listadoDni)
            {
                fuenteDeAutoCompletado.Add(dni.ToString());
            }

            // configura el textBox del DNI del cliente
            this.txtDniUsuario.AutoCompleteCustomSource = fuenteDeAutoCompletado;
            this.txtDniUsuario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtDniUsuario.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarCampos())
                {
                    Usuario usuario = UsuarioControlador.BuscarUsuario(int.Parse(txtDniUsuario.Text));
                    Asistencia asistencia = new Asistencia(usuario, dtpFecha.Value, (EGrupo)cmbGrupo.SelectedItem, (ETipoAsistencia)cmbTipoAsistencia.SelectedItem);
                    if (AsistenciaControlador.AgregarAsistencia(asistencia))
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La asistencia ya se encontraba registrada anteriormente", "No se pudo agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (CampoInvalido error)
            {
                Control control = Controls.Find(error.NombreCampo, true)[0];
                errorCampo.SetError(control, error.Message);
            }
            catch (UsuarioNoEncontrado error)
            {
                MessageBox.Show(error.Message, "No se pudo agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected bool ValidarCampos()
        {
            errorCampo.SetError(txtDniUsuario, "");
            errorCampo.SetError(dtpFecha, "");
            if (txtDniUsuario.Text.Trim() == string.Empty)
            {
                throw new CampoInvalido("El campo es obligatorio", "txtDniUsuario");
            }
            if (!Persona.ValidarDNI(txtDniUsuario.Text))
            {
                throw new CampoInvalido("El Dni ingresado es inválido", "txtDniUsuario");
            }
            if (!dtpFecha.Value.ValidarSiFechaYDia(cmbGrupo.SelectedItem.ToString()))
            {
                throw new CampoInvalido($"La fecha {dtpFecha.Value} no coincide con el dia {cmbGrupo.SelectedItem}", "dtpFecha");
            }
            return true;
        }

        private void txtDniUsuario_Validating(object sender, CancelEventArgs e)
        {
            errorCampo.SetError(txtDniUsuario, "");
            try
            {
                if (Persona.ValidarDNI(txtDniUsuario.Text))
                {
                    Usuario usuario = UsuarioControlador.BuscarUsuario(int.Parse(txtDniUsuario.Text));
                    cmbGrupo.SelectedIndex = (int)usuario.Grupo;
                }
                else
                {
                    errorCampo.SetError(txtDniUsuario, "El Dni ingresado es inválido");
                }
            }
            catch (UsuarioNoEncontrado error)
            {
                errorCampo.SetError(txtDniUsuario, error.Message);
            }

        }

    }
}
