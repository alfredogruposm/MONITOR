using System;
using System.Linq;
using System.Data;

namespace GrupoSM_Recepcion.DAO
{
    class Ficha_tecnicaDAO
    {

       BO.DS_MasterDatasetTableAdapters.fichassolicitudTableAdapter solicitudes_fichas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.fichassolicitudTableAdapter();

        BO.DS_MasterDatasetTableAdapters.VclientefichasTableAdapter vistafichasdg = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.VclientefichasTableAdapter();

        BO.DS_MasterDatasetTableAdapters.Vfichas_tecnicasTableAdapter vista_fichastecnicas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.Vfichas_tecnicasTableAdapter();

        BO.DS_MasterDatasetTableAdapters.numerofichatecnicaTableAdapter numeroficha = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.numerofichatecnicaTableAdapter();

        BO.DS_MasterDatasetTableAdapters.ficha_tecnicaTableAdapter fichatecnica = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ficha_tecnicaTableAdapter();

        BO.DS_MasterDatasetTableAdapters.ficha_detalleTableAdapter fichadetalle = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ficha_detalleTableAdapter();

        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();

        BO.DS_MasterDatasetTableAdapters.Vfichas_tecnicas2TableAdapter vistafichastecnicas2 = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.Vfichas_tecnicas2TableAdapter();

        BO.DS_MasterDatasetTableAdapters.regresa_fichatecnica_vista2TableAdapter fichatecnica2 = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.regresa_fichatecnica_vista2TableAdapter();
        
        BO.DS_MasterDatasetTableAdapters.ver_especificacionesfichaTableAdapter fichaespecificaciones;
        

        public int id_fichatecnica { get; set; }
        public int ficha_detalle { get; set; }
        public int cliente { get; set; }
        public int idsolicitud { get; set; }
        public string observaciones { get; set; }
        public double tiempo_costuras { get; set; }
        public double tiempo_acabados { get; set; }
        public double costeo { get; set; }
        public string nombreprenda { get; set; }
        public string modelo { get; set; }
        public string tela { get; set; }
        public double anchotela { get; set; }
        public double consumotela { get; set; }
        public string combinacion { get; set; }
        public double combinacionancho { get; set; }
        public double combinacionconsumo { get; set; }
        public string forro { get; set; }
        public double forroancho { get; set; }
        public double forroconsumo { get; set; }
        public string especificaciones { get; set; }

        public string ingresaespecificacionesficha()
        {
            try
            {
                querysadapter.insertaespecificacionesfichatecnica(this.id_fichatecnica, this.especificaciones);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable especificacionesficha()
        {
            fichaespecificaciones=new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ver_especificacionesfichaTableAdapter();
            return fichaespecificaciones.GetData(this.id_fichatecnica);
        }

        public DataTable fichatecnicavista()
        {
            return fichatecnica2.GetData(this.id_fichatecnica);
        }

        public DataTable fichas_solicitudes()
        {
            return solicitudes_fichas.GetData(this.idsolicitud);
        }


        public DataTable vistafichas()
        {
            return vistafichasdg.GetData();
        }


        public DataTable fichas_tecnicas()
        {
            return vista_fichastecnicas.GetData();
        }

        public DataTable fichas_tecnicas2()
        {
            return vistafichastecnicas2.GetData();
        }

        public int devuelveid()
        {
            return Convert.ToInt32(numeroficha.GetData().Max().Column1);
        }

        public int ingresaficha_completa()
        {
            try
            {
                fichatecnica.Insert(this.ficha_detalle, this.idsolicitud, this.cliente, this.observaciones, Math.Round((this.tiempo_costuras), 2), Math.Round((this.tiempo_acabados), 2), Math.Round((this.costeo), 2));
                return 1;
            }
            catch
            {
                return 0;
            }
        }


        public int ingresadetalle()
        {
            try
            {
                fichadetalle.Insert(this.nombreprenda, this.modelo, this.tela, this.anchotela, this.consumotela, this.combinacion, this.combinacionancho, this.combinacionconsumo, this.forro, this.forroancho, this.forroconsumo);
                return 1;
                
            }
            catch
            {
                return 0;
            }
        }

        public string actualizafichadetalle()
        {
            try
            {
                querysadapter.actualiza_fichadetalle(this.id_fichatecnica, this.nombreprenda, this.modelo, this.tela, this.anchotela, this.consumotela, this.combinacion, this.combinacionancho, this.combinacionconsumo, this.forro, this.forroancho, this.forroconsumo);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }


        public string actualizaclienteficha()
        {
            try
            {
                querysadapter.actualiza_clientefichatecnica(this.id_fichatecnica, this.cliente);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }



        public string actualizafichaparcial()
        {
            try
            {
                querysadapter.actualizafichatecnica_parcial(this.id_fichatecnica, this.observaciones, Math.Round((this.tiempo_costuras), 2), Math.Round((this.tiempo_acabados), 2), Math.Round((this.costeo), 2));
                return "Agregado Correctamente";
            }
            catch
            {
                return "Error de coneccion";
            }

        }

        public string creafichaparcial()
        {
            try
            {
                querysadapter.creafichaparcial(this.ficha_detalle, this.cliente);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }


        public string borraficha()
        {
            try
            {
                querysadapter.borra_tablas_ficha(this.id_fichatecnica);
                return "Borrado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }


        public string creaficha_parcialsolicitud()
        {
            try
            {
                querysadapter.creafichaparcial_solicitud(this.ficha_detalle, this.cliente, this.idsolicitud);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }

        }










    }
}
