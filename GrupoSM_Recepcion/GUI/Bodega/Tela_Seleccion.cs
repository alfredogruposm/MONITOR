using System;
using System.Data;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class Tela_Seleccion : Form
    {
        public Tela_Seleccion()
        {
            InitializeComponent();
        }

        private void Tela_Seleccion_Load(object sender, EventArgs e)
        {
            //DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            //telasdao.tipo = int.Parse(label2.Text);
            //telasdao.cliente = int.Parse(label1.Text);
            //dataGridView1.DataSource = telasdao.bodegastipo();
            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
            dataGridView1.DataSource = telasdao.tablatelas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string tela;
            //string color;
            //double metros;
            DialogResult result = MessageBox.Show("¿Desea Continuar con la seleccion hecha?",
                    "Mensaje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (textBox1.Text == "")
                {
                    
                    
                        DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                        telasdao.cliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClientesID"].Value);
                        telasdao.proveedor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ProveedorID"].Value);
                        telasdao.produccion = int.Parse(label3.Text);
                        telasdao.fecha_entrada_produccion = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha Entrada"].Value);
                        telasdao.nombre_descripcion = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
                        telasdao.metros = Convert.ToDouble(dataGridView1.CurrentRow.Cells["metros"].Value);
                        telasdao.composicion = Convert.ToString(dataGridView1.CurrentRow.Cells["composicion"].Value);
                        telasdao.color = Convert.ToString(dataGridView1.CurrentRow.Cells["color"].Value);
                        telasdao.ancho = Convert.ToDouble(dataGridView1.CurrentRow.Cells["ancho"].Value);
                    
                    
                        telasdao.tipo = 0;
                   
                    
                        telasdao.idtela_bodega = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

                  
                    try
                    {
                        string RESPUESTA = telasdao.agregar_telaproduccion();

                        if (RESPUESTA=="Correcto")
                        {
                            MessageBox.Show("Correcto");
                            telasdao.borratelabodega();
                            this.Visible = false;
                            this.Close();

                        }
                        else
                        {


                            MessageBox.Show("Hubo algun error, probablemente no selecciono ningunna tela, o no hay ninguna tela disponible");
                            this.Visible = false;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                   
                    
                    
                    
                }
                else
                {
                    
                        if ((Convert.ToDouble(dataGridView1.CurrentRow.Cells["metros"].Value) > double.Parse(textBox1.Text)))
                        {
                            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                            telasdao.cliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClientesID"].Value);
                            telasdao.proveedor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ProveedorID"].Value);
                            telasdao.produccion = int.Parse(label3.Text);
                            telasdao.fecha_entrada_produccion = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Fecha Entrada"].Value);
                            telasdao.nombre_descripcion = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
                            telasdao.metros = (double.Parse(textBox1.Text));
                            //telasdao.metros = (Convert.ToDouble(dataGridView1.CurrentRow.Cells["metros"].Value));
                            telasdao.composicion = Convert.ToString(dataGridView1.CurrentRow.Cells["composicion"].Value);
                            telasdao.color = Convert.ToString(dataGridView1.CurrentRow.Cells["color"].Value);
                            telasdao.ancho = Convert.ToDouble(dataGridView1.CurrentRow.Cells["ancho"].Value);
                            telasdao.tipo = int.Parse(label2.Text);
                            MessageBox.Show(telasdao.agregar_telaproduccion());
                            DAO.TelasDAO telasdao2 = new GrupoSM_Recepcion.DAO.TelasDAO();
                            telasdao2.idtela_bodega = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                            telasdao2.metros = (Convert.ToDouble(dataGridView1.CurrentRow.Cells["metros"].Value) - double.Parse(textBox1.Text));
                            telasdao2.modificatela_bodega();
                            //telasdao.borratelabodega();
                            this.Visible = false;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Verifique que la cantidad esta correcta de tela");
                        }



                    
                }
                
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string campo = "Nombre";

            DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();


            DataView dv;

            dv = new DataView(telasdao.tablatelas());

            dv.RowFilter = campo + " like '%" + textBox5.Text + "%'";

            dataGridView1.DataSource = dv;
        }
    }
}
