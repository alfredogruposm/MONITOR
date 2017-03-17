using System.Data;

namespace GrupoSM_Recepcion.DAO
{
    class MaquiladoresDAO
    {

        BO.DS_MasterDatasetTableAdapters.maquiladoresTableAdapter maquiladorestabla = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.maquiladoresTableAdapter();
        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter queriesadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();



        public int idmaquilador { get; set; }
        public string nombre { get; set; }
        public double costominuto { get; set; }

        public string borra_maquilador()
        {
            try
            {
                queriesadapter.borra_maquilador(this.idmaquilador);
                return "Maquilador eliminado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }


        public DataTable devuelvemaquiladores()
        {
            return maquiladorestabla.GetData();
        }


        public string actualizamaquiladores()
        {
            try
            {
                queriesadapter.actualizamaquiladores(this.idmaquilador, this.nombre, this.costominuto);
                return "Maquilador Actualizado";
            }
            catch
            {
                return "Error de coneccion";
            }


        }


        public string insertamaquilador()
        {
            try
            {

                maquiladorestabla.Insert(this.nombre, this.costominuto);
                return "Cliente Agregado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }


























    }
}
