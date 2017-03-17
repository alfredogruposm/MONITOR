using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class FichaTecnicaPagina2 : Form
    {
        public FichaTecnicaPagina2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public int idficha { get; set; }

        private void FichaTecnicaPagina2_Load(object sender, EventArgs e)
        {
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            procesosdao.idficha = this.idficha;

            DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
            acabadosdao.idficha = this.idficha;

            //ReportDocument report = new ReportDocument();
            GUI.PLANTILLAS.FichaTecnicaP2 report = new GrupoSM_Recepcion.GUI.PLANTILLAS.FichaTecnicaP2();

            report.SetDataSource(procesosdao.verprocesosfichas());
            report.Subreports["AcabadosSubRPT"].SetDataSource(acabadosdao.acabados_fichas());
            
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
