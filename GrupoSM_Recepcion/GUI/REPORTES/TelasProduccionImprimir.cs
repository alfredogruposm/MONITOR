using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class TelasProduccionImprimir : Form
    {
        public TelasProduccionImprimir()
        {
            InitializeComponent(); 
            this.WindowState = FormWindowState.Maximized;
        }
        public int idproduccion { get; set; }
        private void TelasProduccionImprimir_Load(object sender, EventArgs e)
        {
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            ordendao.idorden = (this.idproduccion);
            GUI.PLANTILLAS.Telas_RPT report = new GrupoSM_Recepcion.GUI.PLANTILLAS.Telas_RPT();
            report.SetDataSource(ordendao.datosproduccionreporteFull());
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = (this.idproduccion);
            report.Subreports["CombinacionSubRPT"].SetDataSource(producciondao.combinacionproduccion());
            report.Subreports["TelasSubRPT"].SetDataSource(producciondao.vertelasproduccionsum());
            report.Subreports["NumeroPrendasRPT"].SetDataSource(ordendao.numeroprendasreporte());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
