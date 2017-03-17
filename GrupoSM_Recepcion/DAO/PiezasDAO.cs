using System;
using System.Data;


namespace GrupoSM_Recepcion.DAO
{
    class PiezasDAO
    {
        BO.DS_MasterDatasetTableAdapters.piezasTableAdapter tablapiezas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.piezasTableAdapter();
        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();
        BO.DS_MasterDatasetTableAdapters.piezas_detalleTableAdapter tabladetalle = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.piezas_detalleTableAdapter();
        BO.DS_MasterDatasetTableAdapters.verpiezas_fichaTableAdapter piezasficha = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.verpiezas_fichaTableAdapter();
        BO.DS_MasterDatasetTableAdapters.busca_piezastipoTableAdapter piezastipo = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.busca_piezastipoTableAdapter();
        BO.DS_MasterDatasetTableAdapters.devuelvepiezasplantillaTableAdapter piezasplantilla;
        BO.DS_MasterDatasetTableAdapters.trabajoseparadohojacorteTableAdapter tablatrabajoseparado = new BO.DS_MasterDatasetTableAdapters.trabajoseparadohojacorteTableAdapter();
        BO.DS_MasterDatasetTableAdapters.devuelvetrabajoseparadoTableAdapter trabajoseparado = new BO.DS_MasterDatasetTableAdapters.devuelvetrabajoseparadoTableAdapter();

        public int orden { get; set; }
        public int idpiezas { get; set; }
        public int tipo { get; set; }
        public int idplantilla { get; set; }
        public string nombre { get; set; }
        public string talla { get; set; }
        public string color { get; set; }

        public int idpiezasdetalle { get; set; }
        public int idficha { get; set; }
        public double cantidad { get; set; }
        public int cantidadseparado { get; set; }

        public DataTable devuelveordentrabajoseparado()
        {
            return trabajoseparado.GetData(this.orden);
        }

        public string insertatrabajoseparadohojacorte()
        {
            tablatrabajoseparado.Insert(this.orden, this.nombre, this.cantidadseparado, this.talla, this.color);
            return "Correcto";

        }

        public DataTable devuelvepiezasplantilla()
        {
            piezasplantilla = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelvepiezasplantillaTableAdapter();
            return piezasplantilla.GetData(this.idplantilla);
        }

        public string ingresaplantillapiezas()
        {
            try
            {
                querysadapter.insertaplantilla_piezas(this.idplantilla, this.idpiezas, Math.Round(this.cantidad, 2));
                return "Correcto";
            }
            catch
            {
                return "Error(ingresapiezasplantilla)";
            }
        }

        public string eliminapiezasplantilla()
        {
            try
            {
                querysadapter.eliminapiezas_plantilla(this.idplantilla, this.idpiezas);
                return "Correcto";
            }
            catch
            {
                return "Error(eliminapiezasplantilla)";
            }
        }

        public string insertapieza()
        {
            try
            {
                tablapiezas.Insert(this.tipo, this.nombre);
                return "Pieza Agregada";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string borrapieza()
        {
            querysadapter.borra_pieza(this.idpiezas);
            return "0";
        }

        public DataTable devuelvepiezas()
        {
            return tablapiezas.GetData();
        }


        public DataTable devuelvepiezasfichas()
        {
            return piezasficha.GetData(this.idficha);
        }

        public string actualizapiezas()
        {
            try
            {
                querysadapter.actualizapiezas(this.idpiezas, this.tipo, this.nombre);
                return "cliente Actualizado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string insertadetalle()
        {
            try
            {

                querysadapter.insertaficha_piezas(this.idficha, this.idpiezas, this.cantidad);
                return "Agregado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable busca_piezasportipo()
        {
            return piezastipo.GetData(this.tipo);
        }

        public string borra_piezaficha()
        {
            try
            {
                querysadapter.borra_piezasficha(this.idpiezas, this.idficha);
                return "Borrado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }


    }
}
