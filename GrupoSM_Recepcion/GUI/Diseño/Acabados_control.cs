using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Acabados_control : Form
    {
        
        public Acabados_control()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (comboBox1.SelectedIndex != -1))
            {
                if (textBox3.Text == "")
                {
                    DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                    acabadosdao.nombre = textBox1.Text;
                    acabadosdao.tipo = comboBox1.SelectedIndex;
                    acabadosdao.tiempo = double.Parse(textBox2.Text);
                    MessageBox.Show(acabadosdao.insertaproceso());
                    this.Visible = false;
                    this.Close();
                    
                }
                else
                {
                    DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                    acabadosdao.idacabados = int.Parse(textBox3.Text);
                    acabadosdao.nombre = textBox1.Text;
                    acabadosdao.tipo = comboBox1.SelectedIndex;
                    acabadosdao.tiempo = double.Parse(textBox2.Text);
                    MessageBox.Show(acabadosdao.actualizaproceso());
                    this.Visible = false;
                    this.Close();
                    

                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese todos los datos");
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Acabados_control_Load(object sender, EventArgs e)
        {

        }
    }
}
