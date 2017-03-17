using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class HojaCorte1 : Form
    {
        public HojaCorte1()
        {
            InitializeComponent(); 
            this.WindowState = FormWindowState.Maximized;
        }
        public int idproduccion { get; set; }

        private void HojaCorte1_Load(object sender, EventArgs e)
        {
            DAO.ProduccionDAO produccion = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            produccion.id_produccion = this.idproduccion;
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            ordendao.idorden = this.idproduccion;
            DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
            salidasdao.idproduccion = this.idproduccion;
            GUI.PLANTILLAS.HojaCorte1 report = new GrupoSM_Recepcion.GUI.PLANTILLAS.HojaCorte1();
            report.SetDataSource(salidasdao.devuelvehojacorte1());
            report.Subreports["CrystalReport1.rpt"].SetDataSource(produccion.tallas_preliminaresproduccion());
            report.Subreports["ModeloSubrpt"].SetDataSource(ordendao.devuelvepellones());

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
