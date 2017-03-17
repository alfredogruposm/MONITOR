using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class Seleccionar_ClienteOrden : Form
    {
        GUI.Recepcion.Orden_Produccion guiordenproduccion;
        public Seleccionar_ClienteOrden(GUI.Recepcion.Orden_Produccion fr1)
        {
            InitializeComponent();

            guiordenproduccion = new Orden_Produccion();
            guiordenproduccion = fr1;
        }

        private void Seleccionar_ClienteOrden_Load(object sender, EventArgs e)
        {
            DAO.ClientesDAO clientesdao = new GrupoSM_Recepcion.DAO.ClientesDAO();

            dataGridView1.DataSource = clientesdao.devuelveclientes();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            guiordenproduccion.textBox11.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
            guiordenproduccion.label7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idclientes"].Value);
            guiordenproduccion.groupBox3.Visible = true;
            guiordenproduccion.groupBox3.Enabled = true;
            guiordenproduccion.textBox11.Enabled = false;
            
            this.Visible = false;
            this.Close();
        }
    }
}
