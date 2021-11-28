namespace AsociacionPabloBesson
{
    partial class FrmReporteEstadistico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaracterizadoPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCaracterizacionGrupos = new System.Windows.Forms.Label();
            this.lblAnalisiCantidadCausasIngreso = new System.Windows.Forms.Label();
            this.lblGrupoMayorCantidadDenuncias = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblGrurpoDelUsuario = new System.Windows.Forms.Label();
            this.pnlLineaUno = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstbGrupoMayorCantidadDenuncias = new System.Windows.Forms.ListBox();
            this.lstbNroCausasDeIngreso = new System.Windows.Forms.ListBox();
            this.txtNroCausasDeIngreso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.pnlLineaUno.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.AllowUserToResizeColumns = false;
            this.dgvReporte.AllowUserToResizeRows = false;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grupo,
            this.CaracterizadoPor,
            this.Porcentaje});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporte.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReporte.Location = new System.Drawing.Point(25, 34);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowTemplate.Height = 13;
            this.dgvReporte.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReporte.Size = new System.Drawing.Size(732, 134);
            this.dgvReporte.TabIndex = 7;
            // 
            // Grupo
            // 
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            // 
            // CaracterizadoPor
            // 
            this.CaracterizadoPor.HeaderText = "Caracterizado Por";
            this.CaracterizadoPor.Name = "CaracterizadoPor";
            this.CaracterizadoPor.ReadOnly = true;
            this.CaracterizadoPor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Porcentaje
            // 
            this.Porcentaje.HeaderText = "Porcentaje";
            this.Porcentaje.Name = "Porcentaje";
            this.Porcentaje.ReadOnly = true;
            // 
            // lblCaracterizacionGrupos
            // 
            this.lblCaracterizacionGrupos.AutoSize = true;
            this.lblCaracterizacionGrupos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCaracterizacionGrupos.ForeColor = System.Drawing.Color.White;
            this.lblCaracterizacionGrupos.Location = new System.Drawing.Point(27, 10);
            this.lblCaracterizacionGrupos.Name = "lblCaracterizacionGrupos";
            this.lblCaracterizacionGrupos.Size = new System.Drawing.Size(287, 15);
            this.lblCaracterizacionGrupos.TabIndex = 10;
            this.lblCaracterizacionGrupos.Text = "Caracterización de los grupos por causa de ingreso:";
            // 
            // lblAnalisiCantidadCausasIngreso
            // 
            this.lblAnalisiCantidadCausasIngreso.AutoSize = true;
            this.lblAnalisiCantidadCausasIngreso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAnalisiCantidadCausasIngreso.ForeColor = System.Drawing.Color.White;
            this.lblAnalisiCantidadCausasIngreso.Location = new System.Drawing.Point(25, 196);
            this.lblAnalisiCantidadCausasIngreso.Name = "lblAnalisiCantidadCausasIngreso";
            this.lblAnalisiCantidadCausasIngreso.Size = new System.Drawing.Size(341, 15);
            this.lblAnalisiCantidadCausasIngreso.TabIndex = 12;
            this.lblAnalisiCantidadCausasIngreso.Text = "Número de causas de ingreso del usuario con más denuncias:";
            // 
            // lblGrupoMayorCantidadDenuncias
            // 
            this.lblGrupoMayorCantidadDenuncias.AutoSize = true;
            this.lblGrupoMayorCantidadDenuncias.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGrupoMayorCantidadDenuncias.ForeColor = System.Drawing.Color.White;
            this.lblGrupoMayorCantidadDenuncias.Location = new System.Drawing.Point(417, 196);
            this.lblGrupoMayorCantidadDenuncias.Name = "lblGrupoMayorCantidadDenuncias";
            this.lblGrupoMayorCantidadDenuncias.Size = new System.Drawing.Size(358, 15);
            this.lblGrupoMayorCantidadDenuncias.TabIndex = 19;
            this.lblGrupoMayorCantidadDenuncias.Text = "Grupo que posee integrantes con mayor cantidad de denuncias:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Location = new System.Drawing.Point(613, 259);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(144, 23);
            this.txtCantidad.TabIndex = 21;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.ForeColor = System.Drawing.Color.White;
            this.lblCantidad.Location = new System.Drawing.Point(613, 231);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(129, 15);
            this.lblCantidad.TabIndex = 22;
            this.lblCantidad.Text = "Cantidad de Denuncias";
            // 
            // lblGrurpoDelUsuario
            // 
            this.lblGrurpoDelUsuario.AutoSize = true;
            this.lblGrurpoDelUsuario.ForeColor = System.Drawing.Color.White;
            this.lblGrurpoDelUsuario.Location = new System.Drawing.Point(25, 231);
            this.lblGrurpoDelUsuario.Name = "lblGrurpoDelUsuario";
            this.lblGrurpoDelUsuario.Size = new System.Drawing.Size(161, 15);
            this.lblGrurpoDelUsuario.TabIndex = 23;
            this.lblGrurpoDelUsuario.Text = "Grupo en el que se encuentra";
            // 
            // pnlLineaUno
            // 
            this.pnlLineaUno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLineaUno.Controls.Add(this.panel1);
            this.pnlLineaUno.Location = new System.Drawing.Point(-3, 188);
            this.pnlLineaUno.Name = "pnlLineaUno";
            this.pnlLineaUno.Size = new System.Drawing.Size(796, 1);
            this.pnlLineaUno.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 1);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(397, 188);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 130);
            this.panel2.TabIndex = 28;
            // 
            // lstbGrupoMayorCantidadDenuncias
            // 
            this.lstbGrupoMayorCantidadDenuncias.FormattingEnabled = true;
            this.lstbGrupoMayorCantidadDenuncias.HorizontalScrollbar = true;
            this.lstbGrupoMayorCantidadDenuncias.ItemHeight = 15;
            this.lstbGrupoMayorCantidadDenuncias.Location = new System.Drawing.Point(446, 249);
            this.lstbGrupoMayorCantidadDenuncias.Name = "lstbGrupoMayorCantidadDenuncias";
            this.lstbGrupoMayorCantidadDenuncias.Size = new System.Drawing.Size(141, 49);
            this.lstbGrupoMayorCantidadDenuncias.TabIndex = 29;
            // 
            // lstbNroCausasDeIngreso
            // 
            this.lstbNroCausasDeIngreso.FormattingEnabled = true;
            this.lstbNroCausasDeIngreso.HorizontalScrollbar = true;
            this.lstbNroCausasDeIngreso.ItemHeight = 15;
            this.lstbNroCausasDeIngreso.Location = new System.Drawing.Point(25, 249);
            this.lstbNroCausasDeIngreso.Name = "lstbNroCausasDeIngreso";
            this.lstbNroCausasDeIngreso.Size = new System.Drawing.Size(168, 49);
            this.lstbNroCausasDeIngreso.TabIndex = 30;
            // 
            // txtNroCausasDeIngreso
            // 
            this.txtNroCausasDeIngreso.Enabled = false;
            this.txtNroCausasDeIngreso.Location = new System.Drawing.Point(216, 259);
            this.txtNroCausasDeIngreso.Name = "txtNroCausasDeIngreso";
            this.txtNroCausasDeIngreso.Size = new System.Drawing.Size(144, 23);
            this.txtNroCausasDeIngreso.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(446, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "Grupo/s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(216, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 15);
            this.label2.TabIndex = 32;
            this.label2.Text = "Nro de Causas de Ingreso";
            // 
            // FrmReporteEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 315);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstbNroCausasDeIngreso);
            this.Controls.Add(this.lstbGrupoMayorCantidadDenuncias);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlLineaUno);
            this.Controls.Add(this.lblGrurpoDelUsuario);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblGrupoMayorCantidadDenuncias);
            this.Controls.Add(this.txtNroCausasDeIngreso);
            this.Controls.Add(this.lblAnalisiCantidadCausasIngreso);
            this.Controls.Add(this.lblCaracterizacionGrupos);
            this.Controls.Add(this.dgvReporte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReporteEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Estadistico";
            this.Load += new System.EventHandler(this.FrmReporteEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.pnlLineaUno.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Label lblCaracterizacionGrupos;
        private System.Windows.Forms.Label lblAnalisiCantidadCausasIngreso;
        private System.Windows.Forms.Label lblGrupoMayorCantidadDenuncias;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblGrurpoDelUsuario;
        private System.Windows.Forms.Panel pnlLineaUno;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstbGrupoMayorCantidadDenuncias;
        private System.Windows.Forms.ListBox lstbNroCausasDeIngreso;
        private System.Windows.Forms.TextBox txtNroCausasDeIngreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaracterizadoPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje;
    }
}