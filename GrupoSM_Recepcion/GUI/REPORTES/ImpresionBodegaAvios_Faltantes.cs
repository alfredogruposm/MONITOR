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
    public partial class ImpresionBodegaAvios_Faltantes : Form
    {
        public ImpresionBodegaAvios_Faltantes()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ImpresionBodegaAvios_Faltantes_Load(object sender, EventArgs e)
        {
            GUI.PLANTILLAS.VistaBodegaAvios_Faltantes report = new PLANTILLAS.VistaBodegaAvios_Faltantes();
            DAO.AviosDAO aviosdao = new DAO.AviosDAO();
            report.SetDataSource(aviosdao.devuelvefaltantesaviosbodega());
            //report.Subreports["AviosSubRPT"].SetDataSource(aviosdao.sacar_avios());
            // report.Subreports["PiezasSubRPT"].SetDataSource(piezasdao.devuelvepiezasfichas());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
