
namespace AsociacionPabloBesson
{
    partial class FrmMenuPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.mnsMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmiListados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAsistencias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportesFiltros = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportesPorcentajes = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrHoraActual = new System.Windows.Forms.Timer(this.components);
            this.lblHoraActual = new System.Windows.Forms.Label();
            this.lblGrupoActivo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pcbLogoAsociacion = new System.Windows.Forms.PictureBox();
            this.lblTituloGrupoActivo = new System.Windows.Forms.Label();
            this.lblListaUsuarios = new System.Windows.Forms.Label();
            this.dgvAsistenciaDelDia = new System.Windows.Forms.DataGridView();
            this.lblNombreAgrupacion = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblCierreDeTurno = new System.Windows.Forms.Label();
            this.mnsMenuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogoAsociacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaDelDia)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMenuPrincipal
            // 
            this.mnsMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiListados,
            this.tsmiAsistencias,
            this.tsmiReportes});
            this.mnsMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsMenuPrincipal.Name = "mnsMenuPrincipal";
            this.mnsMenuPrincipal.Size = new System.Drawing.Size(550, 24);
            this.mnsMenuPrincipal.TabIndex = 0;
            this.mnsMenuPrincipal.Text = "menuStrip1";
            // 
            // tsmiListados
            // 
            this.tsmiListados.Name = "tsmiListados";
            this.tsmiListados.Size = new System.Drawing.Size(62, 20);
            this.tsmiListados.Text = "Listados";
            this.tsmiListados.Click += new System.EventHandler(this.tsmiListados_Click);
            // 
            // tsmiAsistencias
            // 
            this.tsmiAsistencias.Name = "tsmiAsistencias";
            this.tsmiAsistencias.Size = new System.Drawing.Size(77, 20);
            this.tsmiAsistencias.Text = "Asistencias";
            this.tsmiAsistencias.Click += new System.EventHandler(this.tsmiAsistencias_Click);
            // 
            // tsmiReportes
            // 
            this.tsmiReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReportesFiltros,
            this.tsmiReportesPorcentajes});
            this.tsmiReportes.Name = "tsmiReportes";
            this.tsmiReportes.Size = new System.Drawing.Size(65, 20);
            this.tsmiReportes.Text = "Reportes";
            // 
            // tsmiReportesFiltros
            // 
            this.tsmiReportesFiltros.Name = "tsmiReportesFiltros";
            this.tsmiReportesFiltros.Size = new System.Drawing.Size(199, 22);
            this.tsmiReportesFiltros.Text = "Análisis por Filtros";
            this.tsmiReportesFiltros.Click += new System.EventHandler(this.tsmiReportesFiltros_Click);
            // 
            // tsmiReportesPorcentajes
            // 
            this.tsmiReportesPorcentajes.Name = "tsmiReportesPorcentajes";
            this.tsmiReportesPorcentajes.Size = new System.Drawing.Size(199, 22);
            this.tsmiReportesPorcentajes.Text = "Análisis por Porcentajes";
            this.tsmiReportesPorcentajes.Click += new System.EventHandler(this.tsmiReportesPorcentajes_Click);
            // 
            // tmrHoraActual
            // 
            this.tmrHoraActual.Tick += new System.EventHandler(this.tmrHoraActual_Tick);
            // 
            // lblHoraActual
            // 
            this.lblHoraActual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHoraActual.Location = new System.Drawing.Point(87, 296);
            this.lblHoraActual.Name = "lblHoraActual";
            this.lblHoraActual.Size = new System.Drawing.Size(51, 25);
            this.lblHoraActual.TabIndex = 1;
            this.lblHoraActual.Text = "00:00:00";
            this.lblHoraActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGrupoActivo
            // 
            this.lblGrupoActivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGrupoActivo.Location = new System.Drawing.Point(133, 28);
            this.lblGrupoActivo.Name = "lblGrupoActivo";
            this.lblGrupoActivo.Size = new System.Drawing.Size(147, 19);
            this.lblGrupoActivo.TabIndex = 2;
            this.lblGrupoActivo.Text = "Viernes";
            this.lblGrupoActivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFecha.Location = new System.Drawing.Point(22, 299);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 19);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "88/88/8888";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcbLogoAsociacion
            // 
            this.pcbLogoAsociacion.BackColor = System.Drawing.Color.Transparent;
            this.pcbLogoAsociacion.Image = ((System.Drawing.Image)(resources.GetObject("pcbLogoAsociacion.Image")));
            this.pcbLogoAsociacion.Location = new System.Drawing.Point(451, 0);
            this.pcbLogoAsociacion.Name = "pcbLogoAsociacion";
            this.pcbLogoAsociacion.Size = new System.Drawing.Size(84, 86);
            this.pcbLogoAsociacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLogoAsociacion.TabIndex = 4;
            this.pcbLogoAsociacion.TabStop = false;
            // 
            // lblTituloGrupoActivo
            // 
            this.lblTituloGrupoActivo.AutoSize = true;
            this.lblTituloGrupoActivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloGrupoActivo.Location = new System.Drawing.Point(22, 28);
            this.lblTituloGrupoActivo.Name = "lblTituloGrupoActivo";
            this.lblTituloGrupoActivo.Size = new System.Drawing.Size(105, 19);
            this.lblTituloGrupoActivo.TabIndex = 5;
            this.lblTituloGrupoActivo.Text = "Grupo del día:";
            // 
            // lblListaUsuarios
            // 
            this.lblListaUsuarios.AutoSize = true;
            this.lblListaUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblListaUsuarios.Location = new System.Drawing.Point(22, 54);
            this.lblListaUsuarios.Name = "lblListaUsuarios";
            this.lblListaUsuarios.Size = new System.Drawing.Size(141, 19);
            this.lblListaUsuarios.TabIndex = 6;
            this.lblListaUsuarios.Text = "Listado de usuarios:";
            // 
            // dgvAsistenciaDelDia
            // 
            this.dgvAsistenciaDelDia.AllowUserToAddRows = false;
            this.dgvAsistenciaDelDia.AllowUserToDeleteRows = false;
            this.dgvAsistenciaDelDia.AllowUserToResizeRows = false;
            this.dgvAsistenciaDelDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsistenciaDelDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistenciaDelDia.Location = new System.Drawing.Point(22, 111);
            this.dgvAsistenciaDelDia.Name = "dgvAsistenciaDelDia";
            this.dgvAsistenciaDelDia.ReadOnly = true;
            this.dgvAsistenciaDelDia.RowTemplate.Height = 25;
            this.dgvAsistenciaDelDia.Size = new System.Drawing.Size(513, 185);
            this.dgvAsistenciaDelDia.TabIndex = 7;
            // 
            // lblNombreAgrupacion
            // 
            this.lblNombreAgrupacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreAgrupacion.Location = new System.Drawing.Point(318, 1);
            this.lblNombreAgrupacion.Name = "lblNombreAgrupacion";
            this.lblNombreAgrupacion.Size = new System.Drawing.Size(131, 85);
            this.lblNombreAgrupacion.TabIndex = 8;
            this.lblNombreAgrupacion.Text = "Asociación Pablo Besson";
            this.lblNombreAgrupacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.lblTituloGrupoActivo);
            this.pnlMenu.Controls.Add(this.lblNombreAgrupacion);
            this.pnlMenu.Controls.Add(this.lblListaUsuarios);
            this.pnlMenu.Controls.Add(this.lblGrupoActivo);
            this.pnlMenu.Controls.Add(this.pcbLogoAsociacion);
            this.pnlMenu.Location = new System.Drawing.Point(0, 25);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(550, 86);
            this.pnlMenu.TabIndex = 9;
            // 
            // lblCierreDeTurno
            // 
            this.lblCierreDeTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCierreDeTurno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCierreDeTurno.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCierreDeTurno.Location = new System.Drawing.Point(315, 300);
            this.lblCierreDeTurno.Name = "lblCierreDeTurno";
            this.lblCierreDeTurno.Size = new System.Drawing.Size(196, 19);
            this.lblCierreDeTurno.TabIndex = 10;
            this.lblCierreDeTurno.Text = "Registros de Asistencia Faltantes";
            this.lblCierreDeTurno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCierreDeTurno.Visible = false;
            this.lblCierreDeTurno.Click += new System.EventHandler(this.lblCierreDeTurno_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 322);
            this.Controls.Add(this.dgvAsistenciaDelDia);
            this.Controls.Add(this.lblCierreDeTurno);
            this.Controls.Add(this.mnsMenuPrincipal);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHoraActual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnsMenuPrincipal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.mnsMenuPrincipal.ResumeLayout(false);
            this.mnsMenuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogoAsociacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaDelDia)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmiListados;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportes;
        private System.Windows.Forms.Timer tmrHoraActual;
        private System.Windows.Forms.Label lblHoraActual;
        private System.Windows.Forms.Label lblGrupoActivo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.PictureBox pcbLogoAsociacion;
        private System.Windows.Forms.Label lblTituloGrupoActivo;
        private System.Windows.Forms.Label lblListaUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsmiAsistencias;
        private System.Windows.Forms.DataGridView dgvAsistenciaDelDia;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportesFiltros;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportesPorcentajes;
        private System.Windows.Forms.Label lblNombreAgrupacion;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblCierreDeTurno;
    }
}