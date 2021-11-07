
namespace TP3
{
    partial class FrmExportarAsistencia
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
            this.gpbTipoDeArchivo = new System.Windows.Forms.GroupBox();
            this.rbtCsv = new System.Windows.Forms.RadioButton();
            this.rbtTxt = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.txtNombreArchivo = new System.Windows.Forms.TextBox();
            this.btnBuscarCarpeta = new System.Windows.Forms.Button();
            this.lblNombreDelArchivo = new System.Windows.Forms.Label();
            this.gpbTipoDeArchivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbTipoDeArchivo
            // 
            this.gpbTipoDeArchivo.Controls.Add(this.rbtCsv);
            this.gpbTipoDeArchivo.Controls.Add(this.rbtTxt);
            this.gpbTipoDeArchivo.Location = new System.Drawing.Point(245, 66);
            this.gpbTipoDeArchivo.Name = "gpbTipoDeArchivo";
            this.gpbTipoDeArchivo.Size = new System.Drawing.Size(114, 49);
            this.gpbTipoDeArchivo.TabIndex = 0;
            this.gpbTipoDeArchivo.TabStop = false;
            this.gpbTipoDeArchivo.Text = "Tipo de Archivo";
            // 
            // rbtCsv
            // 
            this.rbtCsv.AutoSize = true;
            this.rbtCsv.Location = new System.Drawing.Point(59, 22);
            this.rbtCsv.Name = "rbtCsv";
            this.rbtCsv.Size = new System.Drawing.Size(42, 19);
            this.rbtCsv.TabIndex = 1;
            this.rbtCsv.TabStop = true;
            this.rbtCsv.Text = "csv";
            this.rbtCsv.UseVisualStyleBackColor = true;
            // 
            // rbtTxt
            // 
            this.rbtTxt.AutoSize = true;
            this.rbtTxt.Location = new System.Drawing.Point(14, 22);
            this.rbtTxt.Name = "rbtTxt";
            this.rbtTxt.Size = new System.Drawing.Size(39, 19);
            this.rbtTxt.TabIndex = 0;
            this.rbtTxt.TabStop = true;
            this.rbtTxt.Text = "txt";
            this.rbtTxt.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(22, 131);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(160, 25);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(204, 131);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(160, 25);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(22, 24);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(238, 23);
            this.txtRuta.TabIndex = 3;
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Location = new System.Drawing.Point(22, 92);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(197, 23);
            this.txtNombreArchivo.TabIndex = 4;
            // 
            // btnBuscarCarpeta
            // 
            this.btnBuscarCarpeta.Location = new System.Drawing.Point(269, 24);
            this.btnBuscarCarpeta.Name = "btnBuscarCarpeta";
            this.btnBuscarCarpeta.Size = new System.Drawing.Size(95, 23);
            this.btnBuscarCarpeta.TabIndex = 5;
            this.btnBuscarCarpeta.Text = "Buscar Carpeta";
            this.btnBuscarCarpeta.UseVisualStyleBackColor = true;
            this.btnBuscarCarpeta.Click += new System.EventHandler(this.btnBuscarCarpeta_Click);
            // 
            // lblNombreDelArchivo
            // 
            this.lblNombreDelArchivo.AutoSize = true;
            this.lblNombreDelArchivo.Location = new System.Drawing.Point(22, 66);
            this.lblNombreDelArchivo.Name = "lblNombreDelArchivo";
            this.lblNombreDelArchivo.Size = new System.Drawing.Size(115, 15);
            this.lblNombreDelArchivo.TabIndex = 6;
            this.lblNombreDelArchivo.Text = "Nombre del archivo:";
            // 
            // FrmExportarAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 173);
            this.Controls.Add(this.lblNombreDelArchivo);
            this.Controls.Add(this.btnBuscarCarpeta);
            this.Controls.Add(this.txtNombreArchivo);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gpbTipoDeArchivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExportarAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar Asistencia";
            this.Load += new System.EventHandler(this.FrmExportarAsistencia_Load);
            this.gpbTipoDeArchivo.ResumeLayout(false);
            this.gpbTipoDeArchivo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbTipoDeArchivo;
        private System.Windows.Forms.RadioButton rbtCsv;
        private System.Windows.Forms.RadioButton rbtTxt;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.TextBox txtNombreArchivo;
        private System.Windows.Forms.Button btnBuscarCarpeta;
        private System.Windows.Forms.Label lblNombreDelArchivo;
    }
}