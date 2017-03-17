using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class Agregar_Tallas : Form
    {
        int proporcion = 0;
        int cantidad = 0;
        GUI.Recepcion.Orden_Produccion ordengui;
        public Agregar_Tallas(GUI.Recepcion.Orden_Produccion fr1)
        {
            ordengui = new Orden_Produccion();
            ordengui = fr1;
            InitializeComponent();
        }

        private void Agregar_Tallas_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //groupBox1.Visible = true;
            //button2.Visible = false;
            //tb_proporcion_total.Visible = true;
            //label5.Visible = true;
            //button3.Visible = false;
            groupBox1.Visible = true;
            cantidad = 1;
            button4.Visible = false;
            button7.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button8.Visible = true;

            tb_metrostela.Enabled = false;
            tb_proporcion_total.Enabled = false;
            tb_combinacion.Text = lbl_combinacion.Text;
            tb_tela.Text = lbl_tela.Text;
            tb_rollotela.Enabled = false;
            //tb_combinacion.Enabled = false;
            tb_numrollocombinacion.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button8.Visible = true;
            cantidad = 1;
            button7.Visible = false;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = int.Parse(label_orden.Text);
            ordengui.dataGridView1.DataSource = producciondao.tallas_preliminaresproduccion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            cantidad = 1;
            button4.Visible = false;
            button7.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button8.Visible = true;

            tb_metrostela.Enabled = false;
            tb_proporcion_total.Enabled = false;
            tb_combinacion.Text = lbl_combinacion.Text;
            tb_tela.Text = lbl_tela.Text;
            tb_rollotela.Enabled = false;
            tb_combinacion.Enabled = false;
            tb_numrollocombinacion.Enabled = false;
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            button4.Visible = false;
            button8.Visible = true;
            proporcion = 1;
            button7.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (cantidad == 1)
            {
                if ((tb_cantidadproporcion.Text != "") && (tb_talla.Text != "")&&(tb_color.Text!=""))
                {
                    DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                    
                        producciondao.id_produccion = int.Parse(label_orden.Text);
                        producciondao.tela = tb_tela.Text;

                        if (tb_combinacion.Text != "")
                        {
                            producciondao.combinacion = tb_combinacion.Text;
                        }
                        else
                        {
                            producciondao.combinacion = null;
                        }
                        if (tb_rollotela.Text != "")
                        {
                            producciondao.num_tela_rollo = int.Parse(tb_rollotela.Text);
                        }
                        else
                        {
                            producciondao.num_tela_rollo = 0;
                        }
                        if (tb_numrollocombinacion.Text != "")
                        {
                            producciondao.num_combinacion_rollo = int.Parse(tb_numrollocombinacion.Text);
                        }
                        else
                        {
                            producciondao.num_combinacion_rollo = 0;
                        }

                        producciondao.talla = (tb_talla.Text);
                        producciondao.color = tb_color.Text;
                        string cantidad_deprendas = tb_cantidadproporcion.Text;
                        producciondao.cantidad_prendas = double.Parse(cantidad_deprendas);

                        producciondao.metros_recibidos = Convert.ToDouble(Decimal.Round((Convert.ToDecimal((int.Parse(cantidad_deprendas)) * (double.Parse(label_consumo.Text)))), 8));
                        int resultado = producciondao.ingresa_tallascolores();
                        if (resultado == 1)
                        {
                            tb_color.Enabled = false;
                            tb_combinacion.Enabled = false;
                            tb_numrollocombinacion.Enabled = false;
                            tb_rollotela.Enabled = false;
                            tb_tela.Enabled = false;
                            tb_metrostela.Enabled = false;
                            tb_cantidadproporcion.Text = "";
                            tb_talla.Text = "";
                            tb_proporcion_total.Text = "";
                            bt_nuevocolor.Visible = true;
                            bt_done_colors.Visible = true;
                            
                                producciondao.id_produccion = int.Parse(label_orden.Text);
                                dataGridView1.DataSource = producciondao.tallas_preliminaresproduccion();
                            
                        }
                        else
                        {
                            MessageBox.Show("Hubo algun error, intentelo otra vez");
                        }
                  



                }
                else
                {
                    MessageBox.Show("Ingrese por favor los datos necesarios para ingresar la talla (Cantidad de prendas, Talla y el color)");
                }
            }
            
                if (proporcion == 1)
                {
                    if ((tb_cantidadproporcion.Text != "") && (tb_proporcion_total.Text != "") && (tb_talla.Text != "") && (tb_metrostela.Text != "") && (tb_tela.Text != "") && (tb_color.Text != ""))
                    {
                        DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                       

                            producciondao.id_produccion = int.Parse(label_orden.Text);
                            producciondao.tela = tb_tela.Text;

                            if (tb_combinacion.Text != "")
                            {
                                producciondao.combinacion = tb_combinacion.Text;
                            }
                            else
                            {
                                producciondao.combinacion = null;
                            }
                            if (tb_rollotela.Text != "")
                            {
                                producciondao.num_tela_rollo = int.Parse(tb_rollotela.Text);
                            }
                            else
                            {
                                producciondao.num_tela_rollo = 0;
                            }
                            if (tb_numrollocombinacion.Text != "")
                            {
                                producciondao.num_combinacion_rollo = int.Parse(tb_numrollocombinacion.Text);
                            }
                            else
                            {
                                producciondao.num_combinacion_rollo = 0;
                            }

                            producciondao.talla = (tb_talla.Text);
                            producciondao.color = tb_color.Text;
                            int cantidad_deprendas = Convert.ToInt32((((double.Parse(tb_metrostela.Text)) / (double.Parse(label_consumo.Text))) / (double.Parse(tb_proporcion_total.Text))) * (double.Parse(tb_cantidadproporcion.Text)));
                            producciondao.cantidad_prendas = cantidad_deprendas;

                            producciondao.metros_recibidos = (cantidad_deprendas) * (double.Parse(label_consumo.Text));
                            int resultado = producciondao.ingresa_tallascolores();
                            if (resultado == 1)
                            {
                                tb_color.Enabled = false;
                                tb_combinacion.Enabled = false;
                                tb_numrollocombinacion.Enabled = false;
                                tb_rollotela.Enabled = false;
                                tb_tela.Enabled = false;
                                tb_metrostela.Enabled = false;
                                tb_cantidadproporcion.Text = "";
                                tb_talla.Text = "";
                                tb_proporcion_total.Enabled = false;
                                bt_nuevocolor.Visible = true;
                                bt_done_colors.Visible = true;
                                

                                    producciondao.id_produccion = int.Parse(label_orden.Text);
                                    dataGridView1.DataSource = producciondao.tallas_preliminaresproduccion();
                            }
                            else
                            {
                                MessageBox.Show("Hubo algun error, intentelo otra vez");
                            }
                        



                    }
                    else
                    {
                        MessageBox.Show("Ingrese por favor los datos minimos para ingresar la talla (Proporcion, Proporcion Total, Talla, Metros de tela, la tela y el color)");
                    }


                }
            
        }

        private void bt_seleccionfichadetalle_Click(object sender, EventArgs e)
        {

        }

        private void bt_nuevocolor_Click(object sender, EventArgs e)
        {
            
            if (cantidad == 1)
            {
                tb_color.Enabled = true;
                tb_color.Text = "";
                tb_combinacion.Text = "";
                tb_combinacion.Enabled = true;
            }
            else
            {
                tb_color.Text = "";
                tb_combinacion.Text = "";
                tb_metrostela.Text = "";
                tb_numrollocombinacion.Text = "";
                tb_rollotela.Text = "";
                tb_talla.Text = "";
                tb_tela.Text = "";
                tb_cantidadproporcion.Text = "";
                tb_color.Enabled = true;
                tb_combinacion.Enabled = true;
                tb_metrostela.Enabled = true;
                tb_numrollocombinacion.Enabled = true;
                tb_rollotela.Enabled = true;
                tb_talla.Enabled = true;
                tb_tela.Enabled = true;
                tb_cantidadproporcion.Enabled = true;
                

                
                
            }
        }

        private void bt_done_colors_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            DAO.ProduccionDAO producciondao=new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = int.Parse(label_orden.Text);
            ordengui.dataGridView1.DataSource = producciondao.tallas_preliminaresproduccion();
            ordengui.button6.Visible = true;
        }

        

        
    }
}
