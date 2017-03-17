using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Prendas_separado : Form
    {
        public Prendas_separado()
        {
            InitializeComponent();
        }

        private void Prendas_separado_Load(object sender, EventArgs e)
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            dataGridView1.DataSource = producciondao.prendas_separado();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Diseño.Separado_Vista hojacortegui = new Separado_Vista();
                hojacortegui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                hojacortegui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Asunto"].Value);
                hojacortegui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Cliente"].Value);
                hojacortegui.textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Modelo"].Value);
                DAO.PiezasDAO fichadao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                fichadao.idficha = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idficha"].Value);
                hojacortegui.dataGridView2.DataSource = fichadao.devuelvepiezasfichas();
                hojacortegui.ShowDialog();

            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Fichas_tecnicas_control fichagui = new Fichas_tecnicas_control();
                fichagui.Text = "Ficha Tecnica";
                fichagui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha"].Value);
                fichagui.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Diseño.Ver_observaciones observacionesgui = new Ver_observaciones();
                observacionesgui.label1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                observacionesgui.richTextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Observaciones/Notas Produccion"].Value);
                observacionesgui.ShowDialog();
                DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                dataGridView1.DataSource = producciondao.prendas_separado();
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show("¿Desea pasar esta prenda a la etapa de Maquila?",
                "Mensaje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                    producciondao.id_produccion = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                    MessageBox.Show(producciondao.prendas_maquila());
                    DAO.ProduccionDAO producciondao1 = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                    dataGridView1.DataSource = producciondao1.prendas_separado();

                }
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }

          
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "Asunto";
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                DataView dv;
                DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                dataGridView1.DataSource = producciondao.prendas_separado();
                dv = new DataView(producciondao.prendas_separado());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            catch
            {

            }
        }
    }
}
