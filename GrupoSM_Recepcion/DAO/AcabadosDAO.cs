using System;
using System.Data;


namespace GrupoSM_Recepcion.DAO
{
    class AcabadosDAO
    {


        BO.DS_MasterDatasetTableAdapters.acabadosTableAdapter tablaacabados = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.acabadosTableAdapter();
        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();
        BO.DS_MasterDatasetTableAdapters.acabados_detalleTableAdapter tabladetalleacabados = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.acabados_detalleTableAdapter();
        BO.DS_MasterDatasetTableAdapters.veracabados_fichasTableAdapter acabadosfichas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.veracabados_fichasTableAdapter();
        BO.DS_MasterDatasetTableAdapters.busca_acabadostipoTableAdapter acabadostipo = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.busca_acabadostipoTableAdapter();
        BO.DS_MasterDatasetTableAdapters.devuelveacabados_plantillaTableAdapter acabadosplantilla;
        
        public int idacabados { get; set; }
        public int tipo { get; set; }
        public int idplantilla { get; set; }
        public string nombre { get; set; }
        public double tiempo { get; set; }
        public int idacabadosdetalle { get; set; }
        public int idficha { get; set; }
        public double cantidad { get; set; }
        public double tiempototal { get; set; }

        public string eliminaplantillaacabados()
        {
            try
            {

                querysadapter.eliminaacabados_plantilla(this.idplantilla, this.idacabados);
                return "Agregado";
            }
            catch
            {
                return "Error(eliminaplantillaacabados";
            }
        }

        public string ingresaacabadosplantilla()
        {
            try
            {

                querysadapter.insertaplantilla_acabados(this.idplantilla, this.idacabados, Math.Round((Math.Round((this.cantidad), 2)), 2), Convert.ToDecimal(this.tiempototal));
                return "Agregado";
            }
            catch
            {
                return "Error(ingresaacabadosplantilla)";
            }
        }

        public DataTable devuelveacabadosplantilla()
        {
            acabadosplantilla = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelveacabados_plantillaTableAdapter();
            return acabadosplantilla.GetData(this.idplantilla);
        }

        public DataTable devuelveprocesos()
        {


            return tablaacabados.GetData();


        }

        public string borraacabado()
        {
            querysadapter.borra_acabado(this.idacabados);
            return "0";
            

            
        }

        public string insertaproceso()
        {
            try
            {
                tablaacabados.Insert(this.nombre, this.tipo, this.tiempo);
                return "Acabado Agregado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string actualizaproceso()
        {
            try
            {
                querysadapter.actualizaacabados(this.idacabados, this.nombre, this.tipo, this.tiempo);
                return "Acabado Actualizado";
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

                querysadapter.insertaficha_acabados(this.idficha, this.idacabados, Math.Round((Math.Round((this.cantidad), 2)), 2), Convert.ToDecimal(this.tiempototal));
                return "Agregado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }


        public DataTable acabados_fichas()
        {
         return acabadosfichas.GetData(this.idficha);
            
        }


        public DataTable busca_acabadosportipo()
        {
            return acabadostipo.GetData(this.tipo);
        }




        public string borra_acabadoficha()
        {
            try
            {
                querysadapter.borra_acabadosficha(this.idacabados, this.idficha);
                return "Borrado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }











    }
}
