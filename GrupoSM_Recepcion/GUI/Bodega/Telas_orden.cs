using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Telas_orden : Form
    {
        public Telas_orden()
        {
            InitializeComponent();
        }

        private void Telas_orden_Load(object sender, EventArgs e)
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = int.Parse(lbl_idorden.Text);
            dataGridView1.DataSource = producciondao.combinacionproduccion();
            dataGridView2.DataSource = producciondao.vertelasproduccionsum();
            double sumatoria = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sumatoria += Convert.ToDouble(row.Cells["cantidad_prendas"].Value);
            }

            tb_cantidad.Text = Convert.ToString(sumatoria);
            tb_metroforro.Text = Convert.ToString(double.Parse(tb_cantidad.Text) * double.Parse(lbl_consumoforro.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tb_cantidadcombinacion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cantidad_prendas"].Value);
            tb_metroscombinacion.Text = Convert.ToString(double.Parse(tb_cantidadcombinacion.Text) * double.Parse(lbl_consumocombinacion.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.REPORTES.TelasProduccionImprimir telasimpr = new GrupoSM_Recepcion.GUI.REPORTES.TelasProduccionImprimir();
            telasimpr.idproduccion = int.Parse(lbl_idorden.Text);
            telasimpr.Show();
        }
    }
}
