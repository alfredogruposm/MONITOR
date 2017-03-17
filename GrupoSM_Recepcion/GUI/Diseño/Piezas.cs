using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Piezas : Form
    {
        public Piezas()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Piezas_control piezasgui = new Piezas_control();
            piezasgui.ShowDialog();
            DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
            dataGridView1.DataSource = piezasdao.devuelvepiezas();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Piezas_control piezasgui = new Piezas_control();
            piezasgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_piezas"].Value);
            piezasgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
            piezasgui.comboBox1.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells["tipo"].Value);
            piezasgui.ShowDialog();
            DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
            dataGridView1.DataSource = piezasdao.devuelvepiezas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();

        }

        private void Piezas_Load(object sender, EventArgs e)
        {
            DAO.PiezasDAO piezasdao=new GrupoSM_Recepcion.DAO.PiezasDAO();
            dataGridView1.DataSource = piezasdao.devuelvepiezas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                piezasdao.tipo = comboBox1.SelectedIndex;
                dataGridView1.DataSource = piezasdao.busca_piezasportipo();
            }
            catch
            {
                MessageBox.Show("Por favor, escoja una categoria");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                piezasdao.idpiezas = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_piezas"].Value);
                piezasdao.borrapieza();
                dataGridView1.DataSource = piezasdao.devuelvepiezas();
            }
            catch
            {
                MessageBox.Show("No se elimino, es probable que se este utilizando en una ficha tecnica");
            }
        }
    }
}
