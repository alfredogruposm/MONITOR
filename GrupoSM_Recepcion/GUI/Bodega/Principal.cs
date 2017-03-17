using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Ordenes ordenesgui = new Ordenes();
            ordenesgui.ShowDialog();
            this.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Maquiladores maquiladoresgui = new Maquiladores();
            maquiladoresgui.ShowDialog();
            this.Focus();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Telas telasgui = new Telas();
            telasgui.ShowDialog();
            
            //GUI.REPORTES.HojaCorte1 hojacorte1gui = new GrupoSM_Recepcion.GUI.REPORTES.HojaCorte1();
            //hojacorte1gui.idproduccion = 156;
            //GUI.REPORTES.HojaCorte2 hojacorte2gui = new GrupoSM_Recepcion.GUI.REPORTES.HojaCorte2();
            //hojacorte2gui.idficha = 227;
            //hojacorte1gui.Show();
            //hojacorte2gui.Show();
            ////this.Hide();
            ////this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Proveedores proveedoresgui = new Proveedores();
            proveedoresgui.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Telas_Entrada telasgui = new Telas_Entrada();
            telasgui.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Avios_Entrada aviosgui = new Avios_Entrada();
            aviosgui.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Seleccionar_Orden selecciongui = new Seleccionar_Orden();
            selecciongui.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Avios aviosgui = new Avios();
            aviosgui.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Fichas_tecnicas fichasgui = new GrupoSM_Recepcion.GUI.Diseño.Fichas_tecnicas();
            fichasgui.Text = "Ver Especificaciones";
            fichasgui.button1.Visible = false;
            fichasgui.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            GUI.Recepcion.Orden_Produccion guiorden_produccion = new GUI.Recepcion.Orden_Produccion();
            guiorden_produccion.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Seleccionar_salida salidagui = new Seleccionar_salida();
            salidagui.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Ordenes ordenesgui = new GrupoSM_Recepcion.GUI.Diseño.Ordenes();
            ordenesgui.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Prendas_corte prendascortegui = new GrupoSM_Recepcion.GUI.Diseño.Prendas_corte();
            prendascortegui.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            GUI.Diseño.Prendas_separado prendasgui = new GrupoSM_Recepcion.GUI.Diseño.Prendas_separado();
            prendasgui.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Seleccionar_entrada entregagui = new Seleccionar_entrada();
            entregagui.ShowDialog();

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Seleccion_Entregas entregasgui = new Seleccion_Entregas();
            entregasgui.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GUI.MonitorAlertas monitoralertasgui = new MonitorAlertas();
            monitoralertasgui.Show();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            GUI.MonitorAlertas monitoralertasgui = new MonitorAlertas();
            monitoralertasgui.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            GUI.Bodega.AsignacionEmpleadosCostura costura = new AsignacionEmpleadosCostura();
            costura.Show();
        }
    }
}
