using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class ImpresionBodegaDeavios : Form
    {
        public ImpresionBodegaDeavios()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ImpresionBodegaDeavios_Load(object sender, EventArgs e)
        {
            DAO.AviosDAO daoavios = new DAO.AviosDAO();
            GUI.PLANTILLAS.Vistabodega_Avios report = new PLANTILLAS.Vistabodega_Avios();
            report.SetDataSource(daoavios.devuelvebodegaaviosparaimprimir());
            //report.Subreports["CrystalReport1.rpt"].SetDataSource(produccion.tallas_preliminaresproduccion());
            //report.Subreports["ModeloSubrpt"].SetDataSource(ordendao.devuelvepellones());

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
