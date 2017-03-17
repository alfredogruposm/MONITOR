using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class CosteoControl : Form
    {
        public CosteoControl()
        {
            InitializeComponent();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();

        }

        private void CosteoControl_Load(object sender, EventArgs e)
        {
            try
            {
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                aviosdao.id_ficha_avio = int.Parse(tb_id_ficha.Text);
                dataGridView1.DataSource = aviosdao.sacar_avios();
                tb_tiempototal.Text = Convert.ToString(double.Parse(tb_tiempoacabados.Text) + double.Parse(tb_tiempocostura.Text));
                try
                {
                    double sumatoria = 0;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        sumatoria += Convert.ToDouble(row.Cells["costo"].Value);
                    }

                    tb_costoavios.Text = Convert.ToString(sumatoria);
                }
                catch
                {
                    MessageBox.Show("A habido un error en el calculo del costo de avios");
                }

                if (tb_consumotela.Text != "")
                {
                    if (tb_consumotela.Text != "0")
                    {
                        button5.Visible = true;
                    }
                }
                if (textBox10.Text != "")
                {
                    if (textBox10.Text != "0")
                    {
                        button6.Visible = true;
                    }
                }
                if (textBox8.Text != "")
                {
                    if (textBox8.Text != "0")
                    {
                        button7.Visible = true;
                    }
                }
                tb_costomaquila.Text = Convert.ToString((double.Parse(tb_tiempototal.Text) * double.Parse(tb_costominuto.Text)) + double.Parse(tb_costoavios.Text));
                textBox2.Text = Convert.ToString(double.Parse(tb_tiempototal.Text) * double.Parse(tb_costominuto.Text));
                textBox1.Text = tb_tiempoacabados.Text;
                calculopreciotela();
                // textBox2.Text=Convert.ToString(double.Parse(tb_costomaquila.Text)
                //tb_costoventa.Text = Convert.ToString(((double.Parse(tb_tiempototal.Text) * double.Parse(tb_costominuto.Text)) + double.Parse(tb_costoavios.Text)) + (double.Parse(tb_costometro.Text) * double.Parse(tb_consumotela.Text)));
            }
            catch
            {
                //this.Visible = false;
                //this.Close();
                MessageBox.Show("A ocurrido un error, vuelva a intentarlo");
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_costometro.Text != "")
            {

                tb_costoventa.Text = Convert.ToString(((double.Parse(tb_tiempototal.Text) * double.Parse(tb_costominuto.Text)) + double.Parse(tb_costoavios.Text)) + double.Parse(tb_costometro.Text));
                textBox5.Text = Convert.ToString((double.Parse(tb_tiempototal.Text) * double.Parse(tb_costominuto.Text)) + double.Parse(tb_costometro.Text));
                button3.Visible = true;
            }
            else
            {
                MessageBox.Show("Especifique el costo de la tela");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tb_porcentajeComision.Text != "")
            {

                tb_preciomaquila.Text = Convert.ToString((double.Parse(tb_costomaquila.Text) * (double.Parse(tb_porcentajeComision.Text) / 100)) + double.Parse(tb_costomaquila.Text));
                textBox3.Text = Convert.ToString((double.Parse(textBox2.Text) * (double.Parse(tb_porcentajeComision.Text) / 100)) + double.Parse(textBox2.Text));
                
            }
            else
            {
                MessageBox.Show("Especifique el porcentaje de comision");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tb_porcentajeComision.Text != "")
            {

                tb_precioventa.Text = Convert.ToString((double.Parse(tb_costoventa.Text) * (double.Parse(tb_porcentajeComision.Text) / 100)) + double.Parse(tb_costoventa.Text));
                textBox4.Text = Convert.ToString((double.Parse(textBox5.Text) * (double.Parse(tb_porcentajeComision.Text) / 100)) + double.Parse(textBox5.Text));
            }
            else
            {
                MessageBox.Show("Especifique el porcentaje de comision");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.SeleccionarTela telagui = new SeleccionarTela(this);
            telagui.ShowDialog();
            calculopreciotela();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
                GUI.Recepcion.SeleccionarTela telagui = new SeleccionarTela(this);
                telagui.Text = "Seleccionar Combinacion";
                telagui.ShowDialog();
                calculopreciotela();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.SeleccionarTela telagui = new SeleccionarTela(this);
            telagui.Text = "Seleccionar Forro";
            telagui.ShowDialog();
            calculopreciotela();
        }

        public void calculopreciotela()
        { //567
            // 000 111 011 101 110 100 010 001
            if ((button5.Visible.Equals(false)) && (button6.Visible.Equals(false)) && (button7.Visible.Equals(false)))
            {
                tb_costometro.Text = "0";
            }


            if ((button5.Visible.Equals(true)) && (button6.Visible.Equals(true)) && (button7.Visible.Equals(true)))
                {
                    if ((label24.Text != "label24") && (label25.Text != "label25") && (label26.Text != "label26"))
                    {
                        tb_costometro.Text = Convert.ToString((double.Parse(label24.Text) * (double.Parse(tb_consumotela.Text))) + (double.Parse(label25.Text) * (double.Parse(textBox10.Text))) + (double.Parse(label26.Text) * (double.Parse(textBox8.Text))));
                    }
                }

            if ((button5.Visible.Equals(false)) && (button6.Visible.Equals(true)) && (button7.Visible.Equals(true)))
                {
                    if ((label25.Text != "label25") && (label26.Text != "label26"))
                    {
                        tb_costometro.Text = Convert.ToString((double.Parse(label25.Text) * (double.Parse(textBox10.Text))) + (double.Parse(label26.Text) * (double.Parse(textBox8.Text))));
                    }
                }

            if ((button5.Visible.Equals(true)) && (button6.Visible.Equals(false)) && (button7.Visible.Equals(true)))
                {
                    if ((label24.Text != "label24")&&(label26.Text != "label26"))
                    {
                        tb_costometro.Text = Convert.ToString((double.Parse(label24.Text) * (double.Parse(tb_consumotela.Text))) + (double.Parse(label26.Text) * (double.Parse(textBox8.Text))));
                    }
                }

            if ((button5.Visible.Equals(true)) && (button6.Visible.Equals(true)) && (button7.Visible.Equals(false)))
                {
                    if ((label24.Text != "label24") && (label25.Text != "label25"))
                    {
                        tb_costometro.Text = Convert.ToString((double.Parse(label24.Text) * (double.Parse(tb_consumotela.Text))) + (double.Parse(label25.Text) * (double.Parse(textBox10.Text))));
                    }
                }

            if ((button5.Visible.Equals(true)) && (button6.Visible.Equals(false)) && (button7.Visible.Equals(false)))
                {
                    if ((label24.Text != "label24"))
                    {
                        tb_costometro.Text = Convert.ToString((double.Parse(label24.Text) * (double.Parse(tb_consumotela.Text))));
                    }
                }

            if ((button5.Visible.Equals(false)) && (button6.Visible.Equals(true)) && (button7.Visible.Equals(false)))
                {
                    if ((label25.Text != "label25"))
                    {
                        tb_costometro.Text = Convert.ToString( (double.Parse(label25.Text) * (double.Parse(textBox10.Text))));
                    }
                }

            if ((button5.Visible.Equals(false)) && (button6.Visible.Equals(false)) && (button7.Visible.Equals(true)))
                {
                    if ((label26.Text != "label26"))
                    {
                        tb_costometro.Text = Convert.ToString((double.Parse(label26.Text) * (double.Parse(textBox8.Text))));
                    }
                }
            
        
        }


        
    }
}
