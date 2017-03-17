using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Avios_captura : Form
    {
        public Avios_captura()
        {
            InitializeComponent();
        }

        private void Avios_captura_Load(object sender, EventArgs e)
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = int.Parse(label5.Text);
            dataGridView2.DataSource = producciondao.vertelasproduccionsum();
            int comprobacion;
            DAO.AviosDAO aviosdao1 = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao1.idproduccion = int.Parse(label5.Text);
            dataGridView3.DataSource = aviosdao1.aviosproduc();
            
            dataGridView5.DataSource = aviosdao1.aviosbodega();
            comprobacion = aviosdao1.existe_produccionavios();

            //if (comprobacion == 0)
            //{

            //    ingresaproducciontabla();
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea reiniciar el estado de los avios?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        string campo = "id_avios";
                        DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                        aviosdao.id_ficha_avio = int.Parse(label7.Text);
                        DataView dv;
                        dv = new DataView(aviosdao.sacar_avios());
                        string busqueda = Convert.ToString(row.Cells["aviosid"].Value.ToString());
                        dv.RowFilter = campo + " = '" + busqueda + "'";
                        dataGridView1.DataSource = dv;
                        decimal cantidad = 0;
                        foreach (DataGridViewRow row1 in dataGridView1.Rows)
                        {
                            cantidad = Convert.ToDecimal(row1.Cells["cantidad"].Value);
                        }

                        cantidad = cantidad * (decimal.Parse(textBox2.Text));

                        aviosdao.idavios = Convert.ToInt16(row.Cells["aviosid"].Value);
                        aviosdao.cantidad = Convert.ToDouble(cantidad - (Convert.ToDecimal(row.Cells["cantidad_necesaria"].Value)));
                        aviosdao.actualizabodegaavios();
                    }

                    actualizagrid1();
                    eliminaproduccion();
                    actualizagrid3();
                    //ingresaproducciontabla();

                }
            }
            catch
            {
                MessageBox.Show("Los avios se encuentran reseteados actualmente");
            }
        }

        public void actualizagrid3()
        {
            DAO.AviosDAO aviosdao1 = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao1.idproduccion = int.Parse(label5.Text);
            dataGridView3.DataSource = aviosdao1.aviosproduc();
        }

        public void actualizagrid1()
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.id_ficha_avio = int.Parse(label7.Text);
            dataGridView1.DataSource = aviosdao.sacar_avios();
        }

        public void eliminaproduccion()
        {
            DAO.AviosDAO aviosdao1 = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao1.idproduccion = int.Parse(label5.Text);
            aviosdao1.eliminaaviosproduccion();
        }

        public void ingresaproducciontabla()
        {
            int comprobacion;
            DAO.AviosDAO aviosdao1 = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao1.idproduccion = int.Parse(label5.Text);
            comprobacion = aviosdao1.existe_produccionavios();
            if (comprobacion == 0)
            {
                int flag=0;
                foreach (DataGridViewRow rowcolor in dataGridView2.Rows)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();

                        aviosdao.cantidad = Convert.ToDouble(Convert.ToDouble(row.Cells["cantidad"].Value) * (double.Parse(rowcolor.Cells[2].Value.ToString())));
                        aviosdao.cantidad_ficha = double.Parse(row.Cells["cantidad"].Value.ToString());
                        aviosdao.idavios = Convert.ToInt32(row.Cells["id_avios"].Value);
                        aviosdao.idproduccion = int.Parse(label5.Text);
                        aviosdao.ingresaavios_produccion();
                        aviosdao.Color = rowcolor.Cells[0].Value.ToString();
                        aviosdao.ingresacoloravios();
                        flag=1;

                    }
                }
                if (flag == 0)
                {
                    DAO.AviosDAO aviosdao3 = new GrupoSM_Recepcion.DAO.AviosDAO();
                        aviosdao3.idproduccion = int.Parse(label5.Text);
                        aviosdao3.id_ficha_avio = int.Parse(label7.Text);
                        aviosdao3.fecha = DateTime.Now.Date;
                        aviosdao3.verificaavios();
                }
                
                MessageBox.Show("Correcto");

            }
            else
            {
                MessageBox.Show("Es necesario primero reiniciar el listado de avios que se utilizaran en la prenda para guardar una nueva seleccion de avios para esta prenda, esto sirve para hacer cambios al momento en los avios de la ficha tecnica seleccionada en una orden de produccion");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tb_cantidad.Text=Convert.ToString(Convert.ToDouble(dataGridView1.CurrentRow.Cells["cantidad"].Value));
            tb_nombre.Text=Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
            tb_precio.Text = Convert.ToString(Convert.ToDouble(dataGridView1.CurrentRow.Cells["costo"].Value) * (double.Parse(textBox2.Text)));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int comprobacion;
            DAO.AviosDAO aviosdao1 = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao1.idproduccion = int.Parse(label5.Text);
            comprobacion = aviosdao1.existe_produccionavios();
            if (comprobacion == 0)
            {
                MessageBox.Show("Es necesario primero guardar el listado de avios que se utilizaran en la prenda");

            }
            else
            {
                GUI.REPORTES.AviosProduccionImprimir aviosimpr = new GrupoSM_Recepcion.GUI.REPORTES.AviosProduccionImprimir();
                aviosimpr.idproduccion = int.Parse(label5.Text);
                aviosimpr.idficha = int.Parse(label7.Text);
                aviosimpr.Show();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "nombre";

                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();

                DataView dv;
                if (comboBox1.SelectedIndex != -1)
                {
                    aviosdao.tipo = comboBox1.SelectedIndex;
                    dv = new DataView(aviosdao.buscatipobodega());
                }
                else
                {
                    dv = new DataView(aviosdao.aviosbodega());
                }

                dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";

                dataGridView5.DataSource = dv;
            }
            catch
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    dataGridView4.Rows.Add(dataGridView5.CurrentRow.Cells["id_avios"].Value.ToString(), dataGridView5.CurrentRow.Cells["nombre"].Value.ToString(), Decimal.Parse(textBox1.Text).ToString());
                }
            }
            catch
            {

            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView4.Rows.Remove(dataGridView4.CurrentRow);
            }
            catch
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ingresaproducciontabla();
        }

        
    }
}
