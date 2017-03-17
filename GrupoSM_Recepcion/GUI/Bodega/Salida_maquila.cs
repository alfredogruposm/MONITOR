using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Salida_maquila : Form
    {
        public Salida_maquila()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Seleccionar_Maquilador seleccionarmaquiladorgui = new Seleccionar_Maquilador(this);
            seleccionarmaquiladorgui.ShowDialog(this);
            int numero = 3;
            try
            {
                textBox8.Text = Convert.ToString(decimal.Round((decimal.Parse(lbl_tiempo.Text) * decimal.Parse(label7.Text)), 3));
                numero = 1;
            }
            catch
            {
                numero = 0;
            }
            finally
            {
                if (numero == 1)
                {
                    button2.Enabled = true;
                }
            }
        }

        public void actualizagrid3()
        {
            DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
            salidasdao.idproduccion = int.Parse(textBox1.Text);
            dataGridView3.DataSource = salidasdao.devuelvedetallesalidas();
        }

        private void Salida_maquila_Load(object sender, EventArgs e)
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = int.Parse(textBox1.Text);
            dataGridView1.DataSource = producciondao.tallas_preliminaresproduccion2();
            actualizagrid2();
            if (this.Text == "Modificar")
            {
                
                actualizagrid3();
                button4.Enabled = true;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    button2.Text = "Guardar";
                    richTextBox1.Text = Convert.ToString(row.Cells["Especificaciones"].Value);
                    richTextBox2.Text = Convert.ToString(row.Cells["Notas"].Value);
                    richTextBox3.Text = Convert.ToString(row.Cells["Pagare"].Value);
                    textBox7.Text = Convert.ToString(row.Cells["Tela"].Value);
                    textBox8.Text = Convert.ToString(row.Cells["Mano_de_obra"].Value);
                    textBox6.Text = Convert.ToString(row.Cells["Maquilador"].Value);
                    
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox6.Text != "") && (textBox7.Text != "") && (textBox8.Text != "") && (richTextBox1.Text != ""))
                {
                    int sumatoria = 0;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        sumatoria += Convert.ToInt32(row.Cells["cantidad_prendas"].Value);
                    }


                    DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                    salidasdao.idproduccion = int.Parse(textBox1.Text);
                    salidasdao.maquilador = int.Parse(label12.Text);
                    salidasdao.prendas_enviadas = sumatoria;
                    salidasdao.manobra = double.Parse(textBox8.Text);
                    string resultado = salidasdao.salidamaquila();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        //(this.idproduccion, this.Fecha, this.Modelo, Convert.ToDecimal(this.manobra), this.Prenda, this.Tela, this.Notas, this.Especificaciones, this.Pagare, this.MaquiladorT)
                        DAO.SalidasMaquilaDAO salidas = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                        salidas.idproduccion = int.Parse(textBox1.Text);
                        salidas.Fecha = dateTimePicker1.Value;
                        salidas.Modelo = textBox2.Text;
                        salidas.manobra=double.Parse(textBox8.Text);
                        salidas.Prenda = textBox3.Text;
                        salidas.Tela = textBox7.Text;
                        salidas.Notas = richTextBox2.Text;

                        string resultado3 = richTextBox1.Text;
                        resultado3 = Regex.Replace(resultado3, @"\s+", " ");
                        richTextBox1.Text = resultado3;

                        salidas.Especificaciones = richTextBox1.Text;
                        salidas.Pagare = richTextBox3.Text;
                        salidas.MaquiladorT = textBox6.Text;
                        string resultado2 = salidas.insertadetallesalida();
                        if (resultado2 != "Correcto")
                        {
                            MessageBox.Show(resultado2);
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("¿Desea imprimir la hoja de salida en este momento?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                GUI.REPORTES.Pruebatallas impresion = new GrupoSM_Recepcion.GUI.REPORTES.Pruebatallas();
                                impresion.idproduccion = int.Parse(textBox1.Text);
                                impresion.idficha = int.Parse(lblficha.Text);
                                impresion.Show();
                                GUI.REPORTES.SalidaMaquilaHoja2 impresion2 = new GrupoSM_Recepcion.GUI.REPORTES.SalidaMaquilaHoja2();
                                impresion2.idproduccion = int.Parse(textBox1.Text);
                                impresion2.idficha = int.Parse(lblficha.Text);
                                impresion2.Show();
                                this.Hide();
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                                this.Close();
                            }
                            
                        }

                    }
                    
                }

            }
            catch
            {
                MessageBox.Show("Error de calculo");

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        public void actualizagrid2()
        {
            DAO.SalidasMaquilaDAO saldiasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
            saldiasdao.idproduccion = int.Parse(textBox1.Text);
            dataGridView2.DataSource = saldiasdao.salidasavios();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                salidasdao.id_salidadetalle = Convert.ToInt32(dataGridView2.CurrentRow.Cells["ID"].Value);
                string resultado=salidasdao.ELIMINAdetallesalidaavios();
                if (resultado != "Correcto")
                {
                    
                    MessageBox.Show(resultado);
                }
                else
                {

                    actualizagrid2();
                }
            }
            catch
            {

            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar(Keys.Enter))
            //{
            //    if ((textBox4.Text != "") && (textBox5.Text != ""))
            //    {
            //        DAO.SalidasMaquilaDAO salidas = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
            //        salidas.idproduccion = int.Parse(textBox1.Text);
            //        salidas.texto1 = textBox4.Text;
            //        salidas.texto2 = textBox5.Text;
            //        string resultado = salidas.insertadetallesalidaavios();
            //        if (resultado != "Correcto")
            //        {
            //            MessageBox.Show(resultado);
            //        }
            //        else
            //        {
            //            actualizagrid2();
            //        }
            //    }
            //}
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if ((textBox4.Text != "") && (textBox5.Text != ""))
                {
                    DAO.SalidasMaquilaDAO salidas = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                    salidas.idproduccion = int.Parse(textBox1.Text);
                    salidas.texto1 = textBox4.Text;
                    salidas.texto2 = textBox5.Text;
                    string resultado = salidas.insertadetallesalidaavios();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        actualizagrid2();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea imprimir la hoja de salida en este momento?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    GUI.REPORTES.Pruebatallas impresion = new GrupoSM_Recepcion.GUI.REPORTES.Pruebatallas();
                    impresion.idproduccion = int.Parse(textBox1.Text);
                    impresion.idficha = int.Parse(lblficha.Text);
                    impresion.Show();
                    GUI.REPORTES.SalidaMaquilaHoja2 impresion2 = new GrupoSM_Recepcion.GUI.REPORTES.SalidaMaquilaHoja2();
                    impresion2.idproduccion = int.Parse(textBox1.Text);
                    impresion2.idficha = int.Parse(lblficha.Text);
                    impresion2.Show();
                    this.Hide();
                    this.Close();
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido algun error");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
    }
}
