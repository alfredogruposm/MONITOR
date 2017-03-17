using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class AviosColorGrupos : Form
    {
        public AviosColorGrupos()
        {
            InitializeComponent();
        }

        private void AviosColorGrupos_Load(object sender, EventArgs e)
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            dataGridView1.DataSource = aviosdao.aviosbodega();
            actualizagridavioscolor();
        }

        public void actualizagridavioscolor()
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.idavios = int.Parse(lbl_idavio.Text);
            dataGridView2.DataSource = aviosdao.devuelveaviossubgruposcolor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.idavios = int.Parse(lbl_idavio.Text);
            aviosdao.iddetalle = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string resultado = aviosdao.ingresaaviossubgrupos();
            if (resultado != "Correcto")
            {
                MessageBox.Show(resultado);
            }
            else
            {
                actualizagridavioscolor();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();
            aviosdao.idavios = int.Parse(dataGridView2.CurrentRow.Cells["ID SubAvio"].Value.ToString());
            string resultado = aviosdao.eliminaaviossubgruposcolor();
            if (resultado != "Correcto")
            {
                MessageBox.Show(resultado);
            }
            else
            {
                actualizagridavioscolor();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string campo = "nombre";

            DAO.AviosDAO aviosdao = new GrupoSM_Recepcion.DAO.AviosDAO();

            DataView dv;
            //if (comboBox1.SelectedIndex != -1)
            //{
            //    aviosdao.tipo = comboBox1.SelectedIndex;
            //    dv = new DataView(aviosdao.buscatipobodega());
            //}
            //else
            //{
            dv = new DataView(aviosdao.aviosbodega());
            //}

            dv.RowFilter = campo + " like '%" + textBox2.Text + "%'";

            dataGridView1.DataSource = dv;
        }
    }
}
