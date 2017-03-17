using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class AviosProduccionImprimir : Form
    {
        public AviosProduccionImprimir()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        //    DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
        //    GUI.Bodega.Avios_captura avioscapturagui = new Avios_captura();
        //    aviosdao.id_ficha_avio = (Convert.ToInt16(dataGridView1.CurrentRow.Cells["idficha"].Value));
        //    DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
        //    ordendao.idorden = (Convert.ToInt16(dataGridView1.CurrentRow.Cells["id_orden"].Value));
        //    avioscapturagui.textBox2.Text = Convert.ToString(ordendao.devuelve_numeroprendas());
        //    avioscapturagui.label5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_orden"].Value);
            
        //    avioscapturagui.dataGridView1.DataSource = aviosdao.sacar_avios();
        public int idproduccion { get; set; }
        public int idficha { get; set; }
        


        //    avioscapturagui.ShowDialog();

        private void AviosProduccionImprimir_Load(object sender, EventArgs e)
        {
//            report As New DynamicReport
//report.SetDataSource(ds)
//report.Subreports.Item("SubReport1").SetDataSource(ds.Tables("Customers"))
//report.Subreports.Item("SubReport2").SetDataSource(ds.Tables("Orders"))
//CrystalReportViewer1.ReportSource = report
//CrystalReportViewer1.DataBind()
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            //aviosdao.id_ficha_avio = (this.idficha);
            aviosdao.idproduccion = this.idproduccion;
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            ordendao.idorden = (this.idproduccion);
            //ReportDocument report = new ReportDocument();
            GUI.PLANTILLAS.Avios_RPT report = new GrupoSM_Recepcion.GUI.PLANTILLAS.Avios_RPT();
            
            report.SetDataSource(ordendao.datosproduccionreporte());
            report.Subreports["NumeroprendasRPT"].SetDataSource(ordendao.numeroprendasreporte());
            //report.Subreports["AviosSubRPT"].SetDataSource(aviosdao.sacar_avios());
            report.Subreports["AviosRpt"].SetDataSource(aviosdao.aviosimpresion());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();



        }
    }
}
