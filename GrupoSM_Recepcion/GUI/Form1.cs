using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.Oden_ProduccionDAO ordengui = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
                dataGridView1.DataSource = ordengui.vistamonitoractivos();
                
            }
            catch
            {
                MessageBox.Show("Error de coneccion");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            DAO.Oden_ProduccionDAO ordengui = new GrupoSM_Recepcion.DAO.Oden_ProduccionDAO();
            dataGridView1.DataSource = ordengui.vistamonitorterminados();
            }
            catch
            {
                MessageBox.Show("Error de coneccion");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
