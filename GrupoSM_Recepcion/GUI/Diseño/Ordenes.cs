using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Ordenes : Form
    {
        public Ordenes()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Telas_orden telasgui = new Telas_orden();
            telasgui.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
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
                DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                dataGridView1.DataSource = producciondao.prendas_entrazo();
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
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

        private void Ordenes_Load(object sender, EventArgs e)
        {
            DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            dataGridView1.DataSource = producciondao.prendas_entrazo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
            Rutas rutasgui = new Rutas();
            rutasgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Rutas"].Value);
            rutasgui.button1.Visible = false;
            rutasgui.label2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
            rutasgui.ShowDialog();
            DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            dataGridView1.DataSource = producciondao.prendas_entrazo();
            }
            catch
            {
                MessageBox.Show("Por favor escoja una opcion valida");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Diseño.Ver_observaciones observacionesgui = new Ver_observaciones();
                observacionesgui.label1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                observacionesgui.richTextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Observaciones/Notas Produccion"].Value);
                observacionesgui.ShowDialog();
                DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                dataGridView1.DataSource = producciondao.prendas_entrazo();
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
                string ruta = Convert.ToString(dataGridView1.CurrentRow.Cells["Rutas"].Value);
                if (ruta != "")
                {
                    DialogResult result = MessageBox.Show("¿Desea pasar esta prenda a la etapa de Trazado?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                        producciondao.idorden = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                        producciondao.fecha_trazado_terminado = dateTimePicker1.Value;
                        MessageBox.Show(producciondao.actualizaacroteproduccion());
                        DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                        ordendao.fecha_trazado_inicio = dateTimePicker1.Value;
                        ordendao.idorden = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                        ordendao.actualizatrazoproduccion();
                        DAO.Oden_ProduccionDAO producciondao2 = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                        dataGridView1.DataSource = producciondao2.prendas_entrazo();
                    }
                }
                else
                {
                    MessageBox.Show("No a ingresado las rutas para esta prenda");
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
                
                dv = new DataView(producciondao.prendas_entrazo());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            catch
            {

            }
        }
    }
}
