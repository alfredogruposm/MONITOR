using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Acabados_seleccion : Form
    {
       
        public Acabados_seleccion()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Acabados Plantilla")
                {
                    DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                    acabadosdao.idplantilla = int.Parse(label1.Text);
                    acabadosdao.idacabados = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_acabados"].Value);
                    acabadosdao.cantidad = Convert.ToDouble(numericUpDown1.Value);
                    acabadosdao.tiempototal = ((Convert.ToDouble(numericUpDown1.Value)) * (Convert.ToDouble(dataGridView1.CurrentRow.Cells["tiempo"].Value)));
                    MessageBox.Show(acabadosdao.ingresaacabadosplantilla());
                    this.Visible = false;
                    this.Close();
                }
                else
                {
                    DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                    acabadosdao.idficha = int.Parse(label1.Text);
                    acabadosdao.idacabados = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_acabados"].Value);
                    acabadosdao.cantidad = Convert.ToDouble(numericUpDown1.Value);
                    acabadosdao.tiempototal = ((Convert.ToDouble(numericUpDown1.Value)) * (Convert.ToDouble(dataGridView1.CurrentRow.Cells["tiempo"].Value)));
                    MessageBox.Show(acabadosdao.insertadetalle());
                    this.Visible = false;
                    this.Close();
                }
                

            }
            catch
            {
                MessageBox.Show("Hubo algun error");
            }
        }

        private void Acabados_seleccion_Load(object sender, EventArgs e)
        {
            DAO.AcabadosDAO acabadosdao=new GrupoSM_Recepcion.DAO.AcabadosDAO();
            dataGridView1.DataSource = acabadosdao.devuelveprocesos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Acabados_control acabadosgui = new Acabados_control();
            acabadosgui.ShowDialog();
            if(comboBox1.SelectedIndex!=-1)
            {
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                acabadosdao.tipo = comboBox1.SelectedIndex;
                dataGridView1.DataSource = acabadosdao.busca_acabadosportipo();
            }
            else
            {
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                dataGridView1.DataSource = acabadosdao.devuelveprocesos();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                acabadosdao.tipo = comboBox1.SelectedIndex;
                dataGridView1.DataSource = acabadosdao.busca_acabadosportipo();
            }
            catch
            {
                DAO.AcabadosDAO acabadosdao = new GrupoSM_Recepcion.DAO.AcabadosDAO();
                dataGridView1.DataSource = acabadosdao.devuelveprocesos();
            }
        }
    }
}
