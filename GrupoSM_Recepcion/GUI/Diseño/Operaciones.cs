using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Operaciones : Form
    {
        public Operaciones()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Operaciones_control operacionesgui = new Operaciones_control();
            operacionesgui.ShowDialog();
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            dataGridView1.DataSource = procesosdao.devuelveprocesos();
        }

        private void Operaciones_Load(object sender, EventArgs e)
        {
            DAO.ProcesosDAO procesosdao=new GrupoSM_Recepcion.DAO.ProcesosDAO();
            dataGridView1.DataSource = procesosdao.devuelveprocesos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                GUI.Diseño.Operaciones_control operacionesgui = new Operaciones_control();
                operacionesgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["operacion"].Value);

                operacionesgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tiempo"].Value);

                operacionesgui.comboBox1.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells["tipo"].Value);
                operacionesgui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_procesos"].Value);
                operacionesgui.ShowDialog();
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                dataGridView1.DataSource = procesosdao.devuelveprocesos();
            }
            catch
            {
                MessageBox.Show("escoja una operacion");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao.tipo = comboBox1.SelectedIndex;
                dataGridView1.DataSource = procesosdao.busca_procesosportipo();
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
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao.idproceso = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_procesos"].Value);
                procesosdao.borraproceso();
                dataGridView1.DataSource = procesosdao.devuelveprocesos();
            }
            catch
            {
                MessageBox.Show("No se elimino, es probable que se este utilizando en una ficha tecnica");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
