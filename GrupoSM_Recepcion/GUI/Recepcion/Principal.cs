using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.Clientes guiclientes = new Clientes();
            guiclientes.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.Solicitud guisolicitud = new Solicitud();
            guisolicitud.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.Costeo guicosteo = new Costeo();
            guicosteo.Text = "Costeo Solicitudes";
            guicosteo.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.Costeo guicosteo = new Costeo();
            guicosteo.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.Orden_Produccion guiorden_produccion = new Orden_Produccion();
            guiorden_produccion.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
        }

        private void bodegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Principal principalgui = new GrupoSM_Recepcion.GUI.Bodega.Principal();
            this.Visible = false;
            this.Close();
            principalgui.Show();
        }

        private void recepcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.Principal principalgui = new GrupoSM_Recepcion.GUI.Recepcion.Principal();
            this.Visible = false;
            this.Close();
            principalgui.Show();
        }

        private void diseñoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Principal principalgui = new GrupoSM_Recepcion.GUI.Diseño.Principal();
            this.Visible = false;
            this.Close();
            principalgui.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {


            GUI.Bodega.Avios aviosgui = new GrupoSM_Recepcion.GUI.Bodega.Avios();
            aviosgui.label1.Text = "Catalogo avios";
            aviosgui.ShowDialog();
            this.Focus();
        
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.Telas telasgui = new Telas();
            telasgui.ShowDialog();
        }
    }
}
