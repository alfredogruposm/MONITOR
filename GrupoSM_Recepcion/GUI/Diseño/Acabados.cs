using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Acabados : Form
    {
        public Acabados()
        {
            InitializeComponent();
        }

        private void Acabados_Load(object sender, EventArgs e)
        {
            DAO.AcabadosDAO acabadosdao=new GrupoSM_Recepcion.DAO.AcabadosDAO();
            dataGridView1.DataSource = acabadosdao.devuelveprocesos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Acabados_control acabadosgui = new Acabados_control();
            acabadosgui.ShowDialog();
            DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
            dataGridView1.DataSource = acabadosdao.devuelveprocesos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                GUI.Diseño.Acabados_control acabadosgui = new Acabados_control();

                acabadosgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["operacion"].Value);

                acabadosgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tiempo"].Value);

                acabadosgui.comboBox1.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells["tipo"].Value);
                acabadosgui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_acabados"].Value);
                acabadosgui.ShowDialog();
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                dataGridView1.DataSource = acabadosdao.devuelveprocesos();
            }
            catch
            {
                MessageBox.Show("Escoja un acabado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                acabadosdao.tipo = comboBox1.SelectedIndex;
                dataGridView1.DataSource = acabadosdao.busca_acabadosportipo();
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
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                acabadosdao.idacabados = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_acabados"].Value);
                acabadosdao.borraacabado();
                dataGridView1.DataSource = acabadosdao.devuelveprocesos();
            }
            catch
            {
                MessageBox.Show("No se elimino, es probable que se este utilizando en una ficha tecnica");
            }
        }
    }
}
