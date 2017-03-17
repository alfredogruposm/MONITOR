using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Bodega
{
    public partial class SeleccionarEmpleado : Form
    {
        public SeleccionarEmpleado()
        {
            InitializeComponent();
        }

        public void cargaempleados()
        {
            DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
            dataGridView1.DataSource = empleadosdao.devuelvetodoempleados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
                empleadosdao.idempleados = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                empleadosdao.IDProduccion = int.Parse(lblidproduccion.Text);
                string resultado = empleadosdao.insertaempleadosproduccion();
                if (resultado == "Correcto")
                {
                    this.Visible = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(resultado);
                }
            }
            catch
            {
                MessageBox.Show("Es necesario agregar empleados primero");
            }
        }
    }
}
