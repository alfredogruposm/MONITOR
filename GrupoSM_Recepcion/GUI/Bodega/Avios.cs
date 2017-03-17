using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Avios : Form
    {
        public Avios()
        {
            InitializeComponent();
        }

        private void Avios_Load(object sender, EventArgs e)
        {
            actualizatabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        public void actualizatabla()
        {
            if (label1.Text == "Catalogo avios")
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    DAO.AviosDAO aviosdao = new DAO.AviosDAO();

                    aviosdao.tipo = comboBox1.SelectedIndex;

                    dataGridView1.DataSource = aviosdao.busca_aviosportipobase();
                }
                else
                {
                    DAO.AviosDAO aviosdao = new DAO.AviosDAO();
                    dataGridView1.DataSource = aviosdao.devuelveaviostipobase();
                }
            }
            else
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    DAO.AviosDAO aviosdao = new DAO.AviosDAO();

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

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Bodega.AviosControl aviosgui = new AviosControl();
            if (label1.Text == "Catalogo avios")
            {
                aviosgui.textBox3.Enabled = false;
                aviosgui.textBox3.Text = "0";
            }
            
            aviosgui.ShowDialog();
            actualizatabla();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Bodega.AviosControl aviosgui = new AviosControl();
                aviosgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                
                //aviosgui.comboBox1.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells["tipo"].Value);
                
                //if (label1.Text != "Catalogo avios")
              //  {
               //     aviosgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["precio"].Value);
              //      aviosgui.textBox3.Text = "0";
              //      aviosgui.textBox3.Enabled = false;

                    
             //   }
             //   else
            //    {
                    aviosgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["precio"].Value);
                    aviosgui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["cantidad"].Value);
                    aviosgui.label6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idaviosbodega"].Value);
                    aviosgui.textBox3.Enabled = true;
              //  }
                aviosgui.label4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_avios"].Value);
                
                aviosgui.ShowDialog();
                actualizatabla();
            }
            catch
            {
                MessageBox.Show("Seleccione un avio");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
                actualizatabla();
            //}
            //catch
            //{
            //    MessageBox.Show("Por favor, escoja una categoria");
            //}
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex == 0)
            //{
            //    campo = "nombre_prenda";
            //}
            //else
            //{
            //    campo = "modelo";
            //}
            string campo = "nombre";
            
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            
            DataView dv;
            if (label1.Text == "Catalogo avios")
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    aviosdao.tipo = comboBox1.SelectedIndex;
                    dv = new DataView(aviosdao.busca_aviosportipobase());
                }
                else
                {

                    dv = new DataView(aviosdao.devuelveaviostipobase());
                }
            }
            else
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    aviosdao.tipo = comboBox1.SelectedIndex;
                    dv = new DataView(aviosdao.buscatipobodega());
                }
                else
                {
                    dv = new DataView(aviosdao.aviosbodega());
                }
                
            }
            
            dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";

            dataGridView1.DataSource = dv;
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["tipo"].Value) >= 14)
            //    {
            //        GUI.Bodega.AviosColorGrupos aviosgui = new AviosColorGrupos();
            //        aviosgui.lbl_idavio.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //        aviosgui.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //        aviosgui.ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Solo puede crear relaciones de inventario para avios base");
            //    }
            //}
            //catch
            //{
            //}
            if(comboBox2.SelectedIndex!=-1)
            {
                if(comboBox2.SelectedIndex==0)
                {
                    GUI.REPORTES.ImpresionBodegaAvios_Catalogo impresionreporte = new REPORTES.ImpresionBodegaAvios_Catalogo();
                    impresionreporte.Show();
                }
                if(comboBox2.SelectedIndex==1)
                {
                    GUI.REPORTES.ImpresionBodegaAvios_Faltantes impresionreporte = new REPORTES.ImpresionBodegaAvios_Faltantes();
                    impresionreporte.Show();
                }
            }
            else
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    GUI.REPORTES.ImpresionBodegaAvios_PorTipo impresionreporte = new REPORTES.ImpresionBodegaAvios_PorTipo();
                    impresionreporte.tipoavio = comboBox1.SelectedIndex;
                    impresionreporte.ShowDialog();
                }
                else
                {
                    GUI.REPORTES.ImpresionBodegaDeavios impresionbodega = new REPORTES.ImpresionBodegaDeavios();
                    impresionbodega.ShowDialog();
                }
            }
            
            


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            dataGridView1.DataSource = aviosdao.devuelveaviostipobase();
        }
    }
}
