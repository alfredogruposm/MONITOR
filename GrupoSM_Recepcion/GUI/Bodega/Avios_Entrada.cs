using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Avios_Entrada : Form
    {
        public Avios_Entrada()
        {
            InitializeComponent();
        }

        private void Avios_Entrada_Load(object sender, EventArgs e)
        {
            DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            dataGridView1.DataSource = producciondao.ordenesvistaavios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            ordendao.idorden = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_orden"].Value);
            GUI.Bodega.Avios_Asignacion aviosgui = new Avios_Asignacion();
            aviosgui.label2.Text = Convert.ToString(ordendao.devuelve_numeroprendas());
            aviosgui.label6.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells["id_orden"].Value));
            aviosgui.label7.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells["idficha"].Value));
            aviosgui.ShowDialog();
            DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            dataGridView1.DataSource = producciondao.ordenesvistaavios();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "asunto";
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                DataView dv;
                DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                
                dv = new DataView(producciondao.ordenesvistaavios());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            catch
            {

            }
        }
    }
}
