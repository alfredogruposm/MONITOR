using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class Orden_Produccion : Form
    {
        public Orden_Produccion()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.Seleccionar_ClienteOrden seleccionarcliente = new Seleccionar_ClienteOrden(this);
            seleccionarcliente.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox11.Text != "") && (textBox10.Text != ""))
            {
                //try
                //{
                    
                    groupBox2.Visible = true;
                    groupBox1.Enabled = false;
                //}
                //catch
                //{
                //    MessageBox.Show("A habido algun error");
                //}
                //finally
                //{
                    
                    //try
                    //{
                        
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("A habido algun error");
                //    }
        
                //}
            }
            else
            {
                MessageBox.Show("Por favor, escoja un cliente y especifique el asunto");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int verifica = 3;
            GUI.Recepcion.Ficha_busqueda fichabusquedagui = new Ficha_busqueda(this);
            fichabusquedagui.ShowDialog();
            if (textBox4.Text == "")
            {

                if (textBox3.Text != "")
                {
                    DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    ordendao.asunto = textBox10.Text;
                    ordendao.idcliente = int.Parse(label7.Text);
                    verifica = ordendao.ingresaordenparcial();
                    DAO.Oden_ProduccionDAO ordenproducciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    textBox4.Text = Convert.ToString(ordenproducciondao.devuelveid_max());
                    DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                    producciondao.idficha = int.Parse(textBox3.Text);
                    producciondao.idorden = int.Parse(textBox4.Text);
                    verifica = producciondao.ingresa_produccionparcial();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            
                GUI.Recepcion.Agregar_Tallas agregartallasgui = new Agregar_Tallas(this);
                agregartallasgui.label_orden.Text = textBox4.Text;
                agregartallasgui.label_consumo.Text = textBox2.Text;
                agregartallasgui.lbl_combinacion.Text = label9.Text;
                agregartallasgui.lbl_tela.Text = label8.Text;
                agregartallasgui.ShowDialog();
            
            
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                producciondao.id_produccion = int.Parse(textBox4.Text);
                producciondao.borraorden();
                this.Visible = false;
                this.Close();
                
            }
            catch
            {
                this.Visible = false;
                this.Close();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                DialogResult result = MessageBox.Show("¿Desea terminar sin haber indicado ninguna observacion?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                    ordendao.idorden = int.Parse(textBox4.Text);
                    ordendao.fechainicio = dateTimePicker1.Value;
                    ordendao.actualizafechainicio();
                    this.Visible = false;
                    this.Close();
                }
            }
            else
            {
                DAO.Oden_ProduccionDAO ordendao=new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                ordendao.idorden = int.Parse(textBox4.Text);
                ordendao.fechainicio = dateTimePicker1.Value;
                ordendao.actualizafechainicio();
                ordendao.observaciones = richTextBox1.Text;
                MessageBox.Show(ordendao.actualizaobservacion());
                this.Visible = false;
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                producciondao.color = Convert.ToString(dataGridView1.CurrentRow.Cells["color"].Value);
                producciondao.talla = Convert.ToString(dataGridView1.CurrentRow.Cells["talla"].Value);
                producciondao.id_produccion = int.Parse(textBox4.Text);
                producciondao.eliminatallacolor();
                dataGridView1.DataSource = producciondao.tallas_preliminaresproduccion();
            }
            catch
            {
                MessageBox.Show("Escoja una entrada para eliminar");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string resultado = textBox10.Text;
            resultado = Regex.Replace(resultado, @"\s+", " ");
            textBox10.Text = resultado;
        }
    }
}
