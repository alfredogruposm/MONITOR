using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class TelasControl : Form
    {
        public TelasControl()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Cliente_seleccion clientegui = new Cliente_seleccion(this);
            clientegui.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GUI.Bodega.Proveedor_Seleccion proveedorgui = new Proveedor_Seleccion(this);
            proveedorgui.ShowDialog();
        }
        //                    cliente int not null foreign key references clientes(idclientes),
        //                    proveedor int not null foreign key references proveedor(idproveedor),
        //                    fecha_entrada datetime,
        //                    nombre_descripcion varchar(max),
        //                    metros float,
        //                    composicion varchar(max),
        //                    color varchar(max),
        //                    ancho float
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Aceptar")
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != "") && (textBox7.Text != "") && (comboBox1.Text != "") && (comboBox1.SelectedIndex != -1))
                {
                    DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                    telasdao.cliente = int.Parse(label10.Text);
                    telasdao.fecha_entrada = dateTimePicker1.Value;
                    telasdao.proveedor = int.Parse(label11.Text);
                    telasdao.metros = double.Parse(textBox3.Text);
                    telasdao.nombre_descripcion = (textBox4.Text);
                    telasdao.composicion = textBox5.Text;
                    telasdao.color = textBox6.Text;
                    telasdao.ancho = double.Parse(textBox7.Text);
                    if (comboBox1.Text == "Tela")
                    {
                        telasdao.tipo = 1;
                    }
                    if (comboBox1.Text == "Combinacion")
                    {
                        telasdao.tipo = 2;
                    }
                    if (comboBox1.Text == "Forro")
                    {
                        telasdao.tipo = 3;
                    }
                    MessageBox.Show(telasdao.insertatela());
                    this.Visible = false;
                    this.Close();



                }
                else
                {
                    MessageBox.Show("Por favor, inserte todos los datos completos, o verifique su informacion");
                }
            }
            else
            {
                DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao.metros = double.Parse(textBox3.Text);
                telasdao.nombre_descripcion = (textBox4.Text);
                telasdao.composicion = textBox5.Text;
                telasdao.color = textBox6.Text;
                telasdao.ancho = double.Parse(textBox7.Text);
                if (comboBox1.Text == "Tela")
                {
                    telasdao.tipo = 1;
                }
                if (comboBox1.Text == "Combinacion")
                {
                    telasdao.tipo = 2;
                }
                if (comboBox1.Text == "Forro")
                {
                    telasdao.tipo = 3;
                }
                telasdao.idtela_bodega = int.Parse(label10.Text);
                MessageBox.Show(telasdao.modifica_telascompleto());
                this.Visible = false;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != "") && (textBox7.Text != "") && (comboBox1.Text != ""))
            {
                DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                telasdao.cliente = int.Parse(label10.Text);
                telasdao.fecha_entrada = dateTimePicker1.Value;
                telasdao.proveedor = int.Parse(label11.Text);
                telasdao.metros = double.Parse(textBox3.Text);
                telasdao.nombre_descripcion = (textBox4.Text);
                telasdao.composicion = textBox5.Text;
                telasdao.color = textBox6.Text;
                telasdao.ancho = double.Parse(textBox7.Text);
                if (comboBox1.Text == "Tela")
                {
                    telasdao.tipo = 1;
                }
                if (comboBox1.Text == "Combinacion")
                {
                    telasdao.tipo = 2;
                }
                if (comboBox1.Text == "Forro")
                {
                    telasdao.tipo = 3;
                }
                MessageBox.Show(telasdao.insertatela());
                //textBox1.Text = "";
                //textBox2.Text = "";
                textBox3.Text = "";
                //textBox4.Text = "";
                //textBox5.Text = "";
                //textBox6.Text = "";
                textBox7.Text = "";
                
            }
            else
            {
                MessageBox.Show("Por favor, inserte todos los datos completos, o verifique su informacion");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }
    }
}
