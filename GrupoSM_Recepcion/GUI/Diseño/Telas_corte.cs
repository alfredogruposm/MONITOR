using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Telas_corte : Form
    {
        public Telas_corte()
        {
            InitializeComponent();
        }

        private void Telas_corte_Load(object sender, EventArgs e)
        {
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            telasdao.produccion = int.Parse(label9.Text);
            dataGridView1.DataSource = telasdao.telascorteproduccion();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Tela"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["metros"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["color"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Largo Trazo"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["paños"].Value);
                textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Tela Utilizada"].Value);
                textBox8.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Retazo Tela"].Value);
                textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Saldo"].Value);
                textBox9.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ancho"].Value);
                textBox10.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Faltante"].Value);
                label12.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_tela"].Value);
                button1.Visible = true;
            }
            catch
            {
                MessageBox.Show("No hay nada seleccionado");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao.id_tela_produccion = int.Parse(label12.Text);
                telasdao.largo_trazo = double.Parse(textBox4.Text);
                telasdao.paños = double.Parse(textBox5.Text);
                telasdao.utilizado_tela = double.Parse(textBox6.Text);
                telasdao.retazo_tela = double.Parse(textBox8.Text);
                telasdao.saldo_tela = double.Parse(textBox7.Text);
                telasdao.ancho = double.Parse(textBox9.Text);
                telasdao.faltante_tela = double.Parse(textBox10.Text);
                telasdao.actualizatelacorte();
                button1.Visible = false;
                DAO.TelasDAO telasdao2 = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao2.produccion = int.Parse(label9.Text);
                dataGridView1.DataSource = telasdao2.telascorteproduccion();
            }
            catch
            {
                MessageBox.Show("Error en la informacion");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = Convert.ToString(double.Parse(textBox3.Text) - double.Parse(textBox6.Text));
            }
            catch
            {
            }
        }
    }
}
