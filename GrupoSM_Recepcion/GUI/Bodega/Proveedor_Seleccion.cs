using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Proveedor_Seleccion : Form
    {
        GUI.Bodega.TelasControl telasgui;
        public Proveedor_Seleccion(GUI.Bodega.TelasControl fr1)
        {
            InitializeComponent();
            telasgui = new TelasControl();
            telasgui = fr1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            telasgui.label11.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idproveedor"].Value);
            telasgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
            this.Visible = false;
            this.Close();
        }

        private void Proveedor_Seleccion_Load(object sender, EventArgs e)
        {
            DAO.ProveedoresDAO proveedoresdao = new GrupoSM_Recepcion.DAO.ProveedoresDAO();
            dataGridView1.DataSource = proveedoresdao.proveedorestabla();
        }
    }
}
