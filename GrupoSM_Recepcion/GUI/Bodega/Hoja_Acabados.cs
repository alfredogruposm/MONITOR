using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Hoja_Acabados : Form
    {
        public Hoja_Acabados()
        {
            InitializeComponent();
        }

        private void Hoja_Acabados_Load(object sender, EventArgs e)
        {
            try
            {
                double sumatoria = 0;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    sumatoria += Convert.ToDouble(row.Cells["Cantidad Recibida"].Value);
                }

                textBox4.Text = Convert.ToString(sumatoria);
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
