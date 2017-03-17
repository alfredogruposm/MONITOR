using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Separado_Vista : Form
    {
        public Separado_Vista()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void Separado_Vista_Load(object sender, EventArgs e)
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = int.Parse(textBox1.Text);
            dataGridView1.DataSource = producciondao.tallas_preliminaresproduccion();

            try
            {
                double sumatoria = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    sumatoria += Convert.ToDouble(row.Cells["cantidad_prendas"].Value);
                }

                textBox5.Text = Convert.ToString(sumatoria);


            }
            catch
            {
                textBox5.Text = "0";
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = Convert.ToString(dataGridView2.CurrentRow.Cells["Nombre"].Value);
            int numero = Convert.ToInt32(dataGridView2.CurrentRow.Cells["cantidad"].Value);
            textBox6.Text=Convert.ToString(numero*int.Parse(textBox5.Text));
        }
    }
}
