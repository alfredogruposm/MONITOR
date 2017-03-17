using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Plantillas : Form
    {
        public Plantillas()
        {
            InitializeComponent();
        }

        private void Plantillas_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }

        public void actualizagrid()
        {
            DAO.PlantillasDAO plantillasdao = new GrupoSM_Recepcion.DAO.PlantillasDAO();
            dataGridView1.DataSource = plantillasdao.devuelvelistado();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.Diseño.PlantillasControl plantillasgui = new PlantillasControl();
            plantillasgui.ShowDialog();
            actualizagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.Diseño.PlantillasControl plantillasgui = new PlantillasControl();
            plantillasgui.tb_prenda.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            plantillasgui.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            plantillasgui.button6.Visible = false;
            plantillasgui.groupBox2.Visible = true;
            plantillasgui.ShowDialog();
            actualizagrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Seleccionar")
            {
                GUI.Diseño.PlantillasControl plantillasgui = new PlantillasControl();
                plantillasgui.lbl_idfichas.Text = lbl_idfichas.Text;
                plantillasgui.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                plantillasgui.tb_prenda.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                plantillasgui.button6.Visible = false;
                plantillasgui.groupBox2.Visible = true;
                plantillasgui.button5.Visible = true;
                plantillasgui.actualizatextos();
                this.Visible = false;
                this.Close();
                plantillasgui.ShowDialog();
            }
            else
            {
                DialogResult result = MessageBox.Show("¿De verdad desea eliminar la plantilla seleccionada? Tenga en cuenta que esta accion no puede deshacerse.", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.PlantillasDAO plantillasdao = new GrupoSM_Recepcion.DAO.PlantillasDAO();
                    plantillasdao.idplantilla = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string resultado = plantillasdao.eliminaplantilla();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    actualizagrid();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Diseño.PlantillasControl plantillasgui = new PlantillasControl();
            plantillasgui.tb_prenda.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            plantillasgui.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //plantillasgui.button6.Visible = false;
            plantillasgui.groupBox2.Visible = true;
            plantillasgui.Text = "Guardar Nuevo Como";
            plantillasgui.ShowDialog();
            actualizagrid();
        }
    }
}
