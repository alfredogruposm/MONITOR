using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Telas : Form
    {
        public Telas()
        {
            InitializeComponent();
        }

        private void Telas_Load(object sender, EventArgs e)
        {
            
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            dataGridView1.DataSource = telasdao.tablatelas();
        }

        public void actualizagrid()
        {
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            dataGridView1.DataSource = telasdao.tablatelas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Bodega.TelasControl guitelas = new TelasControl();
            guitelas.ShowDialog();
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            dataGridView1.DataSource = telasdao.tablatelas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.Bodega.TelasControl telasgui = new TelasControl();
            telasgui.button2.Visible = false;
            telasgui.button1.Text = "Modificar";
            telasgui.button4.Visible = false;
            telasgui.button5.Visible = false;
            telasgui.textBox1.Enabled = false;
            telasgui.textBox2.Enabled = false;
            telasgui.textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["metros"].Value);
            telasgui.textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
            telasgui.textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["composicion"].Value);
            telasgui.textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["color"].Value);
            telasgui.textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ancho"].Value);
            if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["tipo"].Value) > 2)
            {
            }
            else
            {
                telasgui.comboBox1.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells["tipo"].Value);
            }
            
            telasgui.label10.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ID"].Value);
            telasgui.textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Cliente"].Value);
            telasgui.textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Proveedor"].Value);
            telasgui.ShowDialog();
            actualizagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show("¿Desea eliminar la tela seleccionada?",
                        "Mensaje",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                    telasdao.idtela_bodega = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    
                    MessageBox.Show(telasdao.borra_telasbodega());

                    DAO.TelasDAO telasdao1 = new GrupoSM_Recepcion.DAO.TelasDAO();
                    dataGridView1.DataSource = telasdao1.tablatelas();
                }
            }
            catch
            {
                MessageBox.Show("Elija una tela para eliminar");
            }

           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex!=-1)
            {
                if(comboBox1.SelectedIndex==0)
                {
                    string campo = "Nombre";

                    DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();


                    DataView dv;

                    dv = new DataView(telasdao.tablatelas());

                    dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";

                    dataGridView1.DataSource = dv;
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    string campo = "Cliente";

                    DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();


                    DataView dv;

                    dv = new DataView(telasdao.tablatelas());

                    dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";

                    dataGridView1.DataSource = dv;
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    string campo = "Proveedor";

                    DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();


                    DataView dv;

                    dv = new DataView(telasdao.tablatelas());

                    dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";

                    dataGridView1.DataSource = dv;
                }
            }
            else
            {
                MessageBox.Show("Escoja una opcion de filtro primero");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                GUI.REPORTES.TelasBodegaVistas_Almacen reportealmacen = new REPORTES.TelasBodegaVistas_Almacen();
                reportealmacen.ShowDialog();                
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    GUI.REPORTES.TelasBodegaVista_porNombre telasbodega = new REPORTES.TelasBodegaVista_porNombre();
                    telasbodega.nombretela = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    GUI.REPORTES.TelasBodegaVista_porCliente reporteclientesalmacen = new REPORTES.TelasBodegaVista_porCliente();
                    reporteclientesalmacen.idcliente = Convert.ToInt16(dataGridView1.CurrentRow.Cells["ClientesID"].Value);


                    reporteclientesalmacen.ShowDialog();
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    GUI.REPORTES.TelasBodegaVista_Proveedor reporteproveedoralmacen = new REPORTES.TelasBodegaVista_Proveedor();
                    reporteproveedoralmacen.idproveedor = Convert.ToInt16(dataGridView1.CurrentRow.Cells["ProveedorID"].Value);


                    reporteproveedoralmacen.ShowDialog();
                }
            }
        }
    }
}
