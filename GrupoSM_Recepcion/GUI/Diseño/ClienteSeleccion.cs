using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class ClienteSeleccion : Form
    {
        GUI.Diseño.Fichas_tecnicas_control fichasgui;
        public ClienteSeleccion(GUI.Diseño.Fichas_tecnicas_control fr1)
        {
            fichasgui = new Fichas_tecnicas_control();
            fichasgui = fr1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fichasgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
            fichasgui.label22.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["costo_minuto"].Value);
            fichasgui.label23.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idclientes"].Value);
            this.Visible = false;
            this.Close();
        }

        private void ClienteSeleccion_Load(object sender, EventArgs e)
        {
            DAO.ClientesDAO clientesdao = new GrupoSM_Recepcion.DAO.ClientesDAO();
            dataGridView1.DataSource = clientesdao.devuelveclientes();
        }
    }
}
