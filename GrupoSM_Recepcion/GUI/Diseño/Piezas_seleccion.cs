using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Piezas_seleccion : Form
    {
        
        public Piezas_seleccion()
        {
            
            InitializeComponent();
        }

        private void Piezas_seleccion_Load(object sender, EventArgs e)
        {
            DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
            dataGridView1.DataSource = piezasdao.devuelvepiezas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Piezas Plantilla")
                {
                    DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                    piezasdao.cantidad = Convert.ToDouble(numericUpDown1.Value);
                    piezasdao.idplantilla = int.Parse(label1.Text);
                    piezasdao.idpiezas = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_piezas"].Value);
                    MessageBox.Show(piezasdao.ingresaplantillapiezas());
                    this.Visible = false;
                    this.Close();
                }
                else
                {

                    DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                    piezasdao.cantidad = Convert.ToDouble(numericUpDown1.Value);
                    piezasdao.idficha = int.Parse(label1.Text);
                    piezasdao.idpiezas = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_piezas"].Value);
                    MessageBox.Show(piezasdao.insertadetalle());
                    this.Visible = false;
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Verifique sus datos");
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Piezas_control piezasgui = new Piezas_control();
            piezasgui.ShowDialog();
            if(comboBox1.SelectedIndex!=-1)
            {
                DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                piezasdao.tipo = comboBox1.SelectedIndex;
                dataGridView1.DataSource = piezasdao.busca_piezasportipo();
            }
            else
            {
                DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                dataGridView1.DataSource = piezasdao.devuelvepiezas();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                piezasdao.tipo = comboBox1.SelectedIndex;
                dataGridView1.DataSource = piezasdao.busca_piezasportipo();
            }
            catch
            {
                DAO.PiezasDAO piezasdao = new GrupoSM_Recepcion.DAO.PiezasDAO();
                dataGridView1.DataSource = piezasdao.devuelvepiezas();
            }
        }
    }
}
