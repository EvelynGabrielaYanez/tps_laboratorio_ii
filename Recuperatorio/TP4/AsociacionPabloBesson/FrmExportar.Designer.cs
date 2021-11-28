
namespace AsociacionPabloBesson
{
    partial class FrmExportar
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
            this.txtPathCarpeta = new System.Windows.Forms.TextBox();
            this.lblRutaCarpeta = new System.Windows.Forms.Label();
            this.btnSeleccionarCarpeta = new System.Windows.Forms.Button();
            this.txtNombreArchivo = new System.Windows.Forms.TextBox();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.cmbTipoDeArchivo = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNuevaCarpeta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPathCarpeta
            // 
            this.txtPathCarpeta.Enabled = false;
            this.txtPathCarpeta.Location = new System.Drawing.Point(26, 36);
            this.txtPathCarpeta.Name = "txtPathCarpeta";
            this.txtPathCarpeta.Size = new System.Drawing.Size(315, 23);
            this.txtPathCarpeta.TabIndex = 0;
            // 
            // lblRutaCarpeta
            // 
            this.lblRutaCarpeta.AutoSize = true;
            this.lblRutaCarpeta.Location = new System.Drawing.Point(26, 18);
            this.lblRutaCarpeta.Name = "lblRutaCarpeta";
            this.lblRutaCarpeta.Size = new System.Drawing.Size(106, 15);
            this.lblRutaCarpeta.TabIndex = 1;
            this.lblRutaCarpeta.Text = "Ruta de la Carpeta:";
            // 
            // btnSeleccionarCarpeta
            // 
            this.btnSeleccionarCarpeta.Location = new System.Drawing.Point(356, 35);
            this.btnSeleccionarCarpeta.Name = "btnSeleccionarCarpeta";
            this.btnSeleccionarCarpeta.Size = new System.Drawing.Size(99, 23);
            this.btnSeleccionarCarpeta.TabIndex = 2;
            this.btnSeleccionarCarpeta.Text = "Buscar Carpeta";
            this.btnSeleccionarCarpeta.UseVisualStyleBackColor = true;
            this.btnSeleccionarCarpeta.Click += new System.EventHandler(this.btnSeleccionarCarpeta_Click);
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Location = new System.Drawing.Point(26, 97);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(152, 23);
            this.txtNombreArchivo.TabIndex = 3;
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Location = new System.Drawing.Point(26, 79);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(117, 15);
            this.lblNombreArchivo.TabIndex = 4;
            this.lblNombreArchivo.Text = "Nombre del Archivo:";
            // 
            // cmbTipoDeArchivo
            // 
            this.cmbTipoDeArchivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDeArchivo.FormattingEnabled = true;
            this.cmbTipoDeArchivo.Items.AddRange(new object[] {
            ".txt",
            ".csv",
            ".json",
            ".xml"});
            this.cmbTipoDeArchivo.Location = new System.Drawing.Point(184, 97);
            this.cmbTipoDeArchivo.Name = "cmbTipoDeArchivo";
            this.cmbTipoDeArchivo.Size = new System.Drawing.Size(63, 23);
            this.cmbTipoDeArchivo.TabIndex = 5;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(26, 137);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(99, 23);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Cancelar";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(356, 137);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(99, 23);
            this.btnExportar.TabIndex = 7;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nueva Carpeta:";
            // 
            // txtNuevaCarpeta
            // 
            this.txtNuevaCarpeta.Location = new System.Drawing.Point(253, 97);
            this.txtNuevaCarpeta.Name = "txtNuevaCarpeta";
            this.txtNuevaCarpeta.PlaceholderText = "Nombre de la nueva carpeta";
            this.txtNuevaCarpeta.Size = new System.Drawing.Size(202, 23);
            this.txtNuevaCarpeta.TabIndex = 8;
            // 
            // FrmExportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 179);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNuevaCarpeta);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cmbTipoDeArchivo);
            this.Controls.Add(this.lblNombreArchivo);
            this.Controls.Add(this.txtNombreArchivo);
            this.Controls.Add(this.btnSeleccionarCarpeta);
            this.Controls.Add(this.lblRutaCarpeta);
            this.Controls.Add(this.txtPathCarpeta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExportar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar";
            this.Load += new System.EventHandler(this.FrmExportar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPathCarpeta;
        private System.Windows.Forms.Label lblRutaCarpeta;
        private System.Windows.Forms.Button btnSeleccionarCarpeta;
        private System.Windows.Forms.TextBox txtNombreArchivo;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.ComboBox cmbTipoDeArchivo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNuevaCarpeta;
    }
}