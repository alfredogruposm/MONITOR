using System;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Recepcion
{
    public partial class TelasControl : Form
    {
        public TelasControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Text == "Modificar")
            {
                try
                {
                    DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                    telasdao.nombretelacosteo = textBox1.Text;
                    telasdao.precio = double.Parse(textBox2.Text);
                    telasdao.idtelacosteo = int.Parse(label3.Text);
                    string s = telasdao.modificatelascosteo();
                    if (s == "Correcto")
                    {
                        this.Visible = false;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(s);
                    }
                }
                catch
                {
                    MessageBox.Show("Verifique sus datos");
                }
            }
            else
            {
                if ((textBox1.Text != "") && (textBox2.Text != ""))
                {

                    try
                    {
                        DAO.TelasDAO telasdao = new GrupoSM_Recepcion.DAO.TelasDAO();
                        telasdao.nombretelacosteo = textBox1.Text;
                        telasdao.precio = double.Parse(textBox2.Text);
                        string s = telasdao.insertatelacosteo();
                        if (s == "Correcto")
                        {
                            this.Visible = false;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(s);
                            
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Verifique sus datos");
                    }
                }
            }
        }
    }
}
