using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class Costeo : Form
    {
        public Costeo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void Costeo_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            if (this.Text == "Costeo Solicitudes")
            {
                DAO.SolicitudesDAO solicitudesdao = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
                dataGridView1.DataSource = solicitudesdao.contestadas();
            }
            else
            {
                DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                dataGridView1.DataSource = fichadao.fichas_tecnicas();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Text == "Costeo Solicitudes")
            {

                try
                {

                    GUI.Recepcion.CosteoControl costeocontrolgui = new CosteoControl();
                    costeocontrolgui.tb_solicitud.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_solicitud"].Value);
                    costeocontrolgui.tb_costominuto.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["costo_minuto"].Value);
                    costeocontrolgui.tb_tiempoacabados.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tiempo_acabados"].Value);
                    costeocontrolgui.tb_tiempocostura.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tiempo_costura"].Value);

                    costeocontrolgui.tb_id_ficha.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha_tecnica"].Value);
                    //costeocontrolgui.tb_costometro.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["costo_metro"].Value);
                    costeocontrolgui.tb_consumotela.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_tela"].Value);

                    costeocontrolgui.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Escoja por favor una solicitud");
                }
            }
            else
            {
                try
                {

                    GUI.Recepcion.CosteoControl costeocontrolgui = new CosteoControl();
                    costeocontrolgui.tb_solicitud.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre_prenda"].Value);
                    
                    costeocontrolgui.label1.Text = "Prenda";
                    costeocontrolgui.tb_costominuto.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["costo_minuto"].Value);
                    costeocontrolgui.tb_tiempoacabados.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tiempo_acabados"].Value);
                    costeocontrolgui.tb_tiempocostura.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tiempo_costura"].Value);
                    
                    
                    
                    costeocontrolgui.textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tela"].Value);
                    costeocontrolgui.textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["combinacion"].Value);
                    costeocontrolgui.textBox9.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["forro"].Value);
                    costeocontrolgui.textBox10.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_conbinacion"].Value);
                    costeocontrolgui.textBox8.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_forro"].Value);





                    costeocontrolgui.tb_id_ficha.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha_tecnica"].Value);
                    //costeocontrolgui.tb_costometro.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["costo_metro"].Value);
                    costeocontrolgui.tb_consumotela.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_tela"].Value);

                    costeocontrolgui.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Escoja por favor una ficha");
                }
            }




        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // dataView.RowFilter = "Name LIKE 'j*'"       // values that start with 'j'
            //dataView.RowFilter = "Name LIKE '%jo%'"     // values that contain 'jo'

            //dataView.RowFilter = "Name NOT LIKE 'j*'"   // values that don't start with 'j'

            if (this.Text == "Costeo Solicitudes")
            {
                //DAO.SolicitudesDAO solicitudesdao = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
                //DataView dv = new DataView(solicitudesdao.contestadas());
                //dv.RowFilter = "modelo like '%" + textBox5.Text + "%'";

                //dataGridView1.DataSource = dv;
            }
            else
            {
                string campo;
                if (comboBox1.SelectedIndex == 0)
                {
                    campo = "nombre_prenda";
                }
                else
                {
                    campo = "modelo";
                }
                DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                DataView dv = new DataView(fichadao.fichas_tecnicas());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";

                dataGridView1.DataSource = dv;
            }
            
            
            
        }
    }
}
