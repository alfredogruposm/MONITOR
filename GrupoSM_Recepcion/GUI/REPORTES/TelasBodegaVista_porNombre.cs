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
    public partial class TelasBodegaVista_porNombre : Form
    {

        public string nombretela { get; set; }
        public TelasBodegaVista_porNombre()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void TelasBodegaVista_porNombre_Load(object sender, EventArgs e)
        {
            PLANTILLAS.TelasBodegaVista_porNombre report = new PLANTILLAS.TelasBodegaVista_porNombre();
            DAO.TelasDAO telasdao = new DAO.TelasDAO();
            telasdao.nombre_descripcion = this.nombretela;
            report.SetDataSource(telasdao.devuelvetelasbodegaNombre());
            // report.Subreports["AviosSubRPT"].SetDataSource(aviosdao.sacar_avios());
            //   report.Subreports["PiezasSubRPT"].SetDataSource(piezasdao.devuelvepiezasfichas());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
