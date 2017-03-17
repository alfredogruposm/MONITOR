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
    public partial class TelasBodegaVistas_Almacen : Form
    {
        public TelasBodegaVistas_Almacen()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void TelasBodegaVistas_Almacen_Load(object sender, EventArgs e)
        {
            PLANTILLAS.TelasBodegaVista_Almacen report = new PLANTILLAS.TelasBodegaVista_Almacen();
            DAO.TelasDAO telasdao = new DAO.TelasDAO();
            report.SetDataSource(telasdao.tablatelas());
            // report.Subreports["AviosSubRPT"].SetDataSource(aviosdao.sacar_avios());
            //   report.Subreports["PiezasSubRPT"].SetDataSource(piezasdao.devuelvepiezasfichas());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
