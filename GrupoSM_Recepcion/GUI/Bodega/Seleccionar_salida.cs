using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Seleccionar_salida : Form
    {
        public Seleccionar_salida()
        {
            InitializeComponent();
        }

        private void Seleccionar_salida_Load(object sender, EventArgs e)
        {
            DAO.SalidasMaquilaDAO saliasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
            dataGridView1.DataSource = saliasdao.vistamaquila();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                GUI.Bodega.Salida_maquila salidagui = new Salida_maquila();
                salidagui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                salidagui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Asunto"].Value);
                salidagui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Modelo"].Value);
                salidagui.lblficha.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha"].Value);
                string uno = Convert.ToString(dataGridView1.CurrentRow.Cells["Notas"].Value), dos = Convert.ToString(dataGridView1.CurrentRow.Cells["Observaciones/Notas Produccion"].Value), tres = Convert.ToString(dataGridView1.CurrentRow.Cells["Especificaciones de costura"].Value);

                salidagui.richTextBox1.Text = uno + dos + tres;
                salidagui.lbl_tiempo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Tiempo Costura"].Value);
                salidagui.ShowDialog();
                DAO.SalidasMaquilaDAO saliasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                dataGridView1.DataSource = saliasdao.vistamaquila();
            }
            catch
            {
                MessageBox.Show("Escoja un proyecto primero");

            }


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "Asunto";
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                DataView dv;
                DAO.SalidasMaquilaDAO saliasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                
                dv = new DataView(saliasdao.vistamaquila());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                GUI.Bodega.AsignacionEmpleadosCostura salidagui = new AsignacionEmpleadosCostura();
                salidagui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                salidagui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Asunto"].Value);
                salidagui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Modelo"].Value);
                salidagui.lblficha.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha"].Value);
                DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                producciondao.idorden = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                salidagui.textBox4.Text = producciondao.devuelve_numeroprendas().ToString();
                //DAO.SalidasMaquilaDAO salidadao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                //salidadao.idproduccion = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                ////salidadao.actualizaproduccionmaquilainterior();
                salidagui.cargaprocesosficha();
                salidagui.cargaprocesostrabajo();
                salidagui.cargaempleados();
                
                salidagui.ShowDialog();

                DAO.SalidasMaquilaDAO saliasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                dataGridView1.DataSource = saliasdao.vistamaquila();
            }
            catch
            {
                MessageBox.Show("Escoja un proyecto primero");

            }
        }
    }
}
