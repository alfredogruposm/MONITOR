using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Telas_Entrada : Form
    {
        public Telas_Entrada()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Bodega.Telas_Captura telasgui = new Telas_Captura();
                telasgui.lbl_consumocombinacion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_conbinacion"].Value);
                telasgui.lbl_consumoforro.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_forro"].Value);
                telasgui.tb_forro.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["forro"].Value);
                telasgui.lbl_idorden.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_orden"].Value);
                telasgui.tb_tela.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tela"].Value);
                telasgui.tb_combinacion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["combinacion"].Value);
                telasgui.lbl_cliente.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_cliente"].Value);
                telasgui.ShowDialog();
                DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();

                dataGridView1.DataSource = ordendao.ordenesvistatelas();
            }
            catch
            {
            }
        }

        private void Telas_Entrada_Load(object sender, EventArgs e)
        {
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();

            dataGridView1.DataSource = ordendao.ordenesvistatelas();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "asunto";
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                DataView dv;
                DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                dv = new DataView(ordendao.ordenesvistatelas());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            catch
            {

            }
        }
    }
}
