using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class AsignacionEmpleadosCostura : Form
    {
        public AsignacionEmpleadosCostura()
        {
            InitializeComponent();
        }

        private void AsignacionEmpleadosCostura_Load(object sender, EventArgs e)
        {
            calculahorasrestantes();
            cargaprocesosficha();
            obtienenumerodeprendas();
            agregaprocesostrabajo();
        }

        public void obtienenumerodeprendas()
        {
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            ordendao.idorden = (Convert.ToInt16(textBox1.Text));
            textBox4.Text = Convert.ToString(ordendao.devuelve_numeroprendas());
        }
        public void cargatrabajoempleados()
        {
            DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
            empleadosdao.IDProduccion = int.Parse(textBox1.Text);
            dataGridView2.DataSource = empleadosdao.devuelveempleadostrabajoproduccion1();
        }
        public void cargaempleados()
        {
            DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
            empleadosdao.IDProduccion = int.Parse(textBox1.Text);
            dataGridView1.DataSource = empleadosdao.devuelveempleadostrabajoproduccion();
            cargatrabajoempleados();
        }
        public void cargaprocesostrabajo()
        {
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            procesosdao.idproduccion = int.Parse(textBox1.Text);
            dataGridView3.DataSource = procesosdao.devuelveprocesostrabajoproduccion();
        }

        public void cargaprocesosficha()
        {
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            procesosdao.idficha = int.Parse(lblficha.Text);
            dataGridView4.DataSource = procesosdao.verprocesosfichas();
        }
        
        public void agregaprocesostrabajo()
        {
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao.idproduccion = int.Parse(textBox1.Text);
                procesosdao.idproceso = Convert.ToInt16(row.Cells[3].Value);
                procesosdao.cantidad = Convert.ToInt32(textBox4.Text);
                procesosdao.tiempototal = Convert.ToDecimal(row.Cells[2].Value) * Convert.ToDecimal(textBox4.Text);
                procesosdao.ingresaprocesostrabajo();
                

            }
        }
        public double devuelvehorasrestantes()
        {
            DateTime fechaactual = DateTime.Now;
            DateTime fechacambiada = fechaactual;
            double respuesta = -1;
            for (double i = 0; i == 25; i += 1)
            {

                // Hour gets 3. 
                int hour = fechacambiada.Hour;
                // Minute gets 57. 
                int minute = fechacambiada.Minute;
                if (hour >= 18)
                {

                    if (i == 0)
                    {
                        i = 25;
                        textBox6.Text = "##";
                        textBox6.ReadOnly = true;
                        respuesta = 0;
                    }
                    if (i == 1)
                    {
                        if (hour > 18)
                        {
                            i = 25;
                            textBox6.Text = "00:" + (60 - minute).ToString();
                            respuesta = 0;
                        }

                    }
                    else
                    {
                        if (i <= 10)
                        {
                            if (fechaactual.Hour <= 13)
                            {
                                if (minute < 30)
                                {
                                    int minutos = 30 - minute;
                                    i = i - (0.40);
                                    i -= double.Parse("0." + minutos.ToString());
                                    decimal minutos1 = decimal.Remainder(Convert.ToDecimal(i), decimal.Round(Convert.ToDecimal(i), 0));
                                    decimal horas = decimal.Round(Convert.ToDecimal(i), 0);
                                    respuesta = Convert.ToDouble(horas);
                                    textBox6.Text = horas.ToString() + ":" + minutos1.ToString();
                                    i = 25;

                                }
                                else
                                {
                                    minute -= 30;
                                    respuesta = i;
                                    textBox6.Text = i.ToString() + ":" + minute.ToString();
                                    i = 25;

                                }
                            }
                            else
                            {
                                respuesta = i;
                                textBox6.Text = i.ToString() + ":" + (60 - minute).ToString();
                                i = 25;

                            }

                        }
                        else
                        {
                            textBox6.Text = ("09:30");
                            i = 25;
                            respuesta = 9;
                        }

                    }

                }
                else
                {
                    fechacambiada = fechacambiada.AddHours(1);

                }
            }

            return respuesta;
        }
        public void calculahorasrestantes()
        {
            DateTime fechaactual=DateTime.Now;
            DateTime fechacambiada = fechaactual;
            for(double i=-1;i<=25;i++)
            {
                
                // Hour gets 3. 
                int hour = fechacambiada.Hour;
                // Minute gets 57. 
                int minute = fechacambiada.Minute;
                if(hour>=18)
                {

                    if (i == 0)
                    {
                        i = 25;
                        textBox6.Text = "##";
                        textBox6.ReadOnly = true;
                    }
                    if (i == 1)
                    {
                        if (hour > 18)
                        {
                            textBox6.Text = "00:" + (60 - minute).ToString();
                            i = 25;
                        }
                        
                    }
                    if ((i - 1) > 0)
                    {
                        if (i <= 10)
                        {
                            if (fechaactual.Hour <= 13)
                            {
                                if (minute < 30)
                                {
                                    int minutos = 30 - minute;
                                    i = i - (0.40);
                                    i -= double.Parse("0." + minutos.ToString());
                                    decimal minutos1 = decimal.Remainder(Convert.ToDecimal(i), decimal.Round(Convert.ToDecimal(i), 0));
                                    decimal horas = decimal.Round(Convert.ToDecimal(i), 0);
                                    textBox6.Text = horas.ToString() + ":" + minutos1.ToString();
                                    i = 25;
                                }
                                else
                                {
                                    minute -= 30;

                                    textBox6.Text = i.ToString() + ":" + minute.ToString();
                                    i = 25;
                                }
                            }
                            else
                            {
                                textBox6.Text = i.ToString() + ":" + (60 - minute).ToString();
                                i = 25;
                            }

                        }
                        else
                        {
                            textBox6.Text = ("09:30");
                            i = 25;
                        }
                        
                    }
                    
                }
                if (hour < 18)
                {
                    fechacambiada = fechacambiada.AddHours(1);
                }
            }
            
            
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Bodega.SeleccionarEmpleado selecciongui = new SeleccionarEmpleado();
            selecciongui.lblidproduccion.Text = textBox1.Text;
            selecciongui.cargaempleados();
            selecciongui.ShowDialog();
            cargaempleados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                

                if (dateTimePicker1.Value.Date == DateTime.Now.Date)
                {
                    double cantidaddevces, tiempototal, tiempounitario = (Convert.ToDouble(dataGridView3.CurrentRow.Cells[3].Value) / Convert.ToDouble(dataGridView3.CurrentRow.Cells[2].Value));
                    if (textBox5.Text != "")
                    {
                        cantidaddevces = double.Parse(textBox5.Text);
                        tiempototal = (cantidaddevces * tiempounitario) / 60;
                    }
                    else
                    {

                        cantidaddevces = Convert.ToDouble(dataGridView3.CurrentRow.Cells[2].Value);

                        tiempototal = (cantidaddevces * tiempounitario) / 60;
                    }
                    DialogResult result = MessageBox.Show("Quiere asignarle a " + (dataGridView1.CurrentRow.Cells[1].Value.ToString()) + " el proceso " + dataGridView3.CurrentRow.Cells[1].Value.ToString() + " la cantidad de " + cantidaddevces.ToString() + " veces para la fecha" + dateTimePicker1.Value.Date.ToShortDateString() + "Le tomara " + decimal.Round(Convert.ToDecimal(tiempototal), 2).ToString() + " horas", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        //this.idempleados, this.IDProduccion, this.IDProceso, this.fechainicio, this.fechaterminado, this.Cantidad, this.Tiempoesperado, this.Porcentaje);
                        DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
                        empleadosdao.idempleados = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        empleadosdao.IDProduccion = int.Parse(textBox1.Text);
                        empleadosdao.IDProceso = Convert.ToInt32(dataGridView3.CurrentRow.Cells[4].Value);
                        empleadosdao.fechainicio = DateTime.Now;
                        empleadosdao.Cantidad = Convert.ToDecimal(cantidaddevces);
                        empleadosdao.fechaterminado = dateTimePicker1.Value.Date;
                        empleadosdao.Tiempoesperado = Convert.ToDecimal(tiempototal);
                        string resultado = empleadosdao.insertaempleadosproduccionmaquila();
                        if (resultado == "Correcto")
                        {
                            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                            procesosdao.idproceso = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                            procesosdao.cantidad = Convert.ToDecimal(dataGridView3.CurrentRow.Cells[2].Value) - Convert.ToDecimal(cantidaddevces);
                            procesosdao.tiempototal = Convert.ToDecimal(dataGridView3.CurrentRow.Cells[3].Value) - Convert.ToDecimal(tiempototal*60);
                            string resultado2 = procesosdao.actualizaprocesostrabajo();
                            if (resultado2 == "Correcto")
                            {
                                cargaprocesostrabajo();
                                cargatrabajoempleados();
                            }
                            else
                            {
                                MessageBox.Show(resultado2);
                            }
                        }
                    }

                }
                else
                {
                    double cantidaddevces, tiempototal, tiempounitario = (Convert.ToDouble(dataGridView3.CurrentRow.Cells[3].Value) / Convert.ToDouble(dataGridView3.CurrentRow.Cells[2].Value));
                    if (textBox5.Text != "")
                    {
                        cantidaddevces = double.Parse(textBox5.Text);
                        tiempototal = (cantidaddevces * tiempounitario) / 60;
                    }
                    else
                    {

                        cantidaddevces = Convert.ToDouble(dataGridView3.CurrentRow.Cells[2].Value);

                        tiempototal = (cantidaddevces * tiempounitario) / 60;
                    }
                    DialogResult result = MessageBox.Show("Quiere asignarle a " + (dataGridView2.CurrentRow.Cells[1].Value.ToString()) + " el proceso " + dataGridView3.CurrentRow.Cells[1].Value.ToString() + " la cantidad de " + cantidaddevces.ToString() + " veces para la fecha " + dateTimePicker1.Value.Date.ToString() + " Le tomara " + tiempototal.ToString() + " horas", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        //this.idempleados, this.IDProduccion, this.IDProceso, this.fechainicio, this.fechaterminado, this.Cantidad, this.Tiempoesperado, this.Porcentaje);
                        DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
                        empleadosdao.idempleados = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        empleadosdao.IDProduccion = int.Parse(textBox1.Text);
                        empleadosdao.IDProceso = Convert.ToInt32(dataGridView3.CurrentRow.Cells[4].Value);
                        empleadosdao.fechainicio = DateTime.Now;
                        empleadosdao.Cantidad = Convert.ToDecimal(cantidaddevces);
                        empleadosdao.Tiempoesperado = Convert.ToDecimal(tiempototal);
                        string resultado = empleadosdao.insertaempleadosproduccionmaquila();
                        if (resultado == "Correcto")
                        {
                            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                            procesosdao.idproceso = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                            procesosdao.cantidad = Convert.ToDecimal(dataGridView3.CurrentRow.Cells[2].Value) - Convert.ToDecimal(cantidaddevces);
                            procesosdao.tiempototal = Convert.ToDecimal(dataGridView3.CurrentRow.Cells[3].Value) - Convert.ToDecimal(tiempototal);
                            string resultado2 = procesosdao.actualizaprocesostrabajo();
                            if (resultado2 == "Correcto")
                            {
                                cargaprocesostrabajo();
                                cargatrabajoempleados();
                            }
                            else
                            {
                                MessageBox.Show(resultado2);
                            }
                        }
                    }
                }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }
        

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        public DateTime devuelvefechatrabajoterminado()
        {
            DateTime respuesta;
            respuesta = Convert.ToDateTime(((dateTimePicker1.Value.ToShortDateString() + dateTimePicker3.Value.ToShortTimeString())));
            return respuesta;

        }

        public decimal porcentajedetrabajo(int tiempoesperado, DateTime fechaterminado, DateTime fechainiciado)
        {
            decimal respuesta=0;
            TimeSpan difference = fechainiciado - fechaterminado;
            respuesta += difference.Hours;
            respuesta += difference.Minutes / 60;
            decimal porcentaje = 0;
            return porcentaje = (respuesta / 100) * tiempoesperado;
        }
        public void limpiatextos()
        {
            lbltrabajo.Text = "";
            lbltiempoesperado.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {

            DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
            empleadosdao.IDProduccionporcentajes = Convert.ToInt16(lbltrabajo.Text);
            empleadosdao.fechaterminado = devuelvefechatrabajoterminado();
            empleadosdao.Porcentaje = porcentajedetrabajo(Convert.ToInt16(lbltiempoesperado.Text), devuelvefechatrabajoterminado(), Convert.ToDateTime(textBox10.Text));
            string respuesta = empleadosdao.actualizaempleadosproduccionmaquila();
            if (respuesta != "Correcto")
            {
                MessageBox.Show(respuesta);
            }
            else
            {
                MessageBox.Show(respuesta);
                limpiatextos();
                cargatrabajoempleados();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            textBox9.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            lbltrabajo.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            lbltiempoesperado.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            
        }
        
    }
}
