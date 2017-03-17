using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Ver_observaciones : Form
    {
        public Ver_observaciones()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = int.Parse(label1.Text);
            producciondao.observaciones_diseño = richTextBox1.Text;
            MessageBox.Show(producciondao.actualizaobservaciones());
            this.Hide();
            this.Close();
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Visible = true;
        }
    }
}
