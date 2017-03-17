using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Ordenes : Form
    {
        public Ordenes()
        {
            InitializeComponent();
        }

        private void Ordenes_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }
        public void actualizagrid()
        {
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();

            dataGridView1.DataSource = ordendao.ordenesvistacorta();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            GUI.Bodega.Avios_captura avioscapturagui = new Avios_captura();
            aviosdao.id_ficha_avio = (Convert.ToInt16(dataGridView1.CurrentRow.Cells["idficha"].Value));
            avioscapturagui.label7.Text = dataGridView1.CurrentRow.Cells["idficha"].Value.ToString();
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            ordendao.idorden = (Convert.ToInt16(dataGridView1.CurrentRow.Cells["id_orden"].Value));
            avioscapturagui.textBox2.Text = Convert.ToString(ordendao.devuelve_numeroprendas());
            avioscapturagui.label5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_orden"].Value);
            
            avioscapturagui.dataGridView1.DataSource = aviosdao.sacar_avios();
            

            avioscapturagui.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Telas_orden telasgui = new Telas_orden();
            telasgui.lbl_consumocombinacion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_conbinacion"].Value);
            telasgui.lbl_consumoforro.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_forro"].Value);
            telasgui.tb_forro.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["forro"].Value);
            telasgui.lbl_idorden.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_orden"].Value);
            telasgui.tb_tela.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tela"].Value);
            telasgui.tb_combinacion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["combinacion"].Value);
            telasgui.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.REPORTES.AviosProduccionImprimir aviosimpr = new GrupoSM_Recepcion.GUI.REPORTES.AviosProduccionImprimir();
            aviosimpr.idproduccion = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_orden"].Value);
            aviosimpr.idficha = (Convert.ToInt16(dataGridView1.CurrentRow.Cells["idficha"].Value));
            aviosimpr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.REPORTES.TelasProduccionImprimir telasimpr = new GrupoSM_Recepcion.GUI.REPORTES.TelasProduccionImprimir();
            telasimpr.idproduccion = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_orden"].Value);
            telasimpr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI.REPORTES.Pruebatallas prueba = new GrupoSM_Recepcion.GUI.REPORTES.Pruebatallas();
            prueba.idproduccion = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_orden"].Value);
            prueba.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea cancelar la orden seleccionada? Tenga en cuenta que es imperativo que esten reiniciados o no asignados los avios y las telas, de lo contrario no se actualizara el inventario.", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    ordendao.idorden = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string resultado=ordendao.eliminaproduccion();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    actualizagrid();
                }
            }
            catch
            {

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "asunto";
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                DataView dv;
                DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                dv = new DataView(ordendao.ordenesvistacorta());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            catch
            {

            }
        }
    }
}
