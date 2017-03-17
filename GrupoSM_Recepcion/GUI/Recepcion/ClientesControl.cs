using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class ClientesControl : Form
    {
        GUI.Recepcion.Clientes guiclientescontrol;
        public ClientesControl(GUI.Recepcion.Clientes fr1)
        {
            InitializeComponent();
            guiclientescontrol = new GUI.Recepcion.Clientes();
            guiclientescontrol = fr1;
        }
        
        
        
        
        
        
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                try
                {
                    DAO.ClientesDAO clientesdao = new GrupoSM_Recepcion.DAO.ClientesDAO();
                    clientesdao.nombre = textBox1.Text;
                    clientesdao.costo_minuto = double.Parse(textBox2.Text);
                    clientesdao.costometro = double.Parse(textBox4.Text);
                    MessageBox.Show(clientesdao.insertacliente());
                    this.Visible = false;
                    this.Close();
                    guiclientescontrol.dataGridView1.DataSource = clientesdao.devuelveclientes();
                }
                catch
                {
                    MessageBox.Show("Error, algo a fallado");
                }
            }
            else
            {
                DAO.ClientesDAO clientesdao = new GrupoSM_Recepcion.DAO.ClientesDAO();
                clientesdao.idclientes = int.Parse(textBox3.Text);
                clientesdao.nombre = textBox1.Text;
                clientesdao.costo_minuto = double.Parse(textBox2.Text);
                clientesdao.costometro = double.Parse(textBox4.Text);
                MessageBox.Show(clientesdao.actualizaclientes());
                this.Visible = false;
                this.Close();
                guiclientescontrol.dataGridView1.DataSource = clientesdao.devuelveclientes();
            }
            
        }

        private void ClientesControl_Load(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Visible = false;
            }
            else
            {
                textBox3.Visible = true;
                button1.Text = "Modificar";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }
    }
}
