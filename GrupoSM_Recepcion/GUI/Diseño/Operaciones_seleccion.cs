using System;
using System.Windows.Forms;
using System.Data;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Operaciones_seleccion : Form
    {
        
        public Operaciones_seleccion()
        {
           
            InitializeComponent();
        }

        private void Operaciones_seleccion_Load(object sender, EventArgs e)
        {
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            dataGridView1.DataSource = procesosdao.devuelveprocesos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Operaciones Plantilla")
                {
                    DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                    procesosdao.idproceso = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    procesosdao.idplantilla = int.Parse(label1.Text);
                    MessageBox.Show(procesosdao.insertaprocesosplantilla());
                    this.Visible = false;
                    this.Close();
                }
                else
                {
                    DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                    procesosdao.idproceso = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_procesos"].Value);
                    procesosdao.idficha = int.Parse(label1.Text);
                    MessageBox.Show(procesosdao.ingresadetalle());
                    this.Visible = false;
                    this.Close();
                }
                

            }
            catch
            {
                MessageBox.Show("A habido algun error");
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Operaciones_control operacionesgui = new Operaciones_control();
            operacionesgui.ShowDialog();
            if(comboBox1.SelectedIndex!=-1)
            {
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao.tipo = comboBox1.SelectedIndex;
                dataGridView1.DataSource = procesosdao.busca_procesosportipo();
            }
            else
            {
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                dataGridView1.DataSource = procesosdao.devuelveprocesos();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao.tipo = comboBox1.SelectedIndex;
                dataGridView1.DataSource = procesosdao.busca_procesosportipo();
            }
            catch
            {
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                dataGridView1.DataSource = procesosdao.devuelveprocesos();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el grupo de busqueda");
            }
            else
            {
                string campo = "operacion";
                
                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                procesosdao.tipo = comboBox1.SelectedIndex;
                DataView dv = new DataView(procesosdao.busca_procesosportipo());
                dv.RowFilter = campo + " like '%" + textBox1.Text + "%'";

                dataGridView1.DataSource = dv;
            }
        }
    }
}
