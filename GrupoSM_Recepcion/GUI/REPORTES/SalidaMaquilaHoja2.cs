using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class SalidaMaquilaHoja2 : Form
    {
        public SalidaMaquilaHoja2()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        public int idproduccion { get; set; }
        public int idficha { get; set; }

        private void SalidaMaquilaHoja2_Load(object sender, EventArgs e)
        {
            DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
            salidasdao.idproduccion = this.idproduccion;

            DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
            fichadao.id_fichatecnica = this.idficha;

            GUI.PLANTILLAS.SalidaMaquila2 report = new GrupoSM_Recepcion.GUI.PLANTILLAS.SalidaMaquila2();

            report.SetDataSource(salidasdao.devuelvedetallesalidas());
            report.Subreports["EspecificacionesSubrpt"].SetDataSource(fichadao.fichatecnicavista());

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
