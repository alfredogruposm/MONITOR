using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Entrada_maquila : Form
    {
        public Entrada_maquila()
        {
            InitializeComponent();
        }

        private void Entrada_maquila_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
            DAO.SalidasMaquilaDAO salidasdao=new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
            salidasdao.idproduccion=int.Parse(textBox3.Text);
            dataGridView1.DataSource = salidasdao.prendas_entrada_cotejo();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Cantidad Enviada"].Value);
            label5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ID"].Value);
            if ((Convert.ToString(dataGridView1.CurrentRow.Cells["Cantidad Recibida"].Value)) != "")
            {
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Cantidad Recibida"].Value);
            }
            else
            {
                textBox1.Text = "0";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double sumatoria=0, sumatoria2=double.Parse(textBox5.Text);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    sumatoria += Convert.ToDouble(row.Cells["Cantidad Enviada"].Value);
                }
                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((Convert.ToString(row.Cells["Cantidad Recibida"].Value)) != "")
                    {
                        sumatoria2 += Convert.ToDouble(row.Cells["Cantidad Recibida"].Value);
                    }
                }

                

                if (sumatoria2 <= sumatoria)
                {
                    DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
                    
                    
                    producciondao.id_produccion_detalle = int.Parse(label5.Text);
                    producciondao.cantidad_prendas_final = int.Parse(textBox5.Text) + int.Parse(textBox1.Text);
                    producciondao.actualiza_entradatelas(); 
                    DAO.SalidasMaquilaDAO salidasdao = new GrupoSM_Recepcion.DAO.SalidasMaquilaDAO();
                    salidasdao.idproduccion = int.Parse(textBox3.Text);
                    dataGridView1.DataSource = salidasdao.prendas_entrada_cotejo();
                    if (int.Parse(textBox5.Text) < 0)
                    {
                        int i=0;
                        do
                        {
                            i += 1;
                        }while(i+int.Parse(textBox5.Text) <= 0);
                        salidasdao.prendas_recibidas = i-1;
                        salidasdao.ingresa_devoluciones();
                    }
                    
                    textBox4.Text = "";
                    label5.Text = "";
                    textBox1.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    MessageBox.Show("No se pueden ingresar mas telas de las que salieron en total");
                }
            }
            catch
            {
                MessageBox.Show("No a seleccionado una tela");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sumatoria = 0, sumatoria2 = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sumatoria += Convert.ToDouble(row.Cells["Cantidad Enviada"].Value);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sumatoria2 += Convert.ToDouble(row.Cells["Cantidad Recibida"].Value);
            }

            if ((sumatoria == sumatoria2)&&(sumatoria!=0))
            {
                DAO.Oden_ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                producciondao.idorden = int.Parse(textBox3.Text);
                MessageBox.Show(producciondao.termina_maquilaprendas());
            }
            else
            {
                MessageBox.Show("No a terminado de ingresar las prendas");
            }


        }
    }
}
