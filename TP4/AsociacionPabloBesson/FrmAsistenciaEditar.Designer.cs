
namespace AsociacionPabloBesson
{
    partial class FrmAsistenciaEditar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // txtDniUsuario
            // 
            this.txtDniUsuario.AutoCompleteCustomSource.AddRange(new string[] {
            "31429766",
            "34429765",
            "39429767",
            "36429768",
            "31429766",
            "34429765",
            "39429767",
            "36429768",
            "39429766",
            "39429765",
            "39429767",
            "39429768"});
            this.txtDniUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDniUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Value = new System.DateTime(2021, 11, 2, 23, 24, 27, 630);
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.DataSource = new EntidadesAsociacion.Enumerados.EGrupo[] {
        EntidadesAsociacion.Enumerados.EGrupo.Lunes,
        EntidadesAsociacion.Enumerados.EGrupo.Martes,
        EntidadesAsociacion.Enumerados.EGrupo.Miercoles,
        EntidadesAsociacion.Enumerados.EGrupo.Jueves,
        EntidadesAsociacion.Enumerados.EGrupo.Viernes};
            this.cmbGrupo.Items.AddRange(new object[] {
            EntidadesAsociacion.Enumerados.EGrupo.Lunes,
            EntidadesAsociacion.Enumerados.EGrupo.Martes,
            EntidadesAsociacion.Enumerados.EGrupo.Miercoles,
            EntidadesAsociacion.Enumerados.EGrupo.Jueves,
            EntidadesAsociacion.Enumerados.EGrupo.Viernes});
            // 
            // cmbTipoAsistencia
            // 
            this.cmbTipoAsistencia.DataSource = new EntidadesAsociacion.Enumerados.ETipoAsistencia[] {
        EntidadesAsociacion.Enumerados.ETipoAsistencia.Ausente,
        EntidadesAsociacion.Enumerados.ETipoAsistencia.AusenteConAviso,
        EntidadesAsociacion.Enumerados.ETipoAsistencia.Feriado,
        EntidadesAsociacion.Enumerados.ETipoAsistencia.Presente};
            this.cmbTipoAsistencia.Items.AddRange(new object[] {
            EntidadesAsociacion.Enumerados.ETipoAsistencia.Ausente,
            EntidadesAsociacion.Enumerados.ETipoAsistencia.AusenteConAviso,
            EntidadesAsociacion.Enumerados.ETipoAsistencia.Feriado,
            EntidadesAsociacion.Enumerados.ETipoAsistencia.Presente});
            // 
            // btnAceptar
            // 
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FrmAsistenciaEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 230);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAsistenciaEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Asistencia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}