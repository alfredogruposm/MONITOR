using System;
using System.Linq;
using System.Data;

namespace GrupoSM_Recepcion.DAO
{
    class PlantillasDAO
    {
        BO.DS_MasterDatasetTableAdapters.plantillasTableAdapter tablaplantillas;
        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter querysadapter;
        BO.DS_MasterDatasetTableAdapters.numeroplantillaTableAdapter devuelveidplantilla;
        BO.DS_MasterDatasetTableAdapters.devuelveespecificacionesplantillaTableAdapter devuelveespecificaciones;

        public string nombre { get; set; }
        public string especificaciones { get; set; }
        public string observaciones { get; set; }
        public int idplantilla { get; set; }
        public int idfichatecnica { get; set; }


        public string actualizaespecificacionesfichatecnica()
        {
            try
            {
                querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();
                querysadapter.actualizaespecificacionesdeplantilla(this.idfichatecnica, this.observaciones, this.especificaciones);
                return "Correcto";
            }
            catch
            {
                return "Error(insertaespecificacionesdeplantillafichatecnica)";
            }
        }



        public string insertaespecificacionesplant()
        {
            try
            {
                querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();
                querysadapter.InsertaEspecificacionesplantillas(this.idplantilla, this.observaciones, this.especificaciones);
                return "Correcto";
            }
            catch
            {
                return "Error(insertaespecificacionesplantilla)";
            }
        }

        public DataTable devuelveespecificacionesplant()
        {
            devuelveespecificaciones = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelveespecificacionesplantillaTableAdapter();
            return devuelveespecificaciones.GetData(this.idplantilla);
        }


        public int numeroplantilla()
        {
            devuelveidplantilla = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.numeroplantillaTableAdapter();
            return Convert.ToInt32(devuelveidplantilla.GetData().Max().Column1);
        }

        public string eliminaplantilla()
        {
            try
            {
                querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();
                querysadapter.eliminaplantilla(this.idplantilla);
                return "Correcto";
            }
            catch
            {
                return "Error(eliminaplantilla)";
            }
        }

        public string modificaplantilla()
        {
            try
            {
                querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();
                querysadapter.modificaplantillas(this.idplantilla, this.nombre);
                return "Correcto";
            }
            catch
            {
                return "Error(modificaplantilla)";
            }
        }

        public string insertaplantilla()
        {
            try
            {
                tablaplantillas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.plantillasTableAdapter();
                tablaplantillas.Insert(this.nombre);
                return "Correcto";
            }
            catch
            {
                return "Error(insertaplantilla)";
            }
        }

        public DataTable devuelvelistado()
        {
            tablaplantillas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.plantillasTableAdapter();
            return tablaplantillas.GetData();
        }

    }
}
