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
    public partial class TelasBodegaVista_Proveedor : Form
    {
        public int idproveedor { get; set; }
        public TelasBodegaVista_Proveedor()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void TelasBodegaVista_Proveedor_Load(object sender, EventArgs e)
        {
            PLANTILLAS.TelasBodegaVista_Proveedor report = new PLANTILLAS.TelasBodegaVista_Proveedor();
            DAO.TelasDAO telasdao = new DAO.TelasDAO();
            telasdao.proveedor = this.idproveedor;
            report.SetDataSource(telasdao.devuelvetelasbodegaproveedor());
           // report.Subreports["AviosSubRPT"].SetDataSource(aviosdao.sacar_avios());
         //   report.Subreports["PiezasSubRPT"].SetDataSource(piezasdao.devuelvepiezasfichas());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
