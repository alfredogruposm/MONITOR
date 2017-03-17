using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Seleccion_Entregas : Form
    {
        public Seleccion_Entregas()
        {
            InitializeComponent();
        }

        private void Seleccion_Entregas_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = llenatabla();
        }

        private DataTable llenatabla()
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            return producciondao.vista_entregas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Esta seguro que desea terminar este proyecto y la prenda a sido entregada?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Stop);
                if (result == DialogResult.Yes)
                {
                    DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                    producciondao.id_produccion = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                    MessageBox.Show(producciondao.termina_entrega());
                    dataGridView1.DataSource = llenatabla();
                }
            }
            catch
            {
                MessageBox.Show("Escoja un proyecto primero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value) != "")
                {
                    DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                    producciondao.id_produccion = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                    MessageBox.Show(producciondao.termina_calidad());
                    dataGridView1.DataSource = llenatabla();
                }
                else
                {
                    MessageBox.Show("Ya a terminado esta parte del proceso");
                }
            }
            catch
            {
                MessageBox.Show("Escoja un proyecto");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "asunto";
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                DataView dv;
                DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                dv = new DataView(producciondao.vista_entregas());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            catch
            {

            }
        }
    }
}
