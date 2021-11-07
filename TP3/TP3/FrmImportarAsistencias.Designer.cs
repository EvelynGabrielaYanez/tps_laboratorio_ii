
namespace TP3
{
    partial class FrmImportarAsistencias
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
            this.txtRutaArchivo = new System.Windows.Forms.TextBox();
            this.btnBuscarArchivo = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNombreDelArchivo = new System.Windows.Forms.Label();
            this.txtNombreArchivo = new System.Windows.Forms.TextBox();
            this.gpbTipoDeArchivo = new System.Windows.Forms.GroupBox();
            this.rbtJson = new System.Windows.Forms.RadioButton();
            this.rbtXml = new System.Windows.Forms.RadioButton();
            this.gpbTipoDeArchivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Enabled = false;
            this.txtRutaArchivo.Location = new System.Drawing.Point(26, 22);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(215, 23);
            this.txtRutaArchivo.TabIndex = 1;
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.Location = new System.Drawing.Point(256, 21);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(110, 23);
            this.btnBuscarArchivo.TabIndex = 2;
            this.btnBuscarArchivo.Text = "Buscar Archivo";
            this.btnBuscarArchivo.UseVisualStyleBackColor = true;
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(204, 142);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(162, 23);
            this.btnImportar.TabIndex = 3;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(26, 142);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(172, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNombreDelArchivo
            // 
            this.lblNombreDelArchivo.AutoSize = true;
            this.lblNombreDelArchivo.Location = new System.Drawing.Point(29, 70);
            this.lblNombreDelArchivo.Name = "lblNombreDelArchivo";
            this.lblNombreDelArchivo.Size = new System.Drawing.Size(115, 15);
            this.lblNombreDelArchivo.TabIndex = 9;
            this.lblNombreDelArchivo.Text = "Nombre del archivo:";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Location = new System.Drawing.Point(29, 96);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(197, 23);
            this.txtNombreArchivo.TabIndex = 8;
            // 
            // gpbTipoDeArchivo
            // 
            this.gpbTipoDeArchivo.Controls.Add(this.rbtJson);
            this.gpbTipoDeArchivo.Controls.Add(this.rbtXml);
            this.gpbTipoDeArchivo.Location = new System.Drawing.Point(252, 70);
            this.gpbTipoDeArchivo.Name = "gpbTipoDeArchivo";
            this.gpbTipoDeArchivo.Size = new System.Drawing.Size(114, 49);
            this.gpbTipoDeArchivo.TabIndex = 7;
            this.gpbTipoDeArchivo.TabStop = false;
            this.gpbTipoDeArchivo.Text = "Tipo de Archivo";
            // 
            // rbtJson
            // 
            this.rbtJson.AutoSize = true;
            this.rbtJson.Location = new System.Drawing.Point(65, 22);
            this.rbtJson.Name = "rbtJson";
            this.rbtJson.Size = new System.Drawing.Size(47, 19);
            this.rbtJson.TabIndex = 1;
            this.rbtJson.TabStop = true;
            this.rbtJson.Text = "json";
            this.rbtJson.UseVisualStyleBackColor = true;
            // 
            // rbtXml
            // 
            this.rbtXml.AutoSize = true;
            this.rbtXml.Location = new System.Drawing.Point(14, 22);
            this.rbtXml.Name = "rbtXml";
            this.rbtXml.Size = new System.Drawing.Size(45, 19);
            this.rbtXml.TabIndex = 0;
            this.rbtXml.TabStop = true;
            this.rbtXml.Text = "xml";
            this.rbtXml.UseVisualStyleBackColor = true;
            // 
            // FrmImportarAsistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 189);
            this.Controls.Add(this.lblNombreDelArchivo);
            this.Controls.Add(this.txtNombreArchivo);
            this.Controls.Add(this.gpbTipoDeArchivo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnBuscarArchivo);
            this.Controls.Add(this.txtRutaArchivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportarAsistencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Asistencias";
            this.Load += new System.EventHandler(this.FrmImportarAsistencias_Load);
            this.gpbTipoDeArchivo.ResumeLayout(false);
            this.gpbTipoDeArchivo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRutaArchivo;
        private System.Windows.Forms.Button btnBuscarArchivo;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNombreDelArchivo;
        private System.Windows.Forms.TextBox txtNombreArchivo;
        private System.Windows.Forms.GroupBox gpbTipoDeArchivo;
        private System.Windows.Forms.RadioButton rbtJson;
        private System.Windows.Forms.RadioButton rbtXml;
    }
}