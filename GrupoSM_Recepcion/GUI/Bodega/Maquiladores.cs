using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Maquiladores : Form
    {
        public Maquiladores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Maquiladores_control maquiladoresgui = new Maquiladores_control(this);
            maquiladoresgui.ShowDialog();
        }

        private void Maquiladores_Load(object sender, EventArgs e)
        {
            DAO.MaquiladoresDAO maquiladoresdao = new GrupoSM_Recepcion.DAO.MaquiladoresDAO();
            dataGridView1.DataSource = maquiladoresdao.devuelvemaquiladores();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                GUI.Bodega.Maquiladores_control maquiladorescontrolgui = new Maquiladores_control(this);
                maquiladorescontrolgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idmaquiladores"].Value);
                maquiladorescontrolgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                maquiladorescontrolgui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["precio_minuto"].Value);
                maquiladorescontrolgui.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Seleccione un cliente de la lista");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show("¿Desea eliminar el maquilador seleccionado?",
                        "Mensaje",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DAO.MaquiladoresDAO maquiladoresdao = new GrupoSM_Recepcion.DAO.MaquiladoresDAO();
                    maquiladoresdao.idmaquilador = Convert.ToInt16(dataGridView1.CurrentRow.Cells["idmaquiladores"].Value);
                    MessageBox.Show(maquiladoresdao.borra_maquilador());
                    DAO.MaquiladoresDAO maquiladoresdao1 = new GrupoSM_Recepcion.DAO.MaquiladoresDAO();
                    dataGridView1.DataSource = maquiladoresdao1.devuelvemaquiladores();
                }
            }
            catch
            {
                MessageBox.Show("Elija un maquilador para eliminar");
            }
        }
    }
}
