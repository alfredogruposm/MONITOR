using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class FichaTecnicaPagina1 : Form
    {
        public FichaTecnicaPagina1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public int idficha { get; set; }

        private void FichaTecnicaPagina1_Load(object sender, EventArgs e)
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.id_ficha_avio = (this.idficha);

            DAO.Ficha_tecnicaDAO fichas = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
            fichas.id_fichatecnica = this.idficha;

            DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
            piezasdao.idficha = this.idficha;

            //ReportDocument report = new ReportDocument();
            GUI.PLANTILLAS.FichaTecnicaP1_RPT report = new GrupoSM_Recepcion.GUI.PLANTILLAS.FichaTecnicaP1_RPT();

            report.SetDataSource(fichas.fichatecnicavista());
            report.Subreports["AviosSubRPT"].SetDataSource(aviosdao.sacar_avios());
            report.Subreports["PiezasSubRPT"].SetDataSource(piezasdao.devuelvepiezasfichas());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
