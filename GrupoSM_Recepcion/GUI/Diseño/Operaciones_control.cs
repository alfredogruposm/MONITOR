using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Operaciones_control : Form
    {
        
        public Operaciones_control()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (comboBox1.SelectedIndex != -1))
            {
                if (textBox3.Text == "")
                {
                    DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                    procesosdao.nombre = textBox1.Text;
                    procesosdao.tipo = comboBox1.SelectedIndex;
                    procesosdao.tiempo = double.Parse(textBox2.Text);
                    MessageBox.Show(procesosdao.insertaproceso());
                    this.Visible = false;
                    this.Close();
                    
                }
                else
                {
                    DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                    procesosdao.idproceso = int.Parse(textBox3.Text);
                    procesosdao.nombre = textBox1.Text;
                    procesosdao.tipo = comboBox1.SelectedIndex;
                    procesosdao.tiempo = double.Parse(textBox2.Text);
                    MessageBox.Show(procesosdao.actualizaproceso());
                    this.Visible = false;
                    this.Close();
                    

                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese todos los datos");
            }
        }

        private void Operaciones_control_Load(object sender, EventArgs e)
        {

        }
    }
}
