using System;
using System.Data;

namespace GrupoSM_Recepcion.DAO
{
    
    class ClientesDAO
    {
        BO.DS_MasterDatasetTableAdapters.clientesTableAdapter tablaclientes = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.clientesTableAdapter();

        BO.DS_MasterDatasetTableAdapters.devuelveclienteTableAdapter devuelvecliente = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelveclienteTableAdapter();

        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter queriesadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();

        BO.DS_MasterDatasetTableAdapters.vernombressolicitudesTableAdapter vernombres = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.vernombressolicitudesTableAdapter();




        public int idclientes { get; set; }
        public string nombre { get; set; }
        public double costo_minuto { get; set; }
        public double costometro { get; set; }

        public string borracliente()
        {
            try
            {
                queriesadapter.borra_cliente(this.idclientes);
                return "Cliente Actualizado";
            }
            catch
            {
                return "A habido un error";
            }
        }

        public DataTable devuelveclientes()
        {
            return tablaclientes.GetData();
        }

        public DataTable vernombresclientes()
        {
            return vernombres.GetData();
        }
        

        public string insertacliente()
        {
            try
            {
                tablaclientes.Insert(this.nombre, Math.Round((this.costo_minuto), 2), this.costometro);
                
                return "Cliente Agregado Correctamente";
            }
            catch
            {
                return "Error De Coneccion";
            }
        }

        public string actualizaclientes()
        {
            try
            {
                queriesadapter.actualizacliente(this.idclientes, this.nombre, Math.Round((this.costo_minuto), 2), this.costometro);
                return "Cliente Actualizado";
            }
            catch
            {
                return "A habido un error";
            }




        }

    }
}
