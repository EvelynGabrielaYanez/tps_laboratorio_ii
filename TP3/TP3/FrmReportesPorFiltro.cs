using EntidadesAsociacion;
using EntidadesAsociacion.Controladores;
using EntidadesAsociacion.Reportes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static EntidadesAsociacion.Enumerados;

namespace TP3
{
    public partial class FrmReportesPorFiltro : Form
    {
        private List<Usuario> dataDeLaTabla;

        /// <summary>
        /// Método constructor del formulario
        /// </summary>
        public FrmReportesPorFiltro()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método ecargado de configurar la apariencia e incializar los campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmReportes_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(159, 94, 142);
            btnFiltrar.BackColor = Color.FromArgb(202, 142, 186);
            btnQuitarFiltro.BackColor = Color.FromArgb(202, 142, 186);

            this.ReiniciarDataGrid();
            chbDenuncias.Checked = false;
            chbMotivoIngreso.Checked = false;
            chbFecha.Checked = false;
            nudDenunciasDesde.Enabled = false;
            nudDenunciasHasta.Enabled = false;
            dtpFechaDesde.Enabled = false;
            dtpFechaHasta.Enabled = false;
            chblstMotivosDeIngreso.Enabled = false;
            this.CargarMotivosDeIngreso();
        }

        /// <summary>
        /// Método encargado de cargar en el checbox list los motivos de ingreso
        /// </summary>
        private void CargarMotivosDeIngreso()
        {
            foreach (ETipoCausaIngreso causa in Enum.GetValues(typeof(ETipoCausaIngreso)))
            {
                chblstMotivosDeIngreso.Items.Add(causa);
            }
        }

        /// <summary>
        /// Método encargado de recargar el datagrid sin ningun filtro
        /// </summary>
        private void ReiniciarDataGrid()
        {

            Reporte<Usuario> datosFiltrados = new Reporte<Usuario>();

            foreach (Usuario usuario in Asociacion.ListaUsuarios)
            {
                datosFiltrados.DatosReporte.Add(usuario);
            }
            dataDeLaTabla = datosFiltrados.DatosReporte;

            dgvReporte.DataSource = datosFiltrados.DatosReporte;
        }

        /// <summary>
        /// Método encargado de abrir el formulario de exportacion pasandole el reporte correpsondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            Reporte<Usuario> datosFiltrados = new Reporte<Usuario>();
            datosFiltrados.DatosReporte = new List<Usuario>((List<Usuario>)dgvReporte.DataSource);
            FrmExportar frmExportar = new FrmExportar(datosFiltrados);
            this.Hide();
            frmExportar.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Método encargado de filtrar segun los filtros seleccionados el listado de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (chbFecha.Checked)
            {
                dataDeLaTabla = UsuarioControlador.FiltrarPorFecha(dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date, dataDeLaTabla);
            }

            if (chbDenuncias.Checked)
            {
                dataDeLaTabla = UsuarioControlador.FiltrarCantidadDenuncias((int)nudDenunciasDesde.Value, (int)nudDenunciasHasta.Value, dataDeLaTabla);
            }

            List<ETipoCausaIngreso> causasSeleccionadas = ObtenerMotivosDeIngresoSeleccionados();
            if (chbMotivoIngreso.Checked && causasSeleccionadas.Count > 0)
            {
                dataDeLaTabla = UsuarioControlador.FiltrarCausaDeIngreso(causasSeleccionadas, dataDeLaTabla);
            }

            dgvReporte.DataSource = dataDeLaTabla;
        }

        /// <summary>
        /// Método encargado de obtener los motivos de ingreso seleccioados en el checkbox list
        /// </summary>
        /// <returns>Listado de ETipoCausaIngreso con las causas seleccionadas</returns>
        private List<ETipoCausaIngreso> ObtenerMotivosDeIngresoSeleccionados()
        {
            List<ETipoCausaIngreso> listadoRetorno = new List<ETipoCausaIngreso>();
            for (int i = 0; i < chblstMotivosDeIngreso.CheckedItems.Count; i++)
            {
                listadoRetorno.Add((ETipoCausaIngreso)chblstMotivosDeIngreso.CheckedItems[i]);
            }
            return listadoRetorno;
        }

        /// <summary>
        /// Método encargado de quitar el filtro y reiniciar el datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            this.ReiniciarDataGrid();
        }

        /// <summary>
        /// Método encargado de manejar la habilitacion de los campos segun el estado del checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbMotivoIngreso_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbMotivoIngreso.Checked)
            {
                chblstMotivosDeIngreso.Enabled = true;
            }
            else
            {
                chblstMotivosDeIngreso.Enabled = false;
            }
        }

        /// <summary>
        /// Método encargado de manejar la habilitacion de los campos segun el estado del checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbDenuncias_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbDenuncias.Checked)
            {
                nudDenunciasDesde.Enabled = true;
                nudDenunciasHasta.Enabled = true;
            }
            else
            {
                nudDenunciasDesde.Enabled = false;
                nudDenunciasHasta.Enabled = false;
            }
        }

        /// <summary>
        /// Método encargado de manejar la habilitacion de los campos segun el estado del checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbFecha_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbFecha.Checked)
            {
                dtpFechaDesde.Enabled = true;
                dtpFechaHasta.Enabled = true;
            }
            else
            {
                dtpFechaDesde.Enabled = false;
                dtpFechaHasta.Enabled = false;
            }
        }
    }
}
