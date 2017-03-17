using System.Data;

namespace GrupoSM_Recepcion.DAO
{
    class ProveedoresDAO
    {
        BO.DS_MasterDatasetTableAdapters.proveedorTableAdapter tablaproveedor = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.proveedorTableAdapter();
        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();

        public int idproveedor { get; set; }
        public string nombre { get; set; }

        public string borra_proveedor()
        {
            try
            {
            querysadapter.borra_proveedor(this.idproveedor);
            return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable proveedorestabla()
        {
            return tablaproveedor.GetData();
        }

        public string insertaproveedor()
        {
            try
            {
            tablaproveedor.Insert(this.nombre);
            return "Agregado";
            
            }
            catch
            {
                return "Error de coneccion";
            }
        }


        public string actualizaproveedor()
        {
            try
            {
                querysadapter.actualiza_proveedor(this.idproveedor, this.nombre);
                
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }


    }
}
