using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Avios_Asignacion : Form
    {
        public Avios_Asignacion()
        {
            InitializeComponent();
        }

        private void Avios_Asignacion_Load(object sender, EventArgs e)
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.idproduccion = int.Parse(label6.Text);
            //aviosdao.id_ficha_avio = int.Parse(label7.Text);
            aviosdao.fecha = dateTimePicker1.Value;
            //aviosdao.verificaavios();

            dataGridView1.DataSource = aviosdao.devuelveaviosasignaciones();
            if (comboBox1.SelectedIndex >= 0)
            {
                

                aviosdao.tipo = comboBox1.SelectedIndex;

                dataGridView2.DataSource = aviosdao.buscatipobodega();
            }
            else
            {
                
                dataGridView2.DataSource = aviosdao.aviosbodega();
            }
        }

        public void actualizagridavios()
        {

            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.idproduccion = int.Parse(label6.Text);
            dataGridView1.DataSource = aviosdao.devuelveaviosasignaciones();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (double.Parse(textBox2.Text) <= double.Parse(textBox3.Text))
                {
                    if ((double.Parse(textBox4.Text) + double.Parse(textBox2.Text)) <= double.Parse(textBox1.Text))
                    {
                        DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                        aviosdao.idproduccion = int.Parse(label6.Text);
                        aviosdao.idavios = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Clave Avio"].Value);
                        aviosdao.cantidadasignada = ((double.Parse(textBox1.Text) - double.Parse(textBox4.Text)) - double.Parse(textBox2.Text));
                        aviosdao.cantidadbodega = - double.Parse(textBox2.Text);
                        aviosdao.iddetalle = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Clave avio produccion"].Value);
                        MessageBox.Show(aviosdao.actualizaavios_bodegaasignaciones());
                        
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox1.Text = "";
                        button1.Visible = false;
                        DAO.AviosDAO aviosdao1 = new GrupoSM_Recepcion.DAO.AviosDAO();
                        aviosdao1.idproduccion = int.Parse(label6.Text);
                        aviosdao1.id_ficha_avio = int.Parse(label7.Text);
                        DAO.AviosDAO aviosdao3 = new GrupoSM_Recepcion.DAO.AviosDAO();
                        aviosdao3.idproduccion = int.Parse(label6.Text);
                        aviosdao3.id_ficha_avio = int.Parse(label7.Text);
                        aviosdao3.fecha = dateTimePicker1.Value;
                        aviosdao3.verificaavios();
                        dataGridView1.DataSource = aviosdao1.devuelveaviosasignaciones();
                    }
                    else
                    {
                        MessageBox.Show("No puede ingresar mas avios de los necesarios");
                        
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox1.Text = "";
                        button1.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("No puede ingresar una cantidad mayor a la existente");
                    
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox1.Text = "";
                    button1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad");
                
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Text = "";
                button1.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }
        public void guardanumeroprendas()
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.idproduccion = int.Parse(label6.Text);
            aviosdao.Color = dataGridView1.CurrentRow.Cells["Color"].Value.ToString();
            label2.Text = aviosdao.numerocolorprendas().ToString();
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            guardanumeroprendas();
            textBox1.Text = Convert.ToString(double.Parse(label2.Text) * Convert.ToDouble(dataGridView1.CurrentRow.Cells["cantidad_ficha"].Value));
            textBox4.Text = Convert.ToString(double.Parse(textBox1.Text) - Convert.ToDouble(dataGridView1.CurrentRow.Cells["Cantidad necesaria"].Value));
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Cantidad bodega"].Value);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.idavios = int.Parse(dataGridView1.CurrentRow.Cells["Clave Avio"].Value.ToString());
            dataGridView2.DataSource = aviosdao.devuelveaviossubgruposcolor();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "¿" + "De verdad desea cambiar el avio base " + dataGridView1.CurrentRow.Cells[0].Value.ToString() + " por el avio " + dataGridView2.CurrentRow.Cells[1].Value.ToString() + "?" + " Tenga en cuenta que si esta incorrecto el avio tendra que reiniciar el estado de los avios para poder volver a intentarlo";
                DialogResult result = MessageBox.Show(mensaje, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                    aviosdao.idavios = int.Parse(dataGridView1.CurrentRow.Cells["Clave avio produccion"].Value.ToString());
                    aviosdao.iddetalle = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    aviosdao.Actualizaaviosproduccion();
                    actualizagridavios();
                }
            }
            catch
            {
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int comprobacion;
            DAO.AviosDAO aviosdao1 = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao1.idproduccion = int.Parse(label6.Text);
            comprobacion = aviosdao1.existe_produccionavios();
            if (comprobacion == 0)
            {
                MessageBox.Show("Es necesario primero guardar el listado de avios que se utilizaran en la prenda");

            }
            else
            {
                GUI.REPORTES.AviosProduccionImprimir aviosimpr = new GrupoSM_Recepcion.GUI.REPORTES.AviosProduccionImprimir();
                aviosimpr.idproduccion = int.Parse(label6.Text);
                //aviosimpr.idficha = int.Parse(label7.Text);
                aviosimpr.Show();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();

                aviosdao.tipo = comboBox1.SelectedIndex;

                dataGridView1.DataSource = aviosdao.buscatipobodega();
            }
            else
            {
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                dataGridView1.DataSource = aviosdao.aviosbodega();
            }
        }
    }
}
