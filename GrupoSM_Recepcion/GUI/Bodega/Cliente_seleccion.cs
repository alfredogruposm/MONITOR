using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Cliente_seleccion : Form
    {
        GUI.Bodega.TelasControl telasgui;
        public Cliente_seleccion(GUI.Bodega.TelasControl fr1)
        {
            InitializeComponent();
            telasgui = new TelasControl();
            telasgui = fr1;
        }

        private void Cliente_seleccion_Load(object sender, EventArgs e)
        {
            DAO.ClientesDAO clientesdao = new GrupoSM_Recepcion.DAO.ClientesDAO();

            dataGridView1.DataSource = clientesdao.devuelveclientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            telasgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
            telasgui.label10.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idclientes"].Value);
            this.Visible = false;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        

    }
}
