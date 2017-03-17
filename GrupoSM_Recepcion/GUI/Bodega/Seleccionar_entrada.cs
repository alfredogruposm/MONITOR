using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Seleccionar_entrada : Form
    {
        public Seleccionar_entrada()
        {
            InitializeComponent();
        }

        private void Seleccionar_entrada_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = llenatabla();
        }

        private DataTable llenatabla()
        {
            DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
            return salidasdao.prendas_entrada();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if ((Convert.ToString(dataGridView1.CurrentRow.Cells["Entrada Maquila Completa"].Value)) == "")
                {
                    GUI.Bodega.Entrada_maquila entradagui = new Entrada_maquila();
                    entradagui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                    entradagui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Asunto"].Value);
                    entradagui.ShowDialog();
                    dataGridView1.DataSource = llenatabla();
                }
                else
                {
                    GUI.Bodega.Entrada_maquila entradagui = new Entrada_maquila();
                    entradagui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                    entradagui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Asunto"].Value);
                    entradagui.button1.Enabled = false;
                    entradagui.button2.Enabled = false;
                    entradagui.ShowDialog();
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
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                GUI.Bodega.Hoja_Acabados acabadosgui = new Hoja_Acabados();
                acabadosdao.idficha = Convert.ToInt16(dataGridView1.CurrentRow.Cells["idficha"].Value);
                acabadosgui.dataGridView1.DataSource = acabadosdao.acabados_fichas();
                DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                salidasdao.idproduccion = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                acabadosgui.dataGridView2.DataSource = salidasdao.prendas_entrada_cotejo();
                acabadosgui.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Escoja un proyecto primero");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToString(dataGridView1.CurrentRow.Cells["Entrada Maquila Completa"].Value)) != "")
                {
                    DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                    salidasdao.idproduccion = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                    MessageBox.Show(salidasdao.termina_acabados());
                    dataGridView1.DataSource = llenatabla();
                }
                else
                {
                    MessageBox.Show("Es necesario terminar la entrada de prendas de maquila para terminar acabados");
                }

            }
            catch
            {
                MessageBox.Show("Escoja un proyecto primero");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                GUI.Bodega.Salida_maquila salidagui = new Salida_maquila();
                salidagui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                salidagui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Asunto"].Value);
                salidagui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Modelo"].Value);
                salidagui.lblficha.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha"].Value);
                DAO.SalidasMaquilaDAO salidadao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                salidadao.idficha = Convert.ToInt32(dataGridView1.CurrentRow.Cells["idficha"].Value);
                salidagui.lbl_tiempo.Text = Convert.ToString(salidadao.consumocosturaficha());
                salidagui.Text = "Modificar";
                salidagui.ShowDialog();
                dataGridView1.DataSource = llenatabla();
                
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
                string campo = "asunto";
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                DataView dv;
                DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                dv = new DataView(salidasdao.prendas_entrada());
                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";
                dataGridView1.DataSource = dv;
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //try
            //{

                GUI.Bodega.AsignacionEmpleadosCostura salidagui = new AsignacionEmpleadosCostura();
                salidagui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                salidagui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Asunto"].Value);
                salidagui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Modelo"].Value);
                salidagui.lblficha.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idficha"].Value);
                DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                producciondao.idorden = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                salidagui.textBox4.Text = producciondao.devuelve_numeroprendas().ToString();
                DAO.SalidasMaquilaDAO salidadao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                salidadao.idproduccion = Convert.ToInt16(dataGridView1.CurrentRow.Cells["Produccion"].Value);
                //salidadao.actualizaproduccionmaquilainterior();
                salidagui.cargaprocesosficha();
                salidagui.agregaprocesostrabajo();
                salidagui.cargaprocesostrabajo();
                salidagui.cargaempleados();
                salidagui.calculahorasrestantes();

                salidagui.ShowDialog();
                dataGridView1.DataSource = llenatabla();
            //}
            //catch
            //{
            //    MessageBox.Show("Escoja un proyecto primero");

            //}
        }
    }
}
