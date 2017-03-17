using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Solicitudes_control : Form
    {
        public Solicitudes_control()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Fichas_tecnicas_control fichacontrolgui = new Fichas_tecnicas_control();
            fichacontrolgui.tb_solicitud.Text = textBox1.Text;
            fichacontrolgui.label23.Text = label6.Text;
            fichacontrolgui.textBox2.Text = textBox3.Text;
            fichacontrolgui.label22.Text = label5.Text;
            fichacontrolgui.button7.Enabled = false;
            fichacontrolgui.tb_solicitud.Visible = true;
            fichacontrolgui.label19.Visible = true;

            fichacontrolgui.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            this.Close();
        }
    }
}
