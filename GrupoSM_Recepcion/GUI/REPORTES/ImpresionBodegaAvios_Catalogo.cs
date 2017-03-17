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
    public partial class ImpresionBodegaAvios_Catalogo : Form
    {
        public ImpresionBodegaAvios_Catalogo()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ImpresionBodegaAvios_Catalogo_Load(object sender, EventArgs e)
        {
            GUI.PLANTILLAS.VistaBodegaAvios_Catalogo report = new PLANTILLAS.VistaBodegaAvios_Catalogo();
            DAO.AviosDAO aviosdao = new DAO.AviosDAO();
            report.SetDataSource(aviosdao.devuelvecatalogoaviosbodega());
            //report.Subreports["AviosSubRPT"].SetDataSource(aviosdao.sacar_avios());
            // report.Subreports["PiezasSubRPT"].SetDataSource(piezasdao.devuelvepiezasfichas());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
