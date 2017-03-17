using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class Pruebatallas : Form
    {
        public Pruebatallas()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public int idproduccion { get; set; }
        public int idficha { get; set; }

        private void Pruebatallas_Load(object sender, EventArgs e)
        {
            
        }

        private void Pruebatallas_Load_1(object sender, EventArgs e)
        {
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            ordendao.idorden = (this.idproduccion);

            DAO.ProduccionDAO produccion = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            produccion.id_produccion = this.idproduccion;

            DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
            salidasdao.idproduccion = this.idproduccion;

            //ReportDocument report = new ReportDocument();
            GUI.PLANTILLAS.SalidaMaquilaRPT report = new GrupoSM_Recepcion.GUI.PLANTILLAS.SalidaMaquilaRPT();

            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.id_ficha_avio = this.idficha;

            report.SetDataSource(salidasdao.devuelvedetallesalidas());

            report.Subreports["NumPrendas"].SetDataSource(ordendao.numeroprendasreporte());
            report.Subreports["CrystalReport1.rpt"].SetDataSource(produccion.tallas_preliminaresproduccion());
            report.Subreports["AviosDetalleServicios"].SetDataSource(aviosdao.sacar_avios());

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}