using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Piezas_control : Form
    {
       
        public Piezas_control()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (comboBox1.SelectedIndex != -1))
            {
                if (textBox2.Text == "")
                {
                    DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                    piezasdao.nombre = textBox1.Text;
                    piezasdao.tipo = comboBox1.SelectedIndex;
                    MessageBox.Show(piezasdao.insertapieza());
                    this.Visible = false;
                    this.Close();
                    
                }
                else
                {
                    DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                    piezasdao.nombre = textBox1.Text;
                    piezasdao.tipo = comboBox1.SelectedIndex;
                    piezasdao.idpiezas = int.Parse(textBox2.Text);
                    MessageBox.Show(piezasdao.actualizapiezas());
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
    }
}
