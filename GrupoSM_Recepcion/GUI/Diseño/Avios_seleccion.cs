using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Avios_seleccion : Form
    {
        
        public Avios_seleccion()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Text == "Avios Plantilla")
            {
                if (textBox2.Text != "")
                {
                    DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                    aviosdao.idplantilla = int.Parse(label1.Text);
                    aviosdao.idavios = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_avios"].Value);
                    aviosdao.cantidad = Convert.ToDouble(textBox2.Text);
                    aviosdao.costo = Math.Round(((Convert.ToDouble(dataGridView1.CurrentRow.Cells["precio"].Value)) * (Convert.ToDouble(textBox2.Text))), 2);
                    MessageBox.Show(aviosdao.insertaaviosplantilla());
                    this.Visible = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ponga una cantidad");
                }
            }
            else
            {
                if (textBox2.Text != "")
                {
                    DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                    aviosdao.id_ficha_avio = int.Parse(label1.Text);
                    aviosdao.idavios = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_avios"].Value);
                    aviosdao.cantidad = Convert.ToDouble(textBox2.Text);
                    aviosdao.costo = ((Convert.ToDouble(dataGridView1.CurrentRow.Cells["precio"].Value)) * (Convert.ToDouble(textBox2.Text)));
                    MessageBox.Show(aviosdao.agregar_detalle());
                    this.Visible = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ponga una cantidad");
                }
            }
        }

        private void Avios_seleccion_Load(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();

                aviosdao.tipo = comboBox1.SelectedIndex;

                dataGridView1.DataSource = aviosdao.busca_aviosportipobase();
            }
            else
            {
                DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                dataGridView1.DataSource = aviosdao.devuelveaviostipobase();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();

                    aviosdao.tipo = comboBox1.SelectedIndex;

                    dataGridView1.DataSource = aviosdao.busca_aviosportipobase();
                }
                else
                {
                    DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
                    dataGridView1.DataSource = aviosdao.devuelveaviostipobase();
                }
            }
            catch
            {
                MessageBox.Show("Por favor, escoja una categoria");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Bodega.AviosControl aviosgui = new GrupoSM_Recepcion.GUI.Bodega.AviosControl();
            
            
            aviosgui.textBox2.Text = "0";
            aviosgui.textBox3.Text = "0";
            aviosgui.textBox2.Enabled = false;
            aviosgui.textBox3.Enabled = false;
            aviosgui.checkBox1.Checked = true;
            aviosgui.checkBox1.Enabled = false;

            aviosgui.ShowDialog();
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            if (comboBox1.SelectedIndex != -1)
            {
                aviosdao.tipo = comboBox1.SelectedIndex + 14;
                dataGridView1.DataSource = aviosdao.buscatipobodega();
            }
            else
            {
                dataGridView1.DataSource = aviosdao.aviosbodega();
            }
            
        }
    }
}
