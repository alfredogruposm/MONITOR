using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI
{
    public partial class MonitorAlertas : Form
    {
        //0//orden_produccion.asunto as 'Prenda',
        //1//orden_produccion.fecha_inicio as 'Entra Pedido',
        //2//orden_produccion.fecha_avios as 'Avios Completos',
        //3//orden_produccion.fecha_tela as 'Tela Completa',
        //4//orden_produccion.fecha_trazado_inicio as 'Se imprimio la hoja de corte',
        //5//orden_produccion.fecha_ruta as 'Rutas Establecidas',
        //6//orden_produccion.fecha_trazado_terminado as 'Empezo el trazado',
        //7//orden_produccion.fecha_tendido as 'Termina tendido',
        //8//orden_produccion.fecha_corte_inicio as 'Inicia Corte',
        //9//orden_produccion.fecha_corte_terminado as 'Termina Corte',
        //10//orden_produccion.fecha_separado_inicio as 'Inicio Separado',
        //11//orden_produccion.fecha_separado_terminado as 'Termina Separado',
        //12//orden_produccion.fecha_maquila_salida as 'Sale a maquila',
        //13//orden_produccion.fecha_maquila_entrada as 'Entrada Completa de Maquila',
        //14//orden_produccion.fecha_acabados_terminado as 'Acabados terminado'
        public MonitorAlertas()
        {
            InitializeComponent();
        }

        public void evaluaseleccionado()
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            DateTime fechaentrada = Convert.ToDateTime(row.Cells[1].Value);
            
            

            //DateTime d1 = DateTime.MinValue;
            //DateTime d2 = DateTime.MaxValue;
            //TimeSpan span = d2 - d1;
            //Console.WriteLine
            //         ("There're {0} days between {1} and {2}", span.TotalDays, d1.ToString(), d2.ToString());
            //TimeSpan spanentradaavios=fechaentrada - fechavios;
            try
            {
                try
                {
                    DateTime fechavios = Convert.ToDateTime(row.Cells[2].Value);
                    if ((fechavios - fechaentrada).Days <= 3)
                    {

                    }
                    else
                    {
                        dataGridView2.Rows.Add("Pasaron mas de 3 dias para ingresar los avios de esta prenda", (DateTime.Now.Date - fechaentrada).Days.ToString());
                    }
                }
                catch
                {
                    if ((DateTime.Now.Date - fechaentrada).Days <= 3)
                    {

                    }
                    else
                    {
                        dataGridView2.Rows.Add("Ya pasaron mas de 3 dias para ingresar los avios de esta prenda", (DateTime.Now.Date - fechaentrada).Days.ToString());
                    }
                }

                try
                {
                    DateTime fechatelas = Convert.ToDateTime(row.Cells[3].Value);
                    if ((fechatelas - fechaentrada).Days <= 3)
                    {

                    }
                    else
                    {
                        dataGridView2.Rows.Add("Pasaron mas de 3 dias para ingresar las telas de esta prenda", (DateTime.Now.Date - fechaentrada).Days.ToString());
                    }
                }
                catch
                {
                    if ((DateTime.Now.Date - fechaentrada).Days <= 3)
                    {

                    }
                    else
                    {
                        dataGridView2.Rows.Add("Ya pasaron mas de 3 dias para ingresar las telas de esta prenda", (DateTime.Now.Date - fechaentrada).Days.ToString());
                    }
                }

                try
                {
                    DateTime fechahojacorte = Convert.ToDateTime(row.Cells[4].Value);
                    if ((fechahojacorte - fechaentrada).Days <= 3)
                    {

                    }
                    else
                    {
                        dataGridView2.Rows.Add("Pasaron mas de 3 dias para ingresar los avios y las telas de esta prenda y sacar la hoja de corte", (DateTime.Now.Date - fechaentrada).Days.ToString());
                    }
                }
                catch
                {
                    if ((DateTime.Now.Date - fechaentrada).Days <= 3)
                    {

                    }
                    else
                    {
                        dataGridView2.Rows.Add("Ya pasaron mas de 3 dias para ingresar los avios y las telas de esta prenda y no se ha sacado la hoja de corte", (DateTime.Now.Date - fechaentrada).Days.ToString());
                    }
                }

                try
                {
                    DateTime fechaseparado = Convert.ToDateTime(row.Cells[11].Value), fechasalidamaquila = Convert.ToDateTime(row.Cells[12].Value);
                    if ((fechasalidamaquila - fechaseparado).Days <= 1)
                    {

                    }
                    else
                    {
                        dataGridView2.Rows.Add("Paso mas de 1 dia a partir de que se termino de separar la prenda y antes de la salida a maquila de la prenda", (DateTime.Now.Date - fechaseparado).Days.ToString());
                    }
                }
                catch
                {
                    DateTime fechaseparado = Convert.ToDateTime(row.Cells[11].Value);
                    if ((DateTime.Now.Date - fechaseparado).Days <= 1)
                    {

                    }
                    else
                    {
                        dataGridView2.Rows.Add("Ya paso mas de 1 dia a partir de que se termino de separar la prenda y antes de la salida a maquila de la prenda", (DateTime.Now.Date - fechaseparado).Days.ToString());
                    }
                }

                try
                {
                    DateTime fechaentradamaquila = Convert.ToDateTime(row.Cells[13].Value), fechaacabadosterminado = Convert.ToDateTime(row.Cells[14].Value);
                    if ((fechaacabadosterminado - fechaentradamaquila).Days <= 7)
                    {

                    }
                    else
                    {
                        dataGridView2.Rows.Add("Paso mas de una semana a partir de que entro la prenda de maquila y antes que se terminen los acabados", (DateTime.Now.Date - fechaentradamaquila).Days.ToString());
                    }
                }
                catch
                {
                    DateTime fechaentradamaquila = Convert.ToDateTime(row.Cells[13].Value);
                    if ((DateTime.Now.Date - fechaentradamaquila).Days <= 7)
                    {

                    }
                    else
                    {
                        dataGridView2.Rows.Add("Ya paso mas de una semana a partir de que entro la prenda de maquila y antes de el terminó de los acabados", (DateTime.Now.Date - fechaentradamaquila).Days.ToString());
                    }
                }
            }
            catch
            {
            }
        }

        public void evaluaactivos()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int control = 0;
                int numerorow = 0;
                try
                {
                    DateTime fechaentrada = Convert.ToDateTime(row.Cells[1].Value);

                    //DateTime d1 = DateTime.MinValue;
                    //DateTime d2 = DateTime.MaxValue;
                    //TimeSpan span = d2 - d1;
                    //Console.WriteLine
                    //         ("There're {0} days between {1} and {2}", span.TotalDays, d1.ToString(), d2.ToString());
                    //TimeSpan spanentradaavios=fechaentrada - fechavios;

                    try
                    {
                        DateTime fechavios = Convert.ToDateTime(row.Cells[2].Value);
                        if ((fechavios - fechaentrada).Days <= 3)
                        {
                            control = 0;
                        }

                    }
                    catch
                    {
                        if ((DateTime.Now.Date - fechaentrada).Days <= 3)
                        {
                            control = 0;
                        }
                        else
                        {
                            control = 1;
                        }
                    }

                    try
                    {
                        DateTime fechatelas = Convert.ToDateTime(row.Cells[3].Value);
                        if ((fechatelas - fechaentrada).Days <= 3)
                        {
                            control = 0;
                        }

                    }
                    catch
                    {
                        if ((DateTime.Now.Date - fechaentrada).Days <= 3)
                        {
                            control = 0;
                        }
                        else
                        {
                            control = 1;
                        }
                    }

                    try
                    {
                        DateTime fechahojacorte = Convert.ToDateTime(row.Cells[4].Value);
                        if ((fechahojacorte - fechaentrada).Days <= 3)
                        {
                            control = 0;
                        }

                    }
                    catch
                    {
                        if ((DateTime.Now.Date - fechaentrada).Days <= 3)
                        {
                            control = 0;
                        }
                        else
                        {
                            control = 1;
                        }
                    }

                    try
                    {
                        try
                        {
                            DateTime fechaseparado = Convert.ToDateTime(row.Cells[11].Value), fechasalidamaquila = Convert.ToDateTime(row.Cells[12].Value);
                            if ((fechasalidamaquila - fechaseparado).Days <= 1)
                            {
                                control = 0;
                            }

                        }
                        catch
                        {

                            DateTime fechaseparado = Convert.ToDateTime(row.Cells[11].Value);
                            if ((DateTime.Now.Date - fechaseparado).Days <= 1)
                            {
                                control = 0;
                            }
                            else
                            {
                                control = 1;
                            }
                        }

                        try
                        {
                            DateTime fechaentradamaquila = Convert.ToDateTime(row.Cells[13].Value), fechaacabadosterminado = Convert.ToDateTime(row.Cells[14].Value);
                            if ((fechaacabadosterminado - fechaentradamaquila).Days <= 7)
                            {
                                control = 0;
                            }

                        }
                        catch
                        {
                            DateTime fechaentradamaquila = Convert.ToDateTime(row.Cells[13].Value);
                            if ((DateTime.Now.Date - fechaentradamaquila).Days <= 7)
                            {
                                control = 0;
                            }
                            else
                            {
                                control = 1;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                catch
                {
                    control = 0;
                }
                if (control == 0)
                {
                    numerorow = row.Index;
                    dataGridView1.Rows.RemoveAt(numerorow);
                }
                
            }
        }

        public void iniciatodo()
        {
            //try
            //{
                DAO.Oden_ProduccionDAO ordengui = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                dataGridView1.DataSource = ordengui.vistamonitoractivos();
                evaluaactivos();

            //}
            //catch
            //{
            //    MessageBox.Show("Error de coneccion");
            //}
        }

        public void verificaabertura()
        {
            if (dataGridView1.Rows.Count < 1)
            {
                this.Hide();
                this.Close();
            }
        }

        private void MonitorAlertas_Load(object sender, EventArgs e)
        {
            iniciatodo();
            verificaabertura();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
            }
            catch
            {
            }
            
            evaluaseleccionado();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
            }
            catch
            {
            }

            evaluaseleccionado();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
