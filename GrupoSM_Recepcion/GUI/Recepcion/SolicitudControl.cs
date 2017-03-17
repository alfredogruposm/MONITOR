using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class SolicitudControl : Form
    {

        
        
        public SolicitudControl()
        {

            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Aceptar")
            {
                try
                {
                    
                    DAO.SolicitudesDAO solicitudesdao = new GrupoSM_Recepcion.DAO.SolicitudesDAO();

                    solicitudesdao.asunto = textBox2.Text;
                    solicitudesdao.descripcion = richTextBox1.Text;
                    solicitudesdao.fecha = dateTimePicker1.Value;
                    solicitudesdao.idcliente = int.Parse(textBox3.Text);
                    MessageBox.Show(solicitudesdao.insertasolicitud());
                    DAO.SolicitudesDAO solicitudesdao2 = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
                    int solicitud = solicitudesdao2.devuelvenumsolicitud();
                    solicitudesdao2.idsolicitud = solicitud;

                    solicitudesdao2.crearespuestasolicitud();
                    this.Visible = false;
                    this.Close();
                    GUI.Recepcion.Solicitud guisolicitud = new Solicitud();
                    guisolicitud.ShowDialog();

                }
                catch
                {
                    MessageBox.Show("Ha habido un error, ingrese los datos requeridos");
                }
            }
            if (button1.Text == "Modificar")
            {
                DAO.SolicitudesDAO solicitudesdao = new GrupoSM_Recepcion.DAO.SolicitudesDAO();
                solicitudesdao.asunto = textBox2.Text;
                solicitudesdao.idsolicitud = int.Parse(label2.Text);
                solicitudesdao.idcliente = int.Parse(textBox3.Text);
                solicitudesdao.descripcion = richTextBox1.Text;
                MessageBox.Show(solicitudesdao.actualizasolicitud());
                this.Visible = false;
                this.Close();
                GUI.Recepcion.Solicitud guisolicitud = new Solicitud();
                guisolicitud.ShowDialog();
            }
        }
        
        private void SolicitudControl_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.Seleccionar_Cliente seleccionarcliente = new Seleccionar_Cliente(this);
            seleccionarcliente.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            GUI.Recepcion.Solicitud guisolicitud = new Solicitud();
            guisolicitud.ShowDialog();
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
        }
    }
}
