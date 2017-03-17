using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Seleccionar_Maquilador : Form
    {
        GUI.Bodega.Salida_maquila salidagui;
        public Seleccionar_Maquilador(Salida_maquila fr1)
        {
            salidagui = new Salida_maquila();
            salidagui = fr1;
            InitializeComponent();
        }

        private void Seleccionar_Maquilador_Load(object sender, EventArgs e)
        {
            DAO.MaquiladoresDAO maquiladoresdao = new GrupoSM_Recepcion.DAO.MaquiladoresDAO();
            dataGridView1.DataSource = maquiladoresdao.devuelvemaquiladores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                salidagui.textBox6.ReadOnly = true;
                salidagui.textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                salidagui.label7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["precio_minuto"].Value);
                salidagui.label12.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["idmaquiladores"].Value);
                this.Hide();
                this.Close();
            }
            catch
            {
                MessageBox.Show("No hay maquilador seleccionado o maquiladores por seleccionar");
                this.Hide();
                this.Close();
            }
        }
    }
}
