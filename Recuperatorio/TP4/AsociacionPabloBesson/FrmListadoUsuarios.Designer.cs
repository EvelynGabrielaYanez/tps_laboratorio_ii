
namespace AsociacionPabloBesson.UsuarioABM
{
    partial class FrmListadoUsuarios
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
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.cmbTipoPersona = new System.Windows.Forms.ComboBox();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblTipoDeUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AllowUserToAddRows = false;
            this.dgvPersonas.AllowUserToDeleteRows = false;
            this.dgvPersonas.AllowUserToResizeRows = false;
            this.dgvPersonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Location = new System.Drawing.Point(24, 66);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.ReadOnly = true;
            this.dgvPersonas.RowTemplate.Height = 25;
            this.dgvPersonas.Size = new System.Drawing.Size(702, 290);
            this.dgvPersonas.TabIndex = 0;
            // 
            // cmbTipoPersona
            // 
            this.cmbTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPersona.FormattingEnabled = true;
            this.cmbTipoPersona.Location = new System.Drawing.Point(581, 21);
            this.cmbTipoPersona.Name = "cmbTipoPersona";
            this.cmbTipoPersona.Size = new System.Drawing.Size(145, 23);
            this.cmbTipoPersona.TabIndex = 1;
            this.cmbTipoPersona.SelectedValueChanged += new System.EventHandler(this.cmbTipoPersona_SelectedValueChanged);
            // 
            // btnAlta
            // 
            this.btnAlta.BackgroundImage = global::AsociacionPabloBesson.Properties.Resources.agregar;
            this.btnAlta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAlta.Location = new System.Drawing.Point(214, 16);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(31, 31);
            this.btnAlta.TabIndex = 3;
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::AsociacionPabloBesson.Properties.Resources.IconoBusqueda;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Location = new System.Drawing.Point(175, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(29, 30);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(24, 21);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(145, 23);
            this.txtDni.TabIndex = 9;
            // 
            // lblTipoDeUsuario
            // 
            this.lblTipoDeUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTipoDeUsuario.ForeColor = System.Drawing.Color.White;
            this.lblTipoDeUsuario.Location = new System.Drawing.Point(478, 21);
            this.lblTipoDeUsuario.Name = "lblTipoDeUsuario";
            this.lblTipoDeUsuario.Size = new System.Drawing.Size(97, 23);
            this.lblTipoDeUsuario.TabIndex = 10;
            this.lblTipoDeUsuario.Text = "Tipo listado:";
            this.lblTipoDeUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmListadoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 375);
            this.Controls.Add(this.lblTipoDeUsuario);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.cmbTipoPersona);
            this.Controls.Add(this.dgvPersonas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListadoUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado";
            this.Load += new System.EventHandler(this.FrmListadoUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.ComboBox cmbTipoPersona;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblTipoDeUsuario;
    }
}