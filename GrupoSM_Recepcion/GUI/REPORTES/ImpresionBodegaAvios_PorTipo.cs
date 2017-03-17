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
    public partial class ImpresionBodegaAvios_PorTipo : Form
    {
        public int tipoavio { get; set; }
        public ImpresionBodegaAvios_PorTipo()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ImpresionBodegaAvios_PorTipo_Load(object sender, EventArgs e)
        {
            GUI.PLANTILLAS.VistaBodegaAvios_PorTipo report = new PLANTILLAS.VistaBodegaAvios_PorTipo();
            DAO.AviosDAO aviosdao = new DAO.AviosDAO();
            aviosdao.tipo = this.tipoavio;
            report.SetDataSource(aviosdao.vistaimpresionbodegaaviosportipo());
            //report.Subreports["AviosSubRPT"].SetDataSource(aviosdao.sacar_avios());
           // report.Subreports["PiezasSubRPT"].SetDataSource(piezasdao.devuelvepiezasfichas());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
