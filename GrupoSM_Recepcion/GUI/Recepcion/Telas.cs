using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class Telas : Form
    {
        public Telas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Recepcion.TelasControl telasgui = new TelasControl();
                telasgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                telasgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["precio"].Value);
                telasgui.label3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idtelas"].Value);
                telasgui.Text = "Modificar";
                telasgui.ShowDialog();
                DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                dataGridView1.DataSource = telasdao.tablatelascosteo();
            }
            catch
            {
                MessageBox.Show("Elija una tela para modificar");
            }

        }

        private void Telas_Load(object sender, EventArgs e)
        {
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            dataGridView1.DataSource = telasdao.tablatelascosteo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                string s = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                telasdao.idtelacosteo = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idtelas"].Value);
                DialogResult result = MessageBox.Show("¿Desea eliminar la tela "+s+"?",
                        "Mensaje",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    telasdao.eliminatelascosteo();
                    DAO.TelasDAO telasdao1 = new GrupoSM_Recepcion.DAO.TelasDAO();
                    dataGridView1.DataSource = telasdao1.tablatelascosteo();
                }
            }
            catch
            {
                MessageBox.Show("Elija una tela para eliminar");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.TelasControl telasgui = new TelasControl();
            telasgui.ShowDialog();
            DAO.TelasDAO telasdao1 = new GrupoSM_Recepcion.DAO.TelasDAO();
            dataGridView1.DataSource = telasdao1.tablatelascosteo();
        }
    }
}
