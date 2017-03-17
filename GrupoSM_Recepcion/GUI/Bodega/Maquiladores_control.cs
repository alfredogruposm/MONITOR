using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Maquiladores_control : Form
    {
        GUI.Bodega.Maquiladores guimaquiladorescontrol;
        public Maquiladores_control(GUI.Bodega.Maquiladores fr1)
        {
            InitializeComponent();
            guimaquiladorescontrol = new Maquiladores();
            guimaquiladorescontrol = fr1;
        }

        private void Maquiladores_control_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
                button1.Text = "Modificar";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                try
                {
                    DAO.MaquiladoresDAO maquiladoresdao=new GrupoSM_Recepcion.DAO.MaquiladoresDAO();
                    maquiladoresdao.nombre = textBox2.Text;
                    maquiladoresdao.costominuto = double.Parse(textBox3.Text);
                    MessageBox.Show(maquiladoresdao.insertamaquilador());
                    this.Visible = false;
                    this.Close();
                    guimaquiladorescontrol.dataGridView1.DataSource = maquiladoresdao.devuelvemaquiladores();
                }
                catch
                {
                    MessageBox.Show("Error, algo a fallado");
                }
            }
            else
            {
                DAO.MaquiladoresDAO maquiladoresdao = new GrupoSM_Recepcion.DAO.MaquiladoresDAO();
                maquiladoresdao.idmaquilador = int.Parse(textBox1.Text);
                maquiladoresdao.nombre = textBox2.Text;
                maquiladoresdao.costominuto = double.Parse(textBox3.Text);

                MessageBox.Show(maquiladoresdao.actualizamaquiladores());
                this.Visible = false;
                this.Close();
                guimaquiladorescontrol.dataGridView1.DataSource = maquiladoresdao.devuelvemaquiladores();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();

        }
    }
}
