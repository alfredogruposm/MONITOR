using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Fichas_tecnicas : Form
    {
        public Fichas_tecnicas()
        {
            InitializeComponent();
        }

        private void Fichas_tecnicas_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            DAO.Ficha_tecnicaDAO fichadao=new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
            dataGridView1.DataSource = fichadao.fichas_tecnicas2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GUI.Diseño.Fichas_tecnicas_control fichacontrolgui = new Fichas_tecnicas_control();
            fichacontrolgui.ShowDialog();
            DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
            dataGridView1.DataSource = fichadao.fichas_tecnicas2();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Text == "Ver Especificaciones")
            {
                GUI.Diseño.Fichas_tecnicas_control fichacontrolgui = new Fichas_tecnicas_control();
                fichacontrolgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha_tecnica"].Value);
                fichacontrolgui.tb_prenda.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre_prenda"].Value);
                fichacontrolgui.tb_molde.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["modelo"].Value);
                fichacontrolgui.tb_tela.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tela"].Value);
                fichacontrolgui.tb_telaancho.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ancho_tela"].Value);
                fichacontrolgui.tb_telaconsumo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_tela"].Value);
                fichacontrolgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                fichacontrolgui.label23.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idclientes"].Value);
                fichacontrolgui.label22.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["costo_minuto"].Value);
                fichacontrolgui.tb_combinacion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["combinacion"].Value);
                fichacontrolgui.button1.Visible = false;
                fichacontrolgui.button10.Visible = false;
                fichacontrolgui.button11.Visible = false;
                fichacontrolgui.button12.Visible = false;
                fichacontrolgui.button13.Visible = false;
                fichacontrolgui.button14.Visible = false;
                fichacontrolgui.button2.Visible = false;
                fichacontrolgui.button3.Visible = false;
                fichacontrolgui.button4.Visible = false;
                fichacontrolgui.button5.Visible = false;
                fichacontrolgui.button6.Visible = false;
                fichacontrolgui.button7.Visible = false;
                fichacontrolgui.button5.Enabled = false;
                fichacontrolgui.button9.Visible = false;

                fichacontrolgui.tb_combinacionancho.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ancho_tela_conbinacion"].Value);
                fichacontrolgui.tb_combinacionconsumo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_conbinacion"].Value);
                fichacontrolgui.tb_forro.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["forro"].Value);
                fichacontrolgui.tb_forroancho.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ancho_tela_forro"].Value);
                fichacontrolgui.tb_forroconsumo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_forro"].Value);
                fichacontrolgui.rtb_observaciones.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["especificacionescostura"].Value);
                fichacontrolgui.groupBox2.Visible = true;
                fichacontrolgui.Text = "Modificar";
                fichacontrolgui.ShowDialog();
                DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                dataGridView1.DataSource = fichadao.fichas_tecnicas2();
            }
            else
            {
                GUI.Diseño.Fichas_tecnicas_control fichacontrolgui = new Fichas_tecnicas_control();
                fichacontrolgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha_tecnica"].Value);
                fichacontrolgui.tb_prenda.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre_prenda"].Value);
                fichacontrolgui.tb_molde.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["modelo"].Value);
                fichacontrolgui.tb_tela.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["tela"].Value);
                fichacontrolgui.tb_telaancho.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ancho_tela"].Value);
                fichacontrolgui.tb_telaconsumo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_tela"].Value);
                fichacontrolgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                fichacontrolgui.label23.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idclientes"].Value);
                fichacontrolgui.label22.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["costo_minuto"].Value);
                fichacontrolgui.tb_combinacion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["combinacion"].Value);

                fichacontrolgui.tb_combinacionancho.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ancho_tela_conbinacion"].Value);
                fichacontrolgui.tb_combinacionconsumo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_conbinacion"].Value);
                fichacontrolgui.tb_forro.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["forro"].Value);
                fichacontrolgui.tb_forroancho.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ancho_tela_forro"].Value);
                fichacontrolgui.tb_forroconsumo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["consumo_forro"].Value);
                fichacontrolgui.rtb_observaciones.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["especificacionescostura"].Value);
                fichacontrolgui.groupBox2.Visible = true;
                fichacontrolgui.Text = "Modificar";
                fichacontrolgui.ShowDialog();
                DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                dataGridView1.DataSource = fichadao.fichas_tecnicas2();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
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
            DataView dv = new DataView(fichadao.fichas_tecnicas2());
            dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";

            dataGridView1.DataSource = dv;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.REPORTES.FichaTecnicaPagina1 pagina1gui = new GrupoSM_Recepcion.GUI.REPORTES.FichaTecnicaPagina1();
                pagina1gui.idficha = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idficha_tecnica"].Value);
                pagina1gui.Show();
            }
            catch
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.REPORTES.FichaTecnicaPagina2 pagina2gui = new GrupoSM_Recepcion.GUI.REPORTES.FichaTecnicaPagina2();
                pagina2gui.idficha = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idficha_tecnica"].Value);
                pagina2gui.Show();
            }
            catch
            {
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Plantillas plantillasgui = new Plantillas();
            plantillasgui.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DAO.Ficha_tecnicaDAO fichasdao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                fichasdao.id_fichatecnica = int.Parse(row.Cells["idficha_tecnica"].Value.ToString());
                fichasdao.especificaciones = "";
                fichasdao.ingresaespecificacionesficha();
            }
            MessageBox.Show("Correcto");
        }
    }
}
