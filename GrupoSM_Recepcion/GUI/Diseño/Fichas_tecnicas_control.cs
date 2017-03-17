using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Fichas_tecnicas_control : Form
    {
        
        public Fichas_tecnicas_control()
        {
            
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Fichas_tecnicas_control_Load(object sender, EventArgs e)
        {
            if (this.Text == "Modificar")
            {
                
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                aviosdao.id_ficha_avio = int.Parse(textBox1.Text);
                dataGridView1.DataSource = aviosdao.sacar_avios();
                DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                piezasdao.idficha = int.Parse(textBox1.Text);
                dataGridView2.DataSource = piezasdao.devuelvepiezasfichas();
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                acabadosdao.idficha = int.Parse(textBox1.Text);
                dataGridView4.DataSource = acabadosdao.acabados_fichas();
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao.idficha = int.Parse(textBox1.Text);
                dataGridView3.DataSource = procesosdao.verprocesosfichas();
                DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                fichadao.id_fichatecnica = int.Parse(textBox1.Text);
                dataGridView6.DataSource = fichadao.especificacionesficha();
                foreach (DataGridViewRow row in dataGridView6.Rows)
                {
                    richTextBox1.Text = row.Cells[2].Value.ToString();
                }
                calculatiempos();
            }

            if (this.Text == "Ficha Tecnica")
            {
                DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                fichadao.id_fichatecnica = int.Parse(textBox1.Text);
                dataGridView5.DataSource = fichadao.fichatecnicavista();
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    
                    tb_prenda.Text = Convert.ToString(row.Cells["nombre_prenda"].Value);
                    tb_molde.Text = Convert.ToString(row.Cells["modelo"].Value);
                    tb_tela.Text = Convert.ToString(row.Cells["tela"].Value);
                    tb_telaancho.Text = Convert.ToString(row.Cells["ancho_tela"].Value);
                    tb_telaconsumo.Text = Convert.ToString(row.Cells["consumo_tela"].Value);
                    textBox2.Text = Convert.ToString(row.Cells["nombre"].Value);
                    label23.Text = Convert.ToString(row.Cells["idclientes"].Value);
                    label22.Text = Convert.ToString(row.Cells["costo_minuto"].Value);
                    tb_combinacion.Text = Convert.ToString(row.Cells["combinacion"].Value);
                    
                    button1.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;
                    button12.Visible = false;
                    button13.Visible = false;
                    button14.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    button7.Visible = false;
                    button5.Enabled = false;
                    button9.Visible = false;

                    tb_combinacionancho.Text = Convert.ToString(row.Cells["ancho_tela_conbinacion"].Value);
                    tb_combinacionconsumo.Text = Convert.ToString(row.Cells["consumo_conbinacion"].Value);
                    tb_forro.Text = Convert.ToString(row.Cells["forro"].Value);
                    tb_forroancho.Text = Convert.ToString(row.Cells["ancho_tela_forro"].Value);
                    tb_forroconsumo.Text = Convert.ToString(row.Cells["consumo_forro"].Value);
                    rtb_observaciones.Text = Convert.ToString(row.Cells["especificacionescostura"].Value);
                    richTextBox1.Text = row.Cells["Especificaciones"].Value.ToString();
                    groupBox2.Visible = true;
                    button10.Visible = false;
                    
                }
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                aviosdao.id_ficha_avio = int.Parse(textBox1.Text);
                dataGridView1.DataSource = aviosdao.sacar_avios();
                DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                piezasdao.idficha = int.Parse(textBox1.Text);
                dataGridView2.DataSource = piezasdao.devuelvepiezasfichas();
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                acabadosdao.idficha = int.Parse(textBox1.Text);
                dataGridView4.DataSource = acabadosdao.acabados_fichas();
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao.idficha = int.Parse(textBox1.Text);
                dataGridView3.DataSource = procesosdao.verprocesosfichas();
                calculatiempos();
            }

        }

        public void actualizatextos()
        {
            DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
            fichadao.id_fichatecnica = int.Parse(textBox1.Text);
            dataGridView5.DataSource = fichadao.fichatecnicavista();
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {

                //tb_prenda.Text = Convert.ToString(row.Cells["nombre_prenda"].Value);
                //tb_molde.Text = Convert.ToString(row.Cells["modelo"].Value);
                //tb_tela.Text = Convert.ToString(row.Cells["tela"].Value);
                //tb_telaancho.Text = Convert.ToString(row.Cells["ancho_tela"].Value);
                //tb_telaconsumo.Text = Convert.ToString(row.Cells["consumo_tela"].Value);
                //textBox2.Text = Convert.ToString(row.Cells["nombre"].Value);
                //label23.Text = Convert.ToString(row.Cells["idclientes"].Value);
                //label22.Text = Convert.ToString(row.Cells["costo_minuto"].Value);
                //tb_combinacion.Text = Convert.ToString(row.Cells["combinacion"].Value);

                //button1.Visible = false;
                //button10.Visible = false;
                //button11.Visible = false;
                //button12.Visible = false;
                //button13.Visible = false;
                //button14.Visible = false;
                //button2.Visible = false;
                //button3.Visible = false;
                //button4.Visible = false;
                //button5.Visible = false;
                //button6.Visible = false;
                //button7.Visible = false;
                //button5.Enabled = false;
                //button9.Visible = false;

                //tb_combinacionancho.Text = Convert.ToString(row.Cells["ancho_tela_conbinacion"].Value);
                //tb_combinacionconsumo.Text = Convert.ToString(row.Cells["consumo_conbinacion"].Value);
                //tb_forro.Text = Convert.ToString(row.Cells["forro"].Value);
                //tb_forroancho.Text = Convert.ToString(row.Cells["ancho_tela_forro"].Value);
                //tb_forroconsumo.Text = Convert.ToString(row.Cells["consumo_forro"].Value);
                rtb_observaciones.Text = Convert.ToString(row.Cells["especificacionescostura"].Value);
                richTextBox1.Text = row.Cells["Especificaciones"].Value.ToString();
                //groupBox2.Visible = true;
                //button10.Visible = false;
                //DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                //aviosdao.id_ficha_avio = int.Parse(textBox1.Text);
                //dataGridView1.DataSource = aviosdao.sacar_avios();
                //DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                //piezasdao.idficha = int.Parse(textBox1.Text);
                //dataGridView2.DataSource = piezasdao.devuelvepiezasfichas();
                //DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                //acabadosdao.idficha = int.Parse(textBox1.Text);
                //dataGridView4.DataSource = acabadosdao.acabados_fichas();
                //DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                //procesosdao.idficha = int.Parse(textBox1.Text);
                //dataGridView3.DataSource = procesosdao.verprocesosfichas();
                
            }
            calculatiempos();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (((tb_tela.Text != "") | (tb_tela.Text != "0")) && ((tb_telaancho.Text != "") | (tb_telaancho.Text != "0")) && ((tb_telaconsumo.Text != "") | (tb_telaconsumo.Text != "0")))
            {
                int numero = 0;
                if ((tb_tela.Text != "") && (tb_telaancho.Text != "") && (tb_telaconsumo.Text != "") && (tb_molde.Text != "") && (textBox2.Text != ""))
                {
                    try
                    {

                        DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                        if (tb_telaancho.Text == "")
                        {
                            fichadao.anchotela = 0;
                        }
                        else
                        {
                            fichadao.anchotela = double.Parse(tb_telaancho.Text);
                        }
                        if (tb_combinacion.Text == "")
                        {
                            fichadao.combinacion = null;
                        }
                        else
                        {
                            fichadao.combinacion = tb_combinacion.Text;
                        }

                        if (tb_combinacionancho.Text == "")
                        {
                            fichadao.combinacionancho = 0;
                        }
                        else
                        {
                            fichadao.combinacionancho = double.Parse(tb_combinacionancho.Text);
                        }

                        if (tb_combinacionconsumo.Text == "")
                        {
                            fichadao.combinacionconsumo = 0;
                        }
                        else
                        {
                            fichadao.combinacionconsumo = double.Parse(tb_combinacionconsumo.Text);
                        }

                        if (tb_telaconsumo.Text == "")
                        {
                            fichadao.consumotela = 0;
                        }
                        else
                        {
                            fichadao.consumotela = double.Parse(tb_telaconsumo.Text);
                        }

                        if (tb_forro.Text == "")
                        {
                            fichadao.forro = null;
                        }
                        else
                        {
                            fichadao.forro = tb_forro.Text;
                        }

                        if (tb_forroancho.Text == "")
                        {
                            fichadao.forroancho = 0;
                        }
                        else
                        {
                            fichadao.forroancho = double.Parse(tb_forroancho.Text);
                        }

                        if (tb_forroconsumo.Text == "")
                        {
                            fichadao.forroconsumo = 0;
                        }
                        else
                        {
                            fichadao.forroconsumo = double.Parse(tb_forroconsumo.Text);
                        }

                        if (tb_forroconsumo.Text == "")
                        {
                            fichadao.forroconsumo = 0;
                        }
                        else
                        {
                            fichadao.forroconsumo = double.Parse(tb_forroconsumo.Text);
                        }





                        if (tb_molde.Text == "")
                        {
                            fichadao.modelo = null;
                        }
                        else
                        {
                            fichadao.modelo = tb_molde.Text;
                        }

                        if (tb_prenda.Text == "")
                        {
                            fichadao.nombreprenda = null;
                        }
                        else
                        {
                            fichadao.nombreprenda = tb_prenda.Text;
                        }

                        if (tb_tela.Text == "")
                        {
                            fichadao.tela = null;
                        }
                        else
                        {
                            fichadao.tela = tb_tela.Text;
                        }


                        if (this.Text != "Modificar")
                        {

                            fichadao.ingresadetalle();
                        }
                        else
                        {
                            fichadao.id_fichatecnica = int.Parse(textBox1.Text);
                            if (fichadao.actualizafichadetalle() == "Correcto")
                            {
                                groupBox1.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Error, no se actualizo la informacion");
                            }
                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("A habido algun error");
                        numero = 1;
                    }
                    finally
                    {
                        if (this.Text != "Modificar")
                        {
                            if (numero == 0)
                            {
                                DAO.Ficha_tecnicaDAO fichadao0 = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                                textBox1.Text = Convert.ToString(fichadao0.devuelveid());
                                fichadao0.id_fichatecnica = int.Parse(textBox1.Text);
                                if (tb_solicitud.Text == "")
                                {



                                    fichadao0.ficha_detalle = int.Parse(textBox1.Text);
                                    fichadao0.cliente = int.Parse(label23.Text);
                                    fichadao0.creafichaparcial();
                                    groupBox1.Enabled = false;
                                    groupBox2.Enabled = true;
                                    groupBox2.Visible = true;
                                }
                                else
                                {


                                    fichadao0.ficha_detalle = int.Parse(textBox1.Text);
                                    fichadao0.cliente = int.Parse(label23.Text);
                                    fichadao0.idsolicitud = int.Parse(tb_solicitud.Text);
                                    fichadao0.creaficha_parcialsolicitud();
                                    DAO.SolicitudesDAO solicitudesdao = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
                                    solicitudesdao.fecha = dateTimePicker1.Value;
                                    solicitudesdao.idsolicitud = int.Parse(tb_solicitud.Text);
                                    solicitudesdao.ingresafechasolicitud();
                                    solicitudesdao.establecerespondido();
                                    groupBox1.Enabled = false;
                                    groupBox2.Enabled = true;
                                    groupBox2.Visible = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cheque su informacion");
                            }
                        }
                        else
                        {
                            DAO.Ficha_tecnicaDAO fichadao0 = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                            fichadao0.id_fichatecnica = int.Parse(textBox1.Text);
                            fichadao0.cliente = int.Parse(label23.Text);
                            if (fichadao0.actualizaclienteficha() == "Correcto")
                            {
                                groupBox1.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show("Error, no se actualizo la informacion");
                            }
                            ;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese todos los datos minimos");
                }
            }
            else
            {
                MessageBox.Show("Es necesario ingresar como minimo los datos de la tela");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            GUI.Diseño.ClienteSeleccion clienteselecciongui = new ClienteSeleccion(this);
            clienteselecciongui.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Avios_seleccion aviosselecgui = new Avios_seleccion();
            aviosselecgui.label1.Text = textBox1.Text;
            aviosselecgui.ShowDialog();
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.id_ficha_avio = int.Parse(textBox1.Text);
            dataGridView1.DataSource = aviosdao.sacar_avios();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Piezas_seleccion piezasselecgui = new Piezas_seleccion();
            piezasselecgui.label1.Text = textBox1.Text;
            piezasselecgui.ShowDialog();
            DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
            piezasdao.idficha = int.Parse(textBox1.Text);
            dataGridView2.DataSource = piezasdao.devuelvepiezasfichas();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Operaciones_seleccion operacionesselectgui = new Operaciones_seleccion();
            operacionesselectgui.label1.Text = textBox1.Text;
            operacionesselectgui.ShowDialog();
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            procesosdao.idficha = int.Parse(textBox1.Text);
            dataGridView3.DataSource = procesosdao.verprocesosfichas();
            calculatiempos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Acabados_seleccion acabadosselectgui = new Acabados_seleccion();
            acabadosselectgui.label1.Text = textBox1.Text;
            acabadosselectgui.ShowDialog();
            DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
            acabadosdao.idficha = int.Parse(textBox1.Text);
            dataGridView4.DataSource = acabadosdao.acabados_fichas();
            calculatiempos();
        }

        //private void button8_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double sumatoria = 0;

        //        foreach (DataGridViewRow row in dataGridView3.Rows)
        //        {
        //            sumatoria += Convert.ToDouble(row.Cells["tiempo"].Value);
        //        }

        //        tb_tiempocostura.Text = Convert.ToString(sumatoria);


        //    }
        //    catch
        //    {
        //        MessageBox.Show("A habido un error en el calculo");
        //    }
        //    finally
        //    {
        //        double sumatoria = 0;

        //        foreach (DataGridViewRow row in dataGridView4.Rows)
        //        {
        //            sumatoria += Convert.ToDouble(row.Cells["tiempo_total"].Value);
        //        }

        //        tb_tiempoacabados.Text = Convert.ToString(sumatoria);
        //        button5.Visible = true;
        //    }
        //}

        private void calculatiempos()
        {
            try
            {
                double sumatoria = 0;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    sumatoria += Convert.ToDouble(row.Cells["tiempo"].Value);
                }

                tb_tiempocostura.Text = Convert.ToString(sumatoria);


            }
            catch
            {
                MessageBox.Show("A habido un error en el calculo");
            }
            finally
            {
                double sumatoria = 0;

                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    sumatoria += Convert.ToDouble(row.Cells["tiempo_total"].Value);
                }

                tb_tiempoacabados.Text = Convert.ToString(sumatoria);
                button5.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calculatiempos();
            if (tb_solicitud.Text == "")
            {
                try
                {
                    DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                    fichadao.costeo = ((Convert.ToDouble(tb_tiempoacabados.Text) + (Convert.ToDouble(tb_tiempocostura.Text))) * (Convert.ToDouble(label22.Text)));
                    fichadao.tiempo_acabados = Convert.ToDouble(tb_tiempoacabados.Text);
                    fichadao.tiempo_costuras = Convert.ToDouble(tb_tiempocostura.Text);
                    fichadao.id_fichatecnica = int.Parse(textBox1.Text);
                    fichadao.observaciones = rtb_observaciones.Text;
                    fichadao.especificaciones = richTextBox1.Text;
                    fichadao.ingresaespecificacionesficha();
                    MessageBox.Show(fichadao.actualizafichaparcial());
                    
                    this.Visible = false;
                    this.Close();
                    //GUI.Diseño.Fichas_tecnicas fichasgui = new Fichas_tecnicas();
                    //fichasgui.ShowDialog();
                    //fichasgui.BringToFront();

                }
                catch
                {
                    MessageBox.Show("A habido algun error, intente otra ves");
                }
            }
            else
            {
                try
                {
                    DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                    DAO.SolicitudesDAO solicitudesdao = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
                    fichadao.costeo = ((Convert.ToDouble(tb_tiempoacabados.Text) + (Convert.ToDouble(tb_tiempocostura.Text))) * (Convert.ToDouble(label22.Text)));
                    fichadao.tiempo_acabados = Convert.ToDouble(tb_tiempoacabados.Text);
                    fichadao.tiempo_costuras = Convert.ToDouble(tb_tiempocostura.Text);
                    fichadao.id_fichatecnica = int.Parse(textBox1.Text);
                    fichadao.observaciones = rtb_observaciones.Text;
                    fichadao.especificaciones = richTextBox1.Text;
                    fichadao.ingresaespecificacionesficha();
                    MessageBox.Show(fichadao.actualizafichaparcial());
                    solicitudesdao.idsolicitud = int.Parse(tb_solicitud.Text);
                    solicitudesdao.establecerespondido();

                    this.Visible = false;
                    this.Close();
                    

                }
                catch
                {
                    MessageBox.Show("A habido algun error, intente otra ves");
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (tb_solicitud.Text == "")
            {
                //GUI.Diseño.Fichas_tecnicas fichasgui = new Fichas_tecnicas();
                //fichasgui.Show();
                //fichasgui.BringToFront();
                this.Visible = false;
                this.Close();
            }
            else
            {
                this.Visible = false;
                this.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿De verdad desea eliminar esta ficha tecnica?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (tb_solicitud.Text == "")
                {
                    DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                    fichadao.id_fichatecnica = int.Parse(textBox1.Text);
                    MessageBox.Show(fichadao.borraficha());

                    this.Visible = false;
                    this.Close();
                }
                else
                {
                    DAO.Ficha_tecnicaDAO fichadao = new GrupoSM_Recepcion.DAO.Ficha_tecnicaDAO();
                    fichadao.id_fichatecnica = int.Parse(textBox1.Text);
                    MessageBox.Show(fichadao.borraficha());
                    this.Visible = false;
                    this.Close();

                }
            }
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            try
            {
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                aviosdao.idavios = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_avios"].Value);
                aviosdao.id_ficha_avio = int.Parse(textBox1.Text);
                aviosdao.borra_avioficha();
                DAO.AviosDAO aviosdao1 = new GrupoSM_Recepcion.DAO.AviosDAO();
                aviosdao1.id_ficha_avio = int.Parse(textBox1.Text);
                dataGridView1.DataSource = aviosdao1.sacar_avios();
            }
            catch
            {
                MessageBox.Show("Error, puede ser la coneccion, o no a seleccionado nada para borrar");
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                piezasdao.idficha = int.Parse(textBox1.Text);
                piezasdao.idpiezas = Convert.ToInt32(dataGridView2.CurrentRow.Cells["id_piezas"].Value);
                piezasdao.borra_piezaficha();
                DAO.PiezasDAO piezasdao1 = new GrupoSM_Recepcion.DAO.PiezasDAO();
                piezasdao1.idficha = int.Parse(textBox1.Text);
                dataGridView2.DataSource = piezasdao1.devuelvepiezasfichas();
            }
            catch
            {
                MessageBox.Show("Error, puede ser la coneccion, o no a seleccionado nada para borrar");
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao.idficha = int.Parse(textBox1.Text);
                procesosdao.idproceso = Convert.ToInt32(dataGridView3.CurrentRow.Cells["id_proceso"].Value);
                procesosdao.borra_procesoficha();
                DAO.ProcesosDAO procesosdao1 = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao1.idficha = int.Parse(textBox1.Text);
                dataGridView3.DataSource = procesosdao1.verprocesosfichas();
            }
            catch
            {
                MessageBox.Show("Error, puede ser la coneccion, o no a seleccionado nada para borrar");
            }
            calculatiempos();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                acabadosdao.idficha = int.Parse(textBox1.Text);
                acabadosdao.idacabados = Convert.ToInt32(dataGridView4.CurrentRow.Cells["id_acabados"].Value);
                acabadosdao.borra_acabadoficha();
                DAO.AcabadosDAO acabadosdao1 = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                acabadosdao1.idficha = int.Parse(textBox1.Text);
                dataGridView4.DataSource = acabadosdao1.acabados_fichas();
            }
            catch
            {
                MessageBox.Show("Error, puede ser la coneccion, o no a seleccionado nada para borrar");
            }
            calculatiempos();

        }

        private void rtb_observaciones_TextChanged(object sender, EventArgs e)
        {
            button5.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string resultado3 = rtb_observaciones.Text;
            resultado3 = Regex.Replace(resultado3, @"\s+", " ");
            rtb_observaciones.Text = resultado3;
            button5.Enabled = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Plantillas plantillasgui = new Plantillas();
            plantillasgui.lbl_idfichas.Text = textBox1.Text;
            plantillasgui.button1.Visible = false;
            plantillasgui.button2.Visible = false;
            plantillasgui.button3.Text= "Seleccionar";
            
            plantillasgui.ShowDialog();
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.id_ficha_avio = int.Parse(textBox1.Text);
            dataGridView1.DataSource = aviosdao.sacar_avios();
            DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
            piezasdao.idficha = int.Parse(textBox1.Text);
            dataGridView2.DataSource = piezasdao.devuelvepiezasfichas();
            DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
            acabadosdao.idficha = int.Parse(textBox1.Text);
            dataGridView4.DataSource = acabadosdao.acabados_fichas();
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            procesosdao.idficha = int.Parse(textBox1.Text);
            dataGridView3.DataSource = procesosdao.verprocesosfichas();
            calculatiempos();
            actualizatextos();
            
        }
    }
}
