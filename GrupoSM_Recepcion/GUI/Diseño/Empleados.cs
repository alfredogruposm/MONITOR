using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.Diseño
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            actualizagrid1();
            actualizagrid2();
            idempleado = 0;
        }
        public void actualizagrid2()
        {
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            dataGridView2.DataSource = procesosdao.devuelveprocesos();
        }
        public int idempleado { get; set; }
        public void actualizagrid1()
        {
            DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
            dataGridView1.DataSource = empleadosdao.devuelvetodoempleados();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
                empleadosdao.nombre = textBox1.Text;
                string resultado = empleadosdao.insertaempleados();
                if (resultado == "Correcto")
                {
                    button1.Enabled = false;
                    groupBox2.Enabled = true;
                    actualizagrid1();
                    int numerorow = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.Displayed);
                    idempleado = Convert.ToInt16(dataGridView1.Rows[numerorow].Cells[0].Value);
                }
                else
                {
                    MessageBox.Show(resultado);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.RowCount == 1)
                {

                }
                else
                {
                    dataGridView3.Rows.Add(dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[1].Value.ToString());
                }
            }
            catch
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView4.RowCount == 1)
                {

                }
                else
                {
                    dataGridView4.Rows.Add(dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[1].Value.ToString());
                }
            }
            catch
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView5.RowCount == 1)
                {

                }
                else
                {
                    dataGridView5.Rows.Add(dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[1].Value.ToString());
                }
            }
            catch
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView5.Rows.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (this.idempleado!=0))
            {
                DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
                empleadosdao.nombre = textBox1.Text;
                empleadosdao.idempleados = this.idempleado;
                if (dataGridView5.RowCount == 1)
                {
                    empleadosdao.Afinidad3 = Convert.ToInt16(dataGridView5.Rows[0].Cells[0].Value);
                }
                else
                {
                    empleadosdao.Afinidad3 = 0;
                }
                if (dataGridView4.RowCount == 1)
                {
                    empleadosdao.Afinidad2 = Convert.ToInt16(dataGridView4.Rows[0].Cells[0].Value);
                }
                else
                {
                    empleadosdao.Afinidad2 = 0;
                }
                if (dataGridView3.RowCount == 1)
                {
                    empleadosdao.Afinidad1 = Convert.ToInt16(dataGridView3.Rows[0].Cells[0].Value);
                }
                else
                {
                    empleadosdao.Afinidad1 = 0;
                }
                string resultado = empleadosdao.actualizaempleados();
                if (resultado == "Correcto")
                {
                    MessageBox.Show(resultado);
                    actualizagrid1();
                }
                else
                {
                    MessageBox.Show(resultado);
                }
            }
        }
        public void afinidad1()
        {
            string campo = "id_procesos";
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            DataView dv = new DataView(procesosdao.devuelveprocesos());
            dv.RowFilter = campo + " = '" + dataGridView6.Rows[0].Cells["Afinidad1"].Value.ToString() + "'";
            dataGridView2.DataSource = dv;
            dataGridView3.Rows.Add(dataGridView2.Rows[0].Cells[0].Value.ToString(), dataGridView2.Rows[0].Cells[1].Value.ToString());
        }
        public void afinidad2()
        {
            string campo = "id_procesos";
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            DataView dv = new DataView(procesosdao.devuelveprocesos());
            dv.RowFilter = campo + " = '" + dataGridView6.Rows[0].Cells["Afinidad2"].Value.ToString() + "'";
            dataGridView2.DataSource = dv;
            dataGridView4.Rows.Add(dataGridView2.Rows[0].Cells[0].Value.ToString(), dataGridView2.Rows[0].Cells[1].Value.ToString());
        }
        public void afinidad3()
        {
            string campo = "id_procesos";
            DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
            DataView dv = new DataView(procesosdao.devuelveprocesos());
            dv.RowFilter = campo + " = '" + dataGridView6.Rows[0].Cells["Afinidad3"].Value.ToString() + "'";
            dataGridView2.DataSource = dv;
            dataGridView5.Rows.Add(dataGridView2.Rows[0].Cells[0].Value.ToString(), dataGridView2.Rows[0].Cells[1].Value.ToString());
        }
        public void sacaafinidades()
        {
            DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
            empleadosdao.idempleados = this.idempleado;
            dataGridView6.DataSource = empleadosdao.devuelveempleados();
            afinidad1();
            afinidad2();
            afinidad3();

        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                limpiagrisafinidad();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                idempleado = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                groupBox2.Enabled = true;
                sacaafinidades();
                actualizagrid2();
            }
            catch
            {
            }
        }
        public void limpiagrisafinidad()
        {
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.idempleado != 0)
            {
                DialogResult result = MessageBox.Show("¿De verdad desea eliminar el empleado seleccionado?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.EmpleadosDAO empleadosdao = new GrupoSM_Recepcion.DAO.EmpleadosDAO();
                    empleadosdao.idempleados = this.idempleado;
                    string resultado = empleadosdao.eliminaempleados();
                    if (resultado == "Correcto")
                    {
                        this.idempleado = 0;
                        actualizagrid1();
                        textBox1.Text = "";
                        limpiagrisafinidad();
                    }
                    else
                    {
                        MessageBox.Show(resultado);
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
                string campo = "operacion";

                DAO.ProcesosDAO procesosdao = new GrupoSM_Recepcion.DAO.ProcesosDAO();
                DataView dv = new DataView(procesosdao.devuelveprocesos());
                dv.RowFilter = campo + " like '%" + textBox2.Text + "%'";

                dataGridView1.DataSource = dv;
            
        }
    }
}
