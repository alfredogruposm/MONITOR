using System;
using System.Windows.Forms;
using GrupoSM_Recepcion.DAO;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class Clientes : Form
    {
        

        

        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            DAO.ClientesDAO clientesdao = new ClientesDAO();
            dataGridView1.DataSource = clientesdao.devuelveclientes();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.ClientesControl guiclientescontrol = new GUI.Recepcion.ClientesControl(this);
            guiclientescontrol.ShowDialog();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                GUI.Recepcion.ClientesControl guiclientescontrol = new GUI.Recepcion.ClientesControl(this);
                guiclientescontrol.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idclientes"].Value);
                guiclientescontrol.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                guiclientescontrol.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["costo_minuto"].Value);
                guiclientescontrol.textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["costo_metro"].Value);
                guiclientescontrol.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Seleccione un cliente de la lista");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                DialogResult result = MessageBox.Show("¿Desea eliminar el cliente seleccionado?",
                        "Mensaje",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DAO.ClientesDAO clientesdao = new ClientesDAO();
                    clientesdao.idclientes = Convert.ToInt16(dataGridView1.CurrentRow.Cells["idclientes"].Value);
                    MessageBox.Show(clientesdao.borracliente());
                    DAO.ClientesDAO clientesdao2 = new ClientesDAO();
                    dataGridView1.DataSource = clientesdao2.devuelveclientes();
                }
            }
            catch
            {
                MessageBox.Show("Elija un cliente para eliminar");
            }
            
        }
    }
}
