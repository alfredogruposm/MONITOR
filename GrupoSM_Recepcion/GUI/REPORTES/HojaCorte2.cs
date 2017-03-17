using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class HojaCorte2 : Form
    {
        public HojaCorte2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        public int idficha { get; set; }
        public int idproduccion { get; set; }

        private void HojaCorte2_Load(object sender, EventArgs e)
        {

            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            ordendao.idorden = this.idproduccion;

            //DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
            //salidasdao.idproduccion = this.idproduccion;

            DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
            piezasdao.idficha = this.idficha;

            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.id_ficha_avio = this.idficha;
            aviosdao.idproduccion = this.idproduccion;
            DAO.Ficha_tecnicaDAO fichasdao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
            fichasdao.id_fichatecnica=this.idficha;

            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            telasdao.id_tela_produccion = this.idproduccion;

            GUI.PLANTILLAS.HojaCorte2 report = new GrupoSM_Recepcion.GUI.PLANTILLAS.HojaCorte2();
            report.SetDataSource(piezasdao.devuelvepiezasfichas());
            report.Subreports["AviosSubRPT"].SetDataSource(aviosdao.aviosimpresion());
            report.Subreports["PiezasSubRPT"].SetDataSource(piezasdao.devuelvepiezasfichas());
            //report.Subreports["FichaSubRPT"].SetDataSource(fichasdao.fichatecnicavista());
            report.Subreports["TelasSubRpt"].SetDataSource(telasdao.vertelasproduccion());
            //report.Subreports["PellonesSubRPT"].SetDataSource(ordendao.devuelvepellones());
            //report.Subreports["ComposicionSubrpt"].SetDataSource(ordendao.devuelvepellones());
            //report.Subreports["MarcaSubrpt"].SetDataSource(ordendao.devuelvepellones());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
