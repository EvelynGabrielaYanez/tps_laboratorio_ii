
namespace AsociacionPabloBesson
{
    partial class FrmInicioSesion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblNombreAsociacion = new System.Windows.Forms.Label();
            this.pbLogoAsociacion = new System.Windows.Forms.PictureBox();
            this.txtNombreCuenta = new System.Windows.Forms.TextBox();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.lblUsuarioInvalido = new System.Windows.Forms.Label();
            this.lblAutocompletar = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoAsociacion)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.lblNombreAsociacion);
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(461, 40);
            this.pnlEncabezado.TabIndex = 0;
            // 
            // lblNombreAsociacion
            // 
            this.lblNombreAsociacion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreAsociacion.Location = new System.Drawing.Point(73, 3);
            this.lblNombreAsociacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreAsociacion.Name = "lblNombreAsociacion";
            this.lblNombreAsociacion.Size = new System.Drawing.Size(312, 28);
            this.lblNombreAsociacion.TabIndex = 5;
            this.lblNombreAsociacion.Text = "Asociación Pablo Besson";
            this.lblNombreAsociacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogoAsociacion
            // 
            this.pbLogoAsociacion.BackColor = System.Drawing.SystemColors.Control;
            this.pbLogoAsociacion.Image = global::AsociacionPabloBesson.Properties.Resources.logoAsociacion;
            this.pbLogoAsociacion.Location = new System.Drawing.Point(-1, 36);
            this.pbLogoAsociacion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbLogoAsociacion.Name = "pbLogoAsociacion";
            this.pbLogoAsociacion.Size = new System.Drawing.Size(168, 170);
            this.pbLogoAsociacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoAsociacion.TabIndex = 1;
            this.pbLogoAsociacion.TabStop = false;
            // 
            // txtNombreCuenta
            // 
            this.txtNombreCuenta.Location = new System.Drawing.Point(270, 63);
            this.txtNombreCuenta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNombreCuenta.Name = "txtNombreCuenta";
            this.txtNombreCuenta.PlaceholderText = "Ingrese el nombre de usuario";
            this.txtNombreCuenta.Size = new System.Drawing.Size(163, 22);
            this.txtNombreCuenta.TabIndex = 2;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Location = new System.Drawing.Point(270, 100);
            this.txtContrasenia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.PasswordChar = '*';
            this.txtContrasenia.PlaceholderText = "Ingrese la contraseña";
            this.txtContrasenia.Size = new System.Drawing.Size(163, 22);
            this.txtContrasenia.TabIndex = 3;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreUsuario.Location = new System.Drawing.Point(191, 64);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(64, 17);
            this.lblNombreUsuario.TabIndex = 4;
            this.lblNombreUsuario.Text = "Usuario:";
            this.lblNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContrasenia.Location = new System.Drawing.Point(191, 101);
            this.lblContrasenia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(76, 17);
            this.lblContrasenia.TabIndex = 5;
            this.lblContrasenia.Text = "Contraseña:";
            this.lblContrasenia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUsuarioInvalido
            // 
            this.lblUsuarioInvalido.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsuarioInvalido.Location = new System.Drawing.Point(191, 135);
            this.lblUsuarioInvalido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarioInvalido.Name = "lblUsuarioInvalido";
            this.lblUsuarioInvalido.Size = new System.Drawing.Size(241, 14);
            this.lblUsuarioInvalido.TabIndex = 6;
            this.lblUsuarioInvalido.Text = "Usuario o contaseña invalidos";
            this.lblUsuarioInvalido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAutocompletar
            // 
            this.lblAutocompletar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAutocompletar.Location = new System.Drawing.Point(191, 180);
            this.lblAutocompletar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutocompletar.Name = "lblAutocompletar";
            this.lblAutocompletar.Size = new System.Drawing.Size(241, 14);
            this.lblAutocompletar.TabIndex = 7;
            this.lblAutocompletar.Text = "Autocompletar Usuario";
            this.lblAutocompletar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAutocompletar.Click += new System.EventHandler(this.lblAutocompletar_Click);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Location = new System.Drawing.Point(191, 153);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(242, 21);
            this.btnIniciarSesion.TabIndex = 8;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // FrmInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 205);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.lblAutocompletar);
            this.Controls.Add(this.lblUsuarioInvalido);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.txtContrasenia);
            this.Controls.Add(this.txtNombreCuenta);
            this.Controls.Add(this.pnlEncabezado);
            this.Controls.Add(this.pbLogoAsociacion);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio Sesión";
            this.Load += new System.EventHandler(this.FrmInicioSesion_Load);
            this.pnlEncabezado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoAsociacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblNombreAsociacion;
        private System.Windows.Forms.PictureBox pbLogoAsociacion;
        private System.Windows.Forms.TextBox txtNombreCuenta;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.Label lblUsuarioInvalido;
        private System.Windows.Forms.Label lblAutocompletar;
        private System.Windows.Forms.Button btnIniciarSesion;
    }
}

