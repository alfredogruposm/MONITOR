using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Bodega.ProveedoresControl proveedoresgui = new ProveedoresControl();
            proveedoresgui.ShowDialog();
            DAO.ProveedoresDAO proveedoresdao = new GrupoSM_Recepcion.DAO.ProveedoresDAO();
            dataGridView1.DataSource = proveedoresdao.proveedorestabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Bodega.ProveedoresControl proveedoresgui = new ProveedoresControl();
            proveedoresgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
            proveedoresgui.label2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idproveedor"].Value);
            proveedoresgui.ShowDialog();
            DAO.ProveedoresDAO proveedoresdao = new GrupoSM_Recepcion.DAO.ProveedoresDAO();
            dataGridView1.DataSource = proveedoresdao.proveedorestabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            DAO.ProveedoresDAO proveedoresdao = new GrupoSM_Recepcion.DAO.ProveedoresDAO();
            dataGridView1.DataSource = proveedoresdao.proveedorestabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show("¿Desea eliminar el proveedor seleccionado?",
                        "Mensaje",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DAO.ProveedoresDAO proveedoresdao=new GrupoSM_Recepcion.DAO.ProveedoresDAO();
                    proveedoresdao.idproveedor=Convert.ToInt16(dataGridView1.CurrentRow.Cells["idproveedor"].Value);
                    MessageBox.Show(proveedoresdao.borra_proveedor());
                    DAO.ProveedoresDAO proveedoresdao1 = new GrupoSM_Recepcion.DAO.ProveedoresDAO();
                    dataGridView1.DataSource = proveedoresdao1.proveedorestabla();
                }
            }
            catch
            {
                MessageBox.Show("Elija un proveedor para eliminar");
            }
        }
    }
}
