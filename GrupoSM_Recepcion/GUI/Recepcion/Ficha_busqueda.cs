using System;
using System.Windows.Forms;
using System.Data;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class Ficha_busqueda : Form
    {
        GUI.Recepcion.Orden_Produccion ordengui;
        public Ficha_busqueda(GUI.Recepcion.Orden_Produccion fr1)
        {
            InitializeComponent();

            ordengui = new Orden_Produccion();
            ordengui = fr1;
        }

        private void Ficha_busqueda_Load(object sender, EventArgs e)
        {
            DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
            dataGridView1.DataSource = fichadao.fichas_tecnicas();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ordengui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre_prenda"].Value);
                ordengui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_tela"].Value);
                ordengui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha_tecnica"].Value);
                ordengui.label8.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tela"].Value);
                ordengui.label9.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["combinacion"].Value);
                ordengui.textBox1.Enabled = false;
                ordengui.textBox2.Enabled = false;
                ordengui.textBox3.Enabled = false;
                ordengui.button3.Visible = true;
                this.Visible = false;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Escoja una ficha tecnica");
            }


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string campo;
            if (comboBox1.SelectedIndex == 0)
            {
                campo = "nombre_prenda";
            }
            else
            {
                campo = "modelo";
            }
            DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
            DataView dv = new DataView(fichadao.fichas_tecnicas());
            dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";

            dataGridView1.DataSource = dv;
        }
    }
}
