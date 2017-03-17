using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Prendas_corte : Form
    {
        public Prendas_corte()
        {
            InitializeComponent();
        }

        private void Prendas_corte_Load(object sender, EventArgs e)
        {
            DAO.Oden_ProduccionDAO producciondao=new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            dataGridView1.DataSource = producciondao.tablaprendascortes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                producciondao.idorden = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                producciondao.fecha_trazado_terminado = dateTimePicker1.Value;
                MessageBox.Show(producciondao.actualizaacroteproduccion());
            }
            catch
            {
                MessageBox.Show("Por favor escoja un proyecto");
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Fichas_tecnicas_control fichagui = new Fichas_tecnicas_control();
                fichagui.Text = "Ficha Tecnica";
                fichagui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha"].Value);
                fichagui.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Diseño.Corte_Vista hojacortegui = new Corte_Vista();
                hojacortegui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                hojacortegui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Asunto"].Value);
                hojacortegui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Cliente"].Value);
                hojacortegui.textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Modelo"].Value);
                hojacortegui.richTextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Notas"].Value);
                hojacortegui.idficha = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idficha"].Value);
                hojacortegui.idproduccion = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                hojacortegui.ShowDialog();
                
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Diseño.Ver_observaciones observacionesgui = new Ver_observaciones();
                observacionesgui.label1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                observacionesgui.richTextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Observaciones/Notas Produccion"].Value);
                observacionesgui.ShowDialog();
                DAO.Oden_ProduccionDAO producciondao2 = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                dataGridView1.DataSource = producciondao2.tablaprendascortes();
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            GUI.Diseño.Telas_corte telasgui = new Telas_corte();
            telasgui.label9.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
            telasgui.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dataGridView1.CurrentRow.Cells["Corte Inicia"].Value.ToString() != "") && (dataGridView1.CurrentRow.Cells[3].Value.ToString() != ""))
                {

                    DialogResult result = MessageBox.Show("¿Desea pasar esta prenda a la etapa de Separado?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                        producciondao.fecha_corte_terminado = dateTimePicker1.Value;
                        producciondao.idorden = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                        string resultado = producciondao.actualiza_corte();
                        if (resultado != "Correcto")
                        {
                            MessageBox.Show(resultado);
                        }
                        DAO.Oden_ProduccionDAO producciondao2 = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                        dataGridView1.DataSource = producciondao2.tablaprendascortes();

                    }
                }
                else
                {
                    MessageBox.Show("Es necesario terminar trazado y tendido para pasar a corte");
                }
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }

            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Convert.ToString(dataGridView1.CurrentRow.Cells["Corte Inicia"].Value);
                if (ruta == "")
                {
                    DialogResult result = MessageBox.Show("¿Desea terminar en esta prenda la etapa de tendido?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                        producciondao.idorden = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                        producciondao.fecha_tendido = dateTimePicker1.Value;
                        MessageBox.Show(producciondao.actualizatendidoproduccion());
                        DAO.Oden_ProduccionDAO producciondao2 = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                        dataGridView1.DataSource = producciondao2.tablaprendascortes();
                    }
                }
                else
                {
                    MessageBox.Show("Ya a terminado esta etapa");
                }
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "Asunto";
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                DataView dv;
                DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                
                dv = new DataView(producciondao.tablaprendascortes());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            catch
            {

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GUI.Bodega.AsignacionEmpleadosCostura hojacortegui = new GrupoSM_Recepcion.GUI.Bodega.AsignacionEmpleadosCostura();
            hojacortegui.lblficha.Text= Convert.ToString(dataGridView1.CurrentRow.Cells["idficha"].Value);
            hojacortegui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
            hojacortegui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Asunto"].Value);
            hojacortegui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Modelo"].Value);
            hojacortegui.Show();
        }
    }
}
