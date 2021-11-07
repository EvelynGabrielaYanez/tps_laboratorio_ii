
namespace TP3
{
    partial class FrmAutocompletar
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpTipoEmpleado = new System.Windows.Forms.GroupBox();
            this.rbtAdministrador = new System.Windows.Forms.RadioButton();
            this.rbtEmpleado = new System.Windows.Forms.RadioButton();
            this.grpTipoEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(144, 78);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(18, 78);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grpTipoEmpleado
            // 
            this.grpTipoEmpleado.Controls.Add(this.rbtAdministrador);
            this.grpTipoEmpleado.Controls.Add(this.rbtEmpleado);
            this.grpTipoEmpleado.Location = new System.Drawing.Point(18, 15);
            this.grpTipoEmpleado.Name = "grpTipoEmpleado";
            this.grpTipoEmpleado.Size = new System.Drawing.Size(246, 57);
            this.grpTipoEmpleado.TabIndex = 3;
            this.grpTipoEmpleado.TabStop = false;
            this.grpTipoEmpleado.Text = "Autocompeltar como";
            // 
            // rbtAdministrador
            // 
            this.rbtAdministrador.AutoSize = true;
            this.rbtAdministrador.Location = new System.Drawing.Point(126, 30);
            this.rbtAdministrador.Name = "rbtAdministrador";
            this.rbtAdministrador.Size = new System.Drawing.Size(101, 19);
            this.rbtAdministrador.TabIndex = 1;
            this.rbtAdministrador.Text = "Administrador";
            this.rbtAdministrador.UseVisualStyleBackColor = true;
            // 
            // rbtEmpleado
            // 
            this.rbtEmpleado.AutoSize = true;
            this.rbtEmpleado.Checked = true;
            this.rbtEmpleado.Location = new System.Drawing.Point(12, 30);
            this.rbtEmpleado.Name = "rbtEmpleado";
            this.rbtEmpleado.Size = new System.Drawing.Size(78, 19);
            this.rbtEmpleado.TabIndex = 0;
            this.rbtEmpleado.TabStop = true;
            this.rbtEmpleado.Text = "Empleado";
            this.rbtEmpleado.UseVisualStyleBackColor = true;
            // 
            // FrmAutocompletar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 113);
            this.Controls.Add(this.grpTipoEmpleado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAutocompletar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autocompletar usuario";
            this.grpTipoEmpleado.ResumeLayout(false);
            this.grpTipoEmpleado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpTipoEmpleado;
        private System.Windows.Forms.RadioButton rbtAdministrador;
        private System.Windows.Forms.RadioButton rbtEmpleado;
    }
}