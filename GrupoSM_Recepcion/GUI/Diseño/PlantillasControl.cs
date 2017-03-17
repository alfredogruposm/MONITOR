using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class PlantillasControl : Form
    {
        public PlantillasControl()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.Text != "PlantillasControl")
            {
                if (tb_prenda.Text != "")
                {
                    DAO.PlantillasDAO plantillasdao = new GrupoSM_Recepcion.DAO.PlantillasDAO();
                    plantillasdao.nombre = tb_prenda.Text;
                    string resultado = plantillasdao.insertaplantilla();
                    if (resultado == "Correcto")
                    {
                        DAO.PlantillasDAO plantillas1dao = new GrupoSM_Recepcion.DAO.PlantillasDAO();
                        textBox1.Text = plantillas1dao.numeroplantilla().ToString();
                        //groupBox2.Visible = true;
                        //button6.Visible = false;
                        guardatodoplantilla();
                        guardatextos();
                        this.Visible = false;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el nombre primero");
                }
            }
            else
            {
                if (textBox1.Text != "")
                {
                    DAO.PlantillasDAO plantillasdao = new GrupoSM_Recepcion.DAO.PlantillasDAO();
                    plantillasdao.idplantilla = int.Parse(textBox1.Text);
                    plantillasdao.nombre = tb_prenda.Text;
                    string resultado = plantillasdao.modificaplantilla();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        button6.Visible = false;
                    }
                }
                else
                {

                    if (tb_prenda.Text != "")
                    {
                        DAO.PlantillasDAO plantillasdao = new GrupoSM_Recepcion.DAO.PlantillasDAO();
                        plantillasdao.nombre = tb_prenda.Text;
                        string resultado = plantillasdao.insertaplantilla();
                        if (resultado == "Correcto")
                        {
                            DAO.PlantillasDAO plantillas1dao = new GrupoSM_Recepcion.DAO.PlantillasDAO();
                            textBox1.Text = plantillas1dao.numeroplantilla().ToString();
                            groupBox2.Visible = true;
                            button6.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese el nombre primero");
                    }
                }
            }
        }
        public void guardatodoplantilla()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                    aviosdao.idplantilla = int.Parse(textBox1.Text);
                    aviosdao.idavios = Convert.ToInt32(row.Cells[0].Value);
                    aviosdao.cantidad = Convert.ToDouble(row.Cells[2].Value);
                    aviosdao.costo = Convert.ToDouble(row.Cells[3].Value);
                    aviosdao.insertaaviosplantilla();
                                       
                }
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                    piezasdao.cantidad = Convert.ToInt32(row.Cells[2].Value);
                    piezasdao.idplantilla = int.Parse(textBox1.Text);
                    piezasdao.idpiezas = Convert.ToInt32(row.Cells[0].Value);
                    piezasdao.ingresaplantillapiezas();
                }
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                    procesosdao.idproceso = Convert.ToInt32(row.Cells[0].Value);
                    procesosdao.idplantilla = int.Parse(textBox1.Text);
                    procesosdao.insertaprocesosplantilla();
                }
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                    acabadosdao.idplantilla = int.Parse(textBox1.Text);
                    acabadosdao.idacabados = Convert.ToInt32(row.Cells[0].Value);
                    acabadosdao.cantidad = Convert.ToDouble(row.Cells[2].Value);
                    acabadosdao.tiempototal = Convert.ToInt32(row.Cells[3].Value);
                    acabadosdao.ingresaacabadosplantilla();
                }
            }
            catch
            {
                MessageBox.Show("Error de agregacion de las piezas, avios, acabados o procesos");
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Avios_seleccion aviosselecgui = new Avios_seleccion();
            aviosselecgui.label1.Text = textBox1.Text;
            aviosselecgui.Text = "Avios Plantilla";
            aviosselecgui.ShowDialog();
            actualizaavios();
            
        }

        public void actualizaavios()
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.idplantilla = int.Parse(textBox1.Text);
            dataGridView1.DataSource = aviosdao.devuelveplantillaavios();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                aviosdao.idavios = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                aviosdao.idplantilla = int.Parse(textBox1.Text);
                aviosdao.eliminaaviosplantilla();
                actualizaavios();
            }
            catch
            {
                MessageBox.Show("Error, puede ser la coneccion, o no a seleccionado nada para borrar");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Piezas_seleccion piezasselecgui = new Piezas_seleccion();
            piezasselecgui.label1.Text = textBox1.Text;
            piezasselecgui.Text = "Piezas Plantilla";
            piezasselecgui.ShowDialog();
            actualizapiezas();
        }

        public void actualizapiezas()
        {
            DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
            piezasdao.idplantilla = int.Parse(textBox1.Text);
            dataGridView2.DataSource = piezasdao.devuelvepiezasplantilla();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                piezasdao.idplantilla = int.Parse(textBox1.Text);
                piezasdao.idpiezas = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                piezasdao.eliminapiezasplantilla();
                actualizapiezas();
            }
            catch
            {
                MessageBox.Show("Error, puede ser la coneccion, o no a seleccionado nada para borrar");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Acabados_seleccion acabadosselectgui = new Acabados_seleccion();
            acabadosselectgui.label1.Text = textBox1.Text;
            acabadosselectgui.Text = "Acabados Plantilla";
            acabadosselectgui.ShowDialog();
            actualizaacabados();
        }

        public void actualizaacabados()
        {
            DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
            acabadosdao.idplantilla = int.Parse(textBox1.Text);
            dataGridView4.DataSource = acabadosdao.devuelveacabadosplantilla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Operaciones_seleccion operacionesselectgui = new Operaciones_seleccion();
            operacionesselectgui.label1.Text = textBox1.Text;
            operacionesselectgui.Text = "Operaciones Plantilla";
            operacionesselectgui.ShowDialog();
            actualizaoperaciones();
        }

        public void actualizaoperaciones()
        {
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            procesosdao.idplantilla = int.Parse(textBox1.Text);
            dataGridView3.DataSource = procesosdao.devuelveplantillaprocesos();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao.idplantilla = int.Parse(textBox1.Text);
                procesosdao.idproceso = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                procesosdao.eliminaprocesosplantilla();
                actualizaoperaciones();
                
            }
            catch
            {
                MessageBox.Show("Error, puede ser la coneccion, o no a seleccionado nada para borrar");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                acabadosdao.idplantilla = int.Parse(textBox1.Text);
                acabadosdao.idacabados = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
                acabadosdao.eliminaplantillaacabados();
                actualizaacabados();
            }
            catch
            {
                MessageBox.Show("Error, puede ser la coneccion, o no a seleccionado nada para borrar");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                    aviosdao.id_ficha_avio = int.Parse(lbl_idfichas.Text);
                    aviosdao.idavios = Convert.ToInt32(row.Cells[0].Value);
                    aviosdao.cantidad = Convert.ToDouble(row.Cells[2].Value);
                    aviosdao.costo = Convert.ToDouble(row.Cells[3].Value);
                    aviosdao.agregar_detalle();
                }
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                    piezasdao.cantidad = Convert.ToInt32(row.Cells[2].Value);
                    piezasdao.idficha = int.Parse(lbl_idfichas.Text);
                    piezasdao.idpiezas = Convert.ToInt32(row.Cells[0].Value);
                    piezasdao.insertadetalle();
                }
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                    procesosdao.idproceso = Convert.ToInt32(row.Cells[0].Value);
                    procesosdao.idficha = int.Parse(lbl_idfichas.Text);
                    procesosdao.ingresadetalle();
                }
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                    acabadosdao.idficha = int.Parse(lbl_idfichas.Text);
                    acabadosdao.idacabados = Convert.ToInt32(row.Cells[0].Value);
                    acabadosdao.cantidad = Convert.ToDouble(row.Cells[2].Value);
                    acabadosdao.tiempototal = Convert.ToInt32(row.Cells[3].Value);
                    acabadosdao.insertadetalle();
                }
            }
            catch
            {
                MessageBox.Show("Error de agregacion");
            }
            finally
            {
                actualizatextos();
                DAO.PlantillasDAO plantillasdao = new GrupoSM_Recepcion.DAO.PlantillasDAO();
                plantillasdao.idfichatecnica = int.Parse(lbl_idfichas.Text);
                plantillasdao.observaciones = rtb_observaciones.Text;
                plantillasdao.especificaciones = richTextBox1.Text;
                plantillasdao.actualizaespecificacionesfichatecnica();
                this.Visible = false;
                this.Close();
            }
        }

        private void tb_prenda_TextChanged(object sender, EventArgs e)
        {
            button6.Visible = true;
        }

        private void PlantillasControl_Load(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                actualizaacabados();
                actualizaavios();
                actualizaoperaciones();
                actualizapiezas();
                actualizatextos();
            }
            if (this.Text != "PlantillasControl")
            {
                actualizaacabados();
                actualizaavios();
                actualizaoperaciones();
                actualizapiezas();
                actualizatextos();
                textBox1.Text = "";
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
                button7.Visible = false;
                tb_prenda.Text = "";
            }
        }

        

        public void actualizatextos()
        {
            try
            {

                DAO.PlantillasDAO plantillasdao = new GrupoSM_Recepcion.DAO.PlantillasDAO();
                plantillasdao.idplantilla = int.Parse(textBox1.Text);
                dataGridView1.DataSource = plantillasdao.devuelveespecificacionesplant();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    rtb_observaciones.Text = row.Cells[0].Value.ToString();
                    richTextBox1.Text = row.Cells[1].Value.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Error de carga de datos de texto");
            }
            finally
            {
                actualizaavios();
            }
        }
        public void guardatextos()
        {
            try
            {
                DAO.PlantillasDAO plantillasdao = new GrupoSM_Recepcion.DAO.PlantillasDAO();
                plantillasdao.idplantilla = int.Parse(textBox1.Text);
                plantillasdao.observaciones = rtb_observaciones.Text;
                plantillasdao.especificaciones = richTextBox1.Text;
                string resultado = plantillasdao.insertaespecificacionesplant();
                if (resultado != "Correcto")
                {
                    MessageBox.Show(resultado);
                }
                else
                {
                    button7.Visible = true;
                }
            }
            catch
            {

            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            guardatextos();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button7.Visible = true;
        }

        private void rtb_observaciones_TextChanged(object sender, EventArgs e)
        {
            button7.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    
    
    
    
    
    }
}
