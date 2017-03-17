using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Corte_Vista : Form
    {
        public Corte_Vista()
        {
            InitializeComponent();
        }

        private void Corte_Vista_Load(object sender, EventArgs e)
        {
            DAO.ProduccionDAO producciondao = new GrupoSM_Recepcion.DAO.ProduccionDAO();
            producciondao.id_produccion = int.Parse(textBox1.Text);
            dataGridView1.DataSource = producciondao.tallas_preliminaresproduccion();
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            telasdao.id_tela_produccion = int.Parse(textBox1.Text);
            dataGridView2.DataSource = telasdao.vertelasproduccion();
            actualizatextos();
        }



        public int idficha { get; set; }
        public int idproduccion { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea imprimir ahorita la hoja de corte?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    GUI.REPORTES.HojaCorte1 hojacorte1gui = new GrupoSM_Recepcion.GUI.REPORTES.HojaCorte1();
                    hojacorte1gui.idproduccion = this.idproduccion;
                    GUI.REPORTES.HojaCorte2 hojacorte2gui = new GrupoSM_Recepcion.GUI.REPORTES.HojaCorte2();
                    hojacorte2gui.idficha = this.idficha;
                    hojacorte2gui.idproduccion = this.idproduccion;
                    GUI.REPORTES.SeparadoTrabajoImpresion trabajoseparado = new REPORTES.SeparadoTrabajoImpresion();
                    trabajoseparado.orden = int.Parse(textBox1.Text);
                    hojacorte1gui.Show();
                    hojacorte2gui.Show();
                    trabajoseparado.Show();
                    this.Hide();
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void actualizatextos()
        {
            DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            ordendao.idorden = int.Parse(textBox1.Text);
            dataGridView3.DataSource = ordendao.devuelvepellones();
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox8.Text = row.Cells[3].Value.ToString();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.Oden_ProduccionDAO ordendao = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                ordendao.idorden = int.Parse(textBox1.Text);
                ordendao.Pellon = textBox4.Text;
                ordendao.Marca = textBox6.Text;
                ordendao.Composicion = textBox5.Text;
                ordendao.Modelo = textBox8.Text;
                ordendao.actualizapellon();
                actualizatextos();
            }
            catch
            {
            }
        }
    }
}
