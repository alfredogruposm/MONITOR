using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Seleccionar_Orden : Form
    {
        public Seleccionar_Orden()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Bodega.Hoja_Corte hojacortegui = new Hoja_Corte();
                hojacortegui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                hojacortegui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Asunto"].Value);
                hojacortegui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Cliente"].Value);
                hojacortegui.textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Modelo"].Value);
                hojacortegui.richTextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["observaciones"].Value);
                hojacortegui.idficha = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idficha"].Value);
                hojacortegui.idproduccion = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                hojacortegui.ShowDialog();
                DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                dataGridView1.DataSource = producciondao.vistaparacorte();
            }
            catch
            {
                MessageBox.Show("Es necesario escojer una produccion primero");
            }
            

        }

        private void Seleccionar_Orden_Load(object sender, EventArgs e)
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            dataGridView1.DataSource = producciondao.vistaparacorte();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "Asunto";
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                DataView dv;
                DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                dv = new DataView(producciondao.vistaparacorte());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            catch
            {

            }
        }
    }
}
