using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Prendas_corte prendascortegui = new Prendas_corte();
            prendascortegui.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Piezas piezasgui = new Piezas();
            piezasgui.ShowDialog();
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

        private void button10_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Acabados acabadosgui = new Acabados();
            acabadosgui.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Operaciones operacionesgui = new Operaciones();
            operacionesgui.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Fichas_tecnicas fichasgui = new Fichas_tecnicas();
            fichasgui.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Solicitudes solicitudesgui = new Solicitudes();
            solicitudesgui.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Ordenes ordenesgui = new Ordenes();
            ordenesgui.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Prendas_separado prendasgui = new Prendas_separado();
            prendasgui.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Empleados empleadosgui = new Empleados();
            empleadosgui.ShowDialog();
        }
    }
}
