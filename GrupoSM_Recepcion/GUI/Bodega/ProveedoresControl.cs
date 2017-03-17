using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class ProveedoresControl : Form
    {
        public ProveedoresControl()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label2.Text == "label2")
            {
                DAO.ProveedoresDAO proveedoresdao = new GrupoSM_Recepcion.DAO.ProveedoresDAO();
                proveedoresdao.nombre = textBox1.Text;
                MessageBox.Show(proveedoresdao.insertaproveedor());
                this.Visible = false;
                this.Close();
            }
            else
            {
                DAO.ProveedoresDAO proveedoresdao = new GrupoSM_Recepcion.DAO.ProveedoresDAO();
                proveedoresdao.nombre = textBox1.Text;
                proveedoresdao.idproveedor = int.Parse(label2.Text);
                MessageBox.Show(proveedoresdao.actualizaproveedor());
                this.Visible = false;
                this.Close();
            }
        }
    }
}
