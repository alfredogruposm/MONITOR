using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Telas_Captura : Form
    {
        public Telas_Captura()
        {
            InitializeComponent();
        }

        private void Telas_Captura_Load(object sender, EventArgs e)
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = int.Parse(lbl_idorden.Text);
            dataGridView1.DataSource = producciondao.combinacionproduccion();
            dataGridView2.DataSource = producciondao.vertelasproduccionsum();
            double sumatoria = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sumatoria += Convert.ToDouble(row.Cells["cantidad_prendas"].Value);
            }

            tb_cantidad.Text = Convert.ToString(sumatoria);
            tb_metroforro.Text = Convert.ToString(double.Parse(tb_cantidad.Text) * double.Parse(lbl_consumoforro.Text));

            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            telasdao.produccion = int.Parse(lbl_idorden.Text);
            telasdao.tipo = 0;
            dataGridView3.DataSource = telasdao.vertelas_asignados();
            telasdao.tipo = 1;
            dataGridView4.DataSource = telasdao.vertelas_asignados();
            telasdao.tipo = 2;
            dataGridView5.DataSource = telasdao.vertelas_asignados();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tb_cantidadcombinacion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cantidad_prendas"].Value);
            tb_metroscombinacion.Text = Convert.ToString(double.Parse(tb_cantidadcombinacion.Text) * double.Parse(lbl_consumocombinacion.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Tela_Seleccion telasgui = new Tela_Seleccion();
            telasgui.label1.Text = lbl_cliente.Text;
            telasgui.label2.Text = "0";
            telasgui.label6.Text = label1.Text;
            telasgui.tb_combinacion.Text = tb_tela.Text;
            telasgui.label5.Text = "Color";
            telasgui.tb_cantidadcombinacion.Text = Convert.ToString(dataGridView2.CurrentRow.Cells["color"].Value);
            telasgui.tb_metroscombinacion.Text = Convert.ToString(dataGridView2.CurrentRow.Cells["metros"].Value);
            telasgui.label3.Text = lbl_idorden.Text;
            telasgui.ShowDialog();
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            telasdao.produccion = int.Parse(lbl_idorden.Text);
            telasdao.tipo = 0;
            dataGridView3.DataSource = telasdao.vertelas_asignados();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Tela_Seleccion telasgui = new Tela_Seleccion();
            telasgui.label1.Text = lbl_cliente.Text;
            telasgui.label2.Text = "1";
            telasgui.label6.Text = label1.Text;
            telasgui.tb_combinacion.Text = tb_tela.Text;
            telasgui.label5.Visible = false;
            telasgui.tb_cantidadcombinacion.Visible = false;
            telasgui.label4.Visible = false;
            telasgui.tb_metroscombinacion.Visible = false;
            telasgui.label3.Text = lbl_idorden.Text;
            telasgui.ShowDialog();
            
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            telasdao.produccion = int.Parse(lbl_idorden.Text);
            telasdao.tipo = 1;
            dataGridView4.DataSource = telasdao.vertelas_asignados();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((tb_forro.Text != "") && (tb_metroforro.Text != "") && (tb_cantidad.Text != ""))
            {
                GUI.Bodega.Tela_Seleccion telasgui = new Tela_Seleccion();
                telasgui.label1.Text = lbl_cliente.Text;
                telasgui.label2.Text = "2";
                telasgui.label6.Text = label9.Text;
                telasgui.tb_combinacion.Text = tb_forro.Text;
                telasgui.label5.Visible = false;
                telasgui.tb_cantidadcombinacion.Visible = false;
                telasgui.label4.Visible = false;
                telasgui.tb_metroscombinacion.Visible = false;
                telasgui.label3.Text = lbl_idorden.Text;
                telasgui.ShowDialog();

                DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao.produccion = int.Parse(lbl_idorden.Text);
                telasdao.tipo = 2;
                dataGridView5.DataSource = telasdao.vertelas_asignados();
            }
            else
            {
                button5.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
                double sumatoria = 0;

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    sumatoria += Convert.ToDouble(row.Cells["metros"].Value);
                }

                double sumatoria2 = 0;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    sumatoria2 += Convert.ToDouble(row.Cells["metros"].Value);
                }

                textBox1.Text = Convert.ToString(sumatoria - sumatoria2);

                if (sumatoria > sumatoria2)
                {
                    MessageBox.Show("Le faltan " + (sumatoria - sumatoria2));
                }
                double a = (sumatoria2 - sumatoria);
                if (sumatoria2 > sumatoria)
                {
                    MessageBox.Show("Le Sobran " + a);
                    lbl1.Text = "1";
                }
                if (sumatoria == sumatoria2)
                {
                    MessageBox.Show("El numero esta exacto");
                    lbl1.Text = "1";
                }
                if ((lbl1.Text == "1") && (lbl2.Text == "1") && (lbl3.Text == "1"))
                {
                    button12.Visible = true;
                    DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    producciondao.idorden = int.Parse(lbl_idorden.Text);
                    dataGridView6.DataSource = producciondao.ver_producciondetalle();
                }
            
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
                double sumatoria = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    sumatoria += (Convert.ToDouble(row.Cells["Cantidad_prendas"].Value))*(double.Parse(lbl_consumocombinacion.Text));
                }

                double sumatoria2 = 0;

                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    sumatoria2 += Convert.ToDouble(row.Cells["metros"].Value);
                }

                textBox2.Text = Convert.ToString(sumatoria - sumatoria2);

                if (sumatoria > sumatoria2)
                {
                    MessageBox.Show("Le faltan " + (sumatoria - sumatoria2));
                }
                double a = (sumatoria2 - sumatoria);
                if (sumatoria2 > sumatoria)
                {
                    MessageBox.Show("Le Sobran" + a);
                    lbl2.Text = "1";
                }
                if (sumatoria == sumatoria2)
                {
                    MessageBox.Show("El numero esta exacto");
                    lbl2.Text = "1";
                }
                if ((lbl1.Text == "1") && (lbl2.Text == "1") && (lbl3.Text == "1"))
                {
                    button12.Visible = true;
                    DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    producciondao.idorden = int.Parse(lbl_idorden.Text);
                    dataGridView6.DataSource = producciondao.ver_producciondetalle();
                }
            
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
                double sumatoria = 0;

                sumatoria = double.Parse(tb_metroforro.Text);
                

                double sumatoria2 = 0;

                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    sumatoria2 += Convert.ToDouble(row.Cells["metros"].Value);
                }

                textBox3.Text = Convert.ToString(sumatoria - sumatoria2);

                if (sumatoria > sumatoria2)
                {
                    MessageBox.Show("Le faltan " + (sumatoria - sumatoria2));
                }
                double a = (sumatoria2 - sumatoria);
                if (sumatoria2 > sumatoria)
                {
                    MessageBox.Show("Le Sobran" + a);
                    lbl3.Text = "1";
                }
                if (sumatoria == sumatoria2)
                {
                    MessageBox.Show("El numero esta exacto");
                    lbl3.Text = "1";
                }
                if ((lbl1.Text == "1") && (lbl2.Text == "1") && (lbl3.Text == "1"))
                {
                    button12.Visible = true;
                    DAO.Oden_ProduccionDAO producciondao2 = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    producciondao2.idorden = int.Parse(lbl_idorden.Text);
                    dataGridView6.DataSource = producciondao2.ver_producciondetalle();
                }
           
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                    telasdao.cliente = int.Parse(lbl_cliente.Text);
                    telasdao.fecha_entrada = Convert.ToDateTime(row.Cells["fecha_entrada"].Value);
                    telasdao.proveedor = Convert.ToInt32(row.Cells["proveedor"].Value);
                    telasdao.metros = Convert.ToDouble(row.Cells["metros"].Value);
                    telasdao.nombre_descripcion = Convert.ToString(row.Cells["nombre_descripcion"].Value);
                    telasdao.composicion = Convert.ToString(row.Cells["composicion"].Value);
                    telasdao.color = Convert.ToString(row.Cells["color"].Value);
                    telasdao.ancho = Convert.ToDouble(row.Cells["ancho"].Value);
                    telasdao.tipo = 0;
                    telasdao.insertatela();
                    
                }
                DAO.TelasDAO telasdao2 = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao2.tipo = 0;
                telasdao2.produccion = Convert.ToInt32(dataGridView3.CurrentRow.Cells["produccion"].Value);
                telasdao2.borra_telasasignadas();
                dataGridView3.DataSource = telasdao2.vertelas_asignados();
            }
            catch
            {
                MessageBox.Show("Error, escoga una tela, o agregue una");
            }
           
            
            

            

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                    telasdao.cliente = int.Parse(lbl_cliente.Text);
                    telasdao.fecha_entrada = Convert.ToDateTime(row.Cells["fecha_entrada"].Value);
                    telasdao.proveedor = Convert.ToInt32(row.Cells["proveedor"].Value);
                    telasdao.metros = Convert.ToDouble(row.Cells["metros"].Value);
                    telasdao.nombre_descripcion = Convert.ToString(row.Cells["nombre_descripcion"].Value);
                    telasdao.composicion = Convert.ToString(row.Cells["composicion"].Value);
                    telasdao.color = Convert.ToString(row.Cells["color"].Value);
                    telasdao.ancho = Convert.ToDouble(row.Cells["ancho"].Value);
                    telasdao.tipo = 1;
                    telasdao.insertatela();
                    
                }
                DAO.TelasDAO telasdao2 = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao2.tipo = 1;
                telasdao2.produccion = Convert.ToInt32(dataGridView4.CurrentRow.Cells["produccion"].Value);
                telasdao2.borra_telasasignadas();
                dataGridView4.DataSource = telasdao2.vertelas_asignados();
            }
            catch
            {
                MessageBox.Show("Error, escoga una tela, o agregue una");
            }
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                    telasdao.cliente = int.Parse(lbl_cliente.Text);
                    telasdao.fecha_entrada = Convert.ToDateTime(row.Cells["fecha_entrada"].Value);
                    telasdao.proveedor = Convert.ToInt32(row.Cells["proveedor"].Value);
                    telasdao.metros = Convert.ToDouble(row.Cells["metros"].Value);
                    telasdao.nombre_descripcion = Convert.ToString(row.Cells["nombre_descripcion"].Value);
                    telasdao.composicion = Convert.ToString(row.Cells["composicion"].Value);
                    telasdao.color = Convert.ToString(row.Cells["color"].Value);
                    telasdao.ancho = Convert.ToDouble(row.Cells["ancho"].Value);
                    telasdao.tipo = 2;
                    telasdao.insertatela();
                }
                DAO.TelasDAO telasdao2 = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao2.tipo = 2;
                telasdao2.produccion = Convert.ToInt32(dataGridView5.CurrentRow.Cells["produccion"].Value);
                telasdao2.borra_telasasignadas();
                dataGridView4.DataSource = telasdao2.vertelas_asignados();
            }
            catch
            {
                MessageBox.Show("Error, escoga una tela, o agregue una");
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView6.Rows)
                {
                    DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    producciondao.idorden = Convert.ToInt32(row.Cells["id_produccion_detalle"].Value);
                    producciondao.actualizadetalles_tela();
                }
            }
            catch
            {
            }
            finally
            {
                DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                producciondao.idorden = int.Parse(lbl_idorden.Text);
                producciondao.fecha_tela = dateTimePicker1.Value;
                int numero = producciondao.actualiza_orden_telas();
                if (numero == 1)
                {
                    MessageBox.Show("Correcto");
                    this.Visible = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("A habido algun error");
                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //this.produccion, this.fecha_entrada, this.nombre_descripcion, this.tipo
            try
            {
                DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao.cliente = int.Parse(lbl_cliente.Text);
                telasdao.fecha_entrada = Convert.ToDateTime(dataGridView3.CurrentRow.Cells["fecha_entrada"].Value);
                telasdao.proveedor = Convert.ToInt32(dataGridView3.CurrentRow.Cells["proveedor"].Value);
                telasdao.metros = Convert.ToDouble(dataGridView3.CurrentRow.Cells["metros"].Value);
                telasdao.nombre_descripcion = Convert.ToString(dataGridView3.CurrentRow.Cells["nombre_descripcion"].Value);
                telasdao.composicion = Convert.ToString(dataGridView3.CurrentRow.Cells["composicion"].Value);
                telasdao.color = Convert.ToString(dataGridView3.CurrentRow.Cells["color"].Value);
                telasdao.ancho = Convert.ToDouble(dataGridView3.CurrentRow.Cells["ancho"].Value);
                telasdao.tipo = 0;
                telasdao.insertatela();
                telasdao.produccion = int.Parse(lbl_idorden.Text);
                telasdao.elimina_entradatelaasignada();
                DAO.TelasDAO telasdao2 = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao2.tipo = 0;
                telasdao2.produccion = Convert.ToInt32(dataGridView3.CurrentRow.Cells["produccion"].Value);
                dataGridView3.DataSource = telasdao2.vertelas_asignados();
            }
            catch
            {
                MessageBox.Show("Error, escoga una tela, o agregue una");
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao.cliente = int.Parse(lbl_cliente.Text);
                telasdao.fecha_entrada = Convert.ToDateTime(dataGridView4.CurrentRow.Cells["fecha_entrada"].Value);
                telasdao.proveedor = Convert.ToInt32(dataGridView4.CurrentRow.Cells["proveedor"].Value);
                telasdao.metros = Convert.ToDouble(dataGridView4.CurrentRow.Cells["metros"].Value);
                telasdao.nombre_descripcion = Convert.ToString(dataGridView4.CurrentRow.Cells["nombre_descripcion"].Value);
                telasdao.composicion = Convert.ToString(dataGridView4.CurrentRow.Cells["composicion"].Value);
                telasdao.color = Convert.ToString(dataGridView4.CurrentRow.Cells["color"].Value);
                telasdao.ancho = Convert.ToDouble(dataGridView4.CurrentRow.Cells["ancho"].Value);
                telasdao.tipo = 1;
                telasdao.insertatela();
                telasdao.produccion = Convert.ToInt32(dataGridView4.CurrentRow.Cells["produccion"].Value);
                telasdao.elimina_entradatelaasignada();
                DAO.TelasDAO telasdao2 = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao2.tipo = 1;
                telasdao2.produccion = Convert.ToInt32(dataGridView4.CurrentRow.Cells["produccion"].Value);
                dataGridView4.DataSource = telasdao2.vertelas_asignados();
            }
            catch
            {
                MessageBox.Show("Error, escoga una tela, o agregue una");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao.cliente = int.Parse(lbl_cliente.Text);
                telasdao.fecha_entrada = Convert.ToDateTime(dataGridView5.CurrentRow.Cells["fecha_entrada"].Value);
                telasdao.proveedor = Convert.ToInt32(dataGridView5.CurrentRow.Cells["proveedor"].Value);
                telasdao.metros = Convert.ToDouble(dataGridView5.CurrentRow.Cells["metros"].Value);
                telasdao.nombre_descripcion = Convert.ToString(dataGridView5.CurrentRow.Cells["nombre_descripcion"].Value);
                telasdao.composicion = Convert.ToString(dataGridView5.CurrentRow.Cells["composicion"].Value);
                telasdao.color = Convert.ToString(dataGridView5.CurrentRow.Cells["color"].Value);
                telasdao.ancho = Convert.ToDouble(dataGridView5.CurrentRow.Cells["ancho"].Value);
                telasdao.tipo = 2;
                telasdao.insertatela();
                telasdao.produccion = Convert.ToInt32(dataGridView5.CurrentRow.Cells["produccion"].Value);
                telasdao.elimina_entradatelaasignada();
                DAO.TelasDAO telasdao2 = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao2.tipo = 2;
                telasdao2.produccion = Convert.ToInt32(dataGridView5.CurrentRow.Cells["produccion"].Value);
                dataGridView5.DataSource = telasdao2.vertelas_asignados();
            }
            catch
            {
                MessageBox.Show("Error, escoga una tela, o agregue una");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            lbl1.Text = "1";
                
                if ((lbl1.Text == "1") && (lbl2.Text == "1") && (lbl3.Text == "1"))
                {
                    button12.Visible = true;
                    DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    producciondao.idorden = int.Parse(lbl_idorden.Text);
                    dataGridView6.DataSource = producciondao.ver_producciondetalle();
                }
        }

        private void button17_Click(object sender, EventArgs e)
        {
             
                    lbl2.Text = "1";
                
                if ((lbl1.Text == "1") && (lbl2.Text == "1") && (lbl3.Text == "1"))
                {
                    button12.Visible = true;
                    DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    producciondao.idorden = int.Parse(lbl_idorden.Text);
                    dataGridView6.DataSource = producciondao.ver_producciondetalle();
                }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            lbl3.Text = "1";
                
                if ((lbl1.Text == "1") && (lbl2.Text == "1") && (lbl3.Text == "1"))
                {
                    button12.Visible = true;
                    DAO.Oden_ProduccionDAO producciondao2 = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    producciondao2.idorden = int.Parse(lbl_idorden.Text);
                    dataGridView6.DataSource = producciondao2.ver_producciondetalle();
                }
        }
    }
}
