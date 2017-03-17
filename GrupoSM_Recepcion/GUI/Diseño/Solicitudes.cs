using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Solicitudes : Form
    {
        public Solicitudes()
        {
            InitializeComponent();
        }

        private void Solicitudes_Load(object sender, EventArgs e)
        {
            DAO.SolicitudesDAO solicitudesdao = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
            dataGridView1.DataSource = solicitudesdao.solicitudesclientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.Diseño.Solicitudes_control solicitudescontrolgui = new Solicitudes_control();

                solicitudescontrolgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["id_solicitud"].Value);
                solicitudescontrolgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["asunto"].Value);
                solicitudescontrolgui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                solicitudescontrolgui.label5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["costo_minuto"].Value);
                solicitudescontrolgui.label6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idclientes"].Value);
                solicitudescontrolgui.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["fecha"].Value);
                solicitudescontrolgui.richTextBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["descripcion"].Value);

                solicitudescontrolgui.ShowDialog();
                DAO.SolicitudesDAO solicitudesdao2 = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
                dataGridView1.DataSource = solicitudesdao2.solicitudesclientes();
            }
            catch
            {
                MessageBox.Show("Seleccione una solicitud");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.SolicitudesDAO solicitudesdao = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
                solicitudesdao.fecha = dateTimePicker1.Value;
                solicitudesdao.idsolicitud = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_solicitud"].Value);
                solicitudesdao.ingresafechasolicitud();
                solicitudesdao.establecerespondido();
            }
            catch
            {
            }
        }
    }
}
