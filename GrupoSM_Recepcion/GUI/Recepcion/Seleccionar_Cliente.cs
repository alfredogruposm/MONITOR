using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class Seleccionar_Cliente : Form
    {
        GUI.Recepcion.SolicitudControl guisolicitudcontrol;
        public Seleccionar_Cliente(GUI.Recepcion.SolicitudControl fr1)
        {
            InitializeComponent();

            guisolicitudcontrol = new SolicitudControl();
            guisolicitudcontrol = fr1;
        }

        private void Seleccionar_Cliente_Load(object sender, EventArgs e)
        {
            DAO.ClientesDAO clientesdao = new GrupoSM_Recepcion.DAO.ClientesDAO();

            dataGridView1.DataSource = clientesdao.devuelveclientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            guisolicitudcontrol.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idclientes"].Value);
            this.Visible = false;
            this.Close();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
