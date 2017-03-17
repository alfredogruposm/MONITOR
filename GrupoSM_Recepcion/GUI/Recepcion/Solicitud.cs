using System;
using System.Windows.Forms;
using System.Data;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class Solicitud : Form
    {
        
        public Solicitud()
        {
            InitializeComponent();
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            
        }

        private void Solicitud_Load(object sender, EventArgs e)
        {
            
            DAO.SolicitudesDAO solicitudesdao = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
            dataGridView1.DataSource = solicitudesdao.solicitudesrespondidas();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            GUI.Recepcion.SolicitudControl solicitudcontrol = new SolicitudControl();
            solicitudcontrol.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            GUI.Recepcion.SolicitudControl solicitudcontrol = new SolicitudControl();
            solicitudcontrol.button1.Text = "Modificar";
            solicitudcontrol.label2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_solicitud"].Value);
            solicitudcontrol.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["asunto"].Value);
            solicitudcontrol.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_cliente"].Value);
            solicitudcontrol.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha Creado"].Value);
            solicitudcontrol.richTextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["descripcion"].Value);
            
            
            solicitudcontrol.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string campo = "Asunto";

            DAO.SolicitudesDAO solicitudesdao = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
            DataView dv = new DataView(solicitudesdao.solicitudesrespondidas());
            dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";

            dataGridView1.DataSource = dv;
        }
    }
}
