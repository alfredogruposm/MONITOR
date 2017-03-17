using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class AviosControl : Form
    {
        public AviosControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (comboBox1.SelectedIndex != -1))
            {
                if (label4.Text == "label4")
                {
                    DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                    aviosdao.nombre = textBox1.Text;
                    aviosdao.precio = double.Parse(textBox2.Text);
                    if (checkBox1.Checked == true)
                    {
                        aviosdao.tipo = comboBox1.SelectedIndex + 14;
                    }
                    else
                    {
                        aviosdao.tipo = comboBox1.SelectedIndex;
                    }
                    
                    MessageBox.Show(aviosdao.agregar_avios());
                    label4.Text = Convert.ToString(aviosdao.numeros_avios());
                    aviosdao.idavios = int.Parse(label4.Text);
                    aviosdao.cantidad = double.Parse(textBox3.Text);
                    aviosdao.insertabodega();
                    this.Visible = false;
                    this.Close();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Considere que si esta cambiando el nombre del avio esto debe de ser solamente por error de escritura, si desea cambiarlo por otro es imperativo que se agregue uno nuevo", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    if (result == DialogResult.OK)
                    {

                        DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                        aviosdao.nombre = textBox1.Text;
                        aviosdao.idavios = int.Parse(label4.Text);
                        aviosdao.precio = double.Parse(textBox2.Text);
                        if (checkBox1.Checked == true)
                        {
                            aviosdao.tipo = comboBox1.SelectedIndex + 14;
                        }
                        else
                        {
                            aviosdao.tipo = comboBox1.SelectedIndex;
                        }
                        MessageBox.Show(aviosdao.actualizaavios());
                        aviosdao.cantidad = double.Parse(textBox3.Text);
                        aviosdao.idaviosbodega = int.Parse(label6.Text);
                        aviosdao.actualizabodegaavios();
                        this.Visible = false;
                        this.Close();
                    }
                    else
                    {
                    }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
        }
    }
}
