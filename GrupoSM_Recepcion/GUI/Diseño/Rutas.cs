using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Rutas : Form
    {
        public Rutas()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                producciondao.rutas = textBox1.Text;
                producciondao.fecharutas = dateTimePicker1.Value;
                producciondao.id_produccion = int.Parse(label2.Text);
                MessageBox.Show(producciondao.actualizarutas());
                this.Hide();
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }
    }
}
