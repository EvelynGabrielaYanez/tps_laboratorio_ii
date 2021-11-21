using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Reportes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace AsociacionPabloBesson
{
    public partial class FrmReportesPorPorcentaje : Form
    {

        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        public FrmReportesPorPorcentaje()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método encargado de abrir el formulario de exportacion generando el reporte correpsondiente a la data del datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            Reporte<RegistroPorcentaje> datosFiltrados = new Reporte<RegistroPorcentaje>();
            datosFiltrados.DatosReporte = new List<RegistroPorcentaje>((List<RegistroPorcentaje>)dgvReporte.DataSource);
            FrmExportar frmExportar = new FrmExportar(datosFiltrados);
            this.Hide();
            frmExportar.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Método encargado de configurar la apariencioa e inicializar los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmReportesPorPorcentaje_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(159, 94, 142);

            nudIntervaloDenuncias.Value = 1;
            //nudIntervaloMeses.Value = 1;
            chbDenuncias.Checked = true;
            chbMeses.Checked = false;
            chbCausaDeIngreso.Checked = false;
            nudIntervaloMeses.Enabled = false;
            chbTipoAsistencia.Checked = false;
            cmbGrupo.DataSource = Enum.GetValues(typeof(EGrupo));
        }

        /// <summary>
        /// Método encargado de calcular el porcentaje segun el checkbox seleccionado y actualziar el datagrid
        /// </summary>
        private void CalcularReporte()
        {
            List<RegistroPorcentaje> resultado = new List<RegistroPorcentaje>();
            if (chbDenuncias.Checked)
            {
                resultado = UsuarioControlador.CalcularPorcentajePorDenuncias((int)nudIntervaloDenuncias.Value);
            }
            else if (chbMeses.Checked)
            {
                resultado = UsuarioControlador.CalcularPorcentajesPorMeses((int)nudIntervaloMeses.Value);
            }
            else if (chbCausaDeIngreso.Checked)
            {
                resultado = UsuarioControlador.CalcularPorcentajesPorCausaIngreso();
            }
            else if (chbTipoAsistencia.Checked)
            {
                resultado = AsistenciaControlador.CalcularPorcentaPorTipoAsistencia((EGrupo)cmbGrupo.SelectedItem);
            }
            dgvReporte.DataSource = resultado;
        }

        /// <summary>
        /// Método encargado de manejar los checbox habilidtados segun el cambop de estado que disparo el evento y actualizar los datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbDenuncias_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbDenuncias.Checked)
            {
                nudIntervaloDenuncias.Enabled = true;
                nudIntervaloMeses.Enabled = false;
                chbCausaDeIngreso.Checked = false;
                chbMeses.Checked = false;
                chbTipoAsistencia.Checked = false;
                cmbGrupo.Enabled = false;
            }
            else
            {
                nudIntervaloDenuncias.Enabled = false;

            }
            this.CalcularReporte();
        }

        /// <summary>
        /// Método encargado de manejar los checbox habilidtados segun el cambop de estado que disparo el evento y actualizar los datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbMeses_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbMeses.Checked)
            {
                nudIntervaloMeses.Enabled = true;
                nudIntervaloDenuncias.Enabled = false;
                chbCausaDeIngreso.Checked = false;
                chbDenuncias.Checked = false;
                chbTipoAsistencia.Checked = false;
                cmbGrupo.Enabled = false;
            }
            else
            {
                nudIntervaloMeses.Enabled = false;
            }
            this.CalcularReporte();
        }

        /// <summary>
        /// Método encargado de manejar los checbox habilidtados segun el cambop de estado que disparo el evento y actualizar los datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbCausaDeIngreso_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbCausaDeIngreso.Checked)
            {
                chbMeses.Checked = false;
                chbDenuncias.Checked = false;
                nudIntervaloMeses.Enabled = false;
                nudIntervaloDenuncias.Enabled = false;
                chbTipoAsistencia.Checked = false;
                cmbGrupo.Enabled = false;
            }
            this.CalcularReporte();
        }

        /// <summary>
        /// Método encargado de manejar los checbox habilidtados segun el cambop de estado que disparo el evento y actualizar los datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbTipoAsistencia_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbTipoAsistencia.Checked)
            {
                nudIntervaloMeses.Enabled = false;
                nudIntervaloDenuncias.Enabled = false;
                chbCausaDeIngreso.Checked = false;
                chbDenuncias.Checked = false;
                chbCausaDeIngreso.Checked = false;
                chbMeses.Checked = false;
                chbTipoAsistencia.Checked = true;
                cmbGrupo.Enabled = true;
            }
            else
            {
                cmbGrupo.Enabled = false;
            }
            this.CalcularReporte();
        }

        /// <summary>
        /// Método  erncagado de actualizar el reporte cuando cambie el valor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudIntervaloDenuncias_ValueChanged(object sender, EventArgs e)
        {
            this.CalcularReporte();
        }

        /// <summary>
        /// Método  erncagado de actualizar el reporte cuando cambie el valor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudIntervaloMeses_ValueChanged(object sender, EventArgs e)
        {
            this.CalcularReporte();
        }

        /// <summary>
        /// Método  erncagado de actualizar el reporte cuando cambie el valor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalcularReporte();
        }
    }
}
