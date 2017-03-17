﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrupoSM_Recepcion.GUI.REPORTES
{
    public partial class TelasBodegaVista_porCliente : Form
    {

        public int idcliente { get; set; }
        public TelasBodegaVista_porCliente()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void TelasBodegaVista_porCliente_Load(object sender, EventArgs e)
        {
            PLANTILLAS.TelasBodegaVista_porCliente report = new PLANTILLAS.TelasBodegaVista_porCliente();
            DAO.TelasDAO telasdao = new DAO.TelasDAO();
            telasdao.cliente = this.idcliente;
            report.SetDataSource(telasdao.devuelvetelasbodegacliente());
            // report.Subreports["AviosSubRPT"].SetDataSource(aviosdao.sacar_avios());
            //   report.Subreports["PiezasSubRPT"].SetDataSource(piezasdao.devuelvepiezasfichas());
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
