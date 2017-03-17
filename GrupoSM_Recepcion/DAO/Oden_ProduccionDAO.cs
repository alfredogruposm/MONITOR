using System;
using System.Linq;
using System.Data;

namespace GrupoSM_Recepcion.DAO
{
    class Oden_ProduccionDAO
    {


        BO.DS_MasterDatasetTableAdapters.numeroproduccionTableAdapter numeroproduccion = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.numeroproduccionTableAdapter();
        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();
        BO.DS_MasterDatasetTableAdapters.ordenesvistaTableAdapter ordenesvista = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ordenesvistaTableAdapter();
        BO.DS_MasterDatasetTableAdapters.cantidadprendas_ordenTableAdapter cantidaprendas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.cantidadprendas_ordenTableAdapter();
        BO.DS_MasterDatasetTableAdapters.ordenesvista_aviosTableAdapter ordenesavios = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ordenesvista_aviosTableAdapter();
        BO.DS_MasterDatasetTableAdapters.ordenesvista_telasTableAdapter ordenestelas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ordenesvista_telasTableAdapter();
        BO.DS_MasterDatasetTableAdapters.ver_produccion_detalleTableAdapter tabladetalle = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ver_produccion_detalleTableAdapter();
        BO.DS_MasterDatasetTableAdapters.vista_prendas_trazadoTableAdapter tablaprendastrazo = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.vista_prendas_trazadoTableAdapter();
        BO.DS_MasterDatasetTableAdapters.vista_prendas_corteTableAdapter tablaprendascorte = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.vista_prendas_corteTableAdapter();
        BO.DS_MasterDatasetTableAdapters.VistaActivosMonitorTableAdapter vistaactivos = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.VistaActivosMonitorTableAdapter();
        BO.DS_MasterDatasetTableAdapters.VistaTerminadosMonitorTableAdapter vistaterminados = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.VistaTerminadosMonitorTableAdapter();
        BO.DS_MasterDatasetTableAdapters.PellonesTableAdapter pellones;
       
        public DataTable vistamonitoractivos()
        {
            return vistaactivos.GetData();
        }

        public DataTable vistamonitorterminados()
        {
            return vistaterminados.GetData();
        }

        public string eliminaproduccion()
        {
            try
            {
                querysadapter.elimina_ordenproduccion(this.idorden);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion(eliminaorden)";
            }
        }


        public int idorden { get; set; }
        public int idpellon { get; set; }
        public int idcliente { get; set; }
        public int avios_completo { get; set; }
        public int tela_completa { get; set; }
        public int ruta_establecida { get; set; }
        public int trazado_completo { get; set; }
        public int tendido_completo { get; set; }
        public int corte { get; set; }
        public int separado { get; set; }
        public int en_maquila { get; set; }
        public int acabados { get; set; }
        public int calidad { get; set; }
        public int Terminado { get; set; }
        public string asunto { get; set; }
        public string Pellon { get; set; }
        public string observaciones { get; set; }
        public string Modelo { get; set; }
        public string Composicion { get; set; }
        public string Marca { get; set; }
        public DateTime fechaentrega {get;set;}
        public DateTime fechainicio {get;set;}
        public DateTime fecha_avios {get;set;}
        public DateTime fecha_tela {get;set;}
        public DateTime fecha_ruta {get;set;}
        public DateTime fecha_trazado_inicio {get;set;}
        public DateTime fecha_trazado_terminado {get;set;}
        public DateTime fecha_tendido {get;set;}
        public DateTime fecha_corte_inicio {get;set;}
        public DateTime fecha_corte_terminado {get;set;}
        public DateTime fecha_separado_inicio {get;set;}
        public DateTime fecha_separado_terminado {get;set;}
        public DateTime fecha_maquila_salida {get;set;}
        public DateTime fecha_maquila_entrada {get;set;}
        public DateTime fecha_acabados_inicio {get;set;}
        public DateTime fecha_acabados_terminado { get; set; }

        public DataTable datosproduccionreporteFull()
        {
            BO.DS_MasterDatasetTableAdapters.datos_orden_reporteCompletoTableAdapter datos = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.datos_orden_reporteCompletoTableAdapter();
            return datos.GetData(this.idorden);
        }

        public DataTable datosproduccionreporte()
        {
            BO.DS_MasterDatasetTableAdapters.datos_orden_reporteTableAdapter datos = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.datos_orden_reporteTableAdapter();
            return datos.GetData(this.idorden);
        }

        public DataTable numeroprendasreporte()
        {
            BO.DS_MasterDatasetTableAdapters.datos_cantidadprendas_ordenTableAdapter numero = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.datos_cantidadprendas_ordenTableAdapter();
            return numero.GetData(this.idorden);
        }

        public string termina_maquilaprendas()
        {
            try
            {
                querysadapter.prendas_termina_maquila(this.idorden);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string insertapellones()
        {
            try
            {
                pellones = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.PellonesTableAdapter();
                pellones.Insert(this.idorden, this.Pellon, this.Modelo, this.Composicion, this.Marca);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable devuelvepellones()
        {
            BO.DS_MasterDatasetTableAdapters.devuelvepellonesTableAdapter pellones = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelvepellonesTableAdapter();
            return pellones.GetData(this.idorden);
        }

        public string actualizapellon()
        {
            try
            {
                querysadapter.actualizapellones(this.idorden, this.Pellon, this.Modelo, this.Composicion, this.Marca);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string actualiza_corte()
        {
            try
            {
                querysadapter.actualiza_prendacorte(this.idorden, this.fecha_corte_terminado);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion(actualizacorte)";
            }
        }

        public string actualizatendidoproduccion()
        {
            try
            {
                querysadapter.actualiza_tendidoterminado(this.idorden, this.fecha_tendido);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable tablaprendascortes()
        {
            return tablaprendascorte.GetData();
        }

        public string actualizaacroteproduccion()
        {
            try
            {
                querysadapter.actualiza_acorteproduccion(this.idorden, this.fecha_trazado_terminado);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string actualizatrazoproduccion()
        {
            try
            {
                querysadapter.actualizaproduccion_trazo(this.idorden, this.fecha_trazado_inicio);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        

        public int devuelveid_max()
        {
            return Convert.ToInt32(numeroproduccion.GetData().Max().Column1);
        }


        public int devuelve_numeroprendas()
        {
            return Convert.ToInt32(cantidaprendas.GetData(this.idorden).Max().Column1);
        }


        public int ingresaordenparcial()
        {
            try
            {
                querysadapter.ingresa_ordenparcial(this.idcliente, this.asunto);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable prendas_entrazo()
        {
            return tablaprendastrazo.GetData();
        }

        public string actualizaobservacion()
        {
            try
            {
                querysadapter.actualizaobservaciones_orden(this.idorden, this.observaciones);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string actualizafechainicio()
        {
            try
            {
                querysadapter.actualiza_fechainicio(this.idorden, this.fechainicio);
                return "Correcto";
            }
            catch
            {
                return "Error de conecccion";
            }
        }


        public DataTable ordenesvistacorta()
        {
            return ordenesvista.GetData();
        }

        public DataTable ordenesvistatelas()
        {
            return ordenestelas.GetData();
        }

        public DataTable ordenesvistaavios()
        {
            return ordenesavios.GetData();
        }

        public DataTable ver_producciondetalle()
        {
            return tabladetalle.GetData(this.idorden);
        }

        public int actualizadetalles_tela()
        {
            querysadapter.actualiza_estado_teladetalle(this.idorden);
            return 1;
        }

        public int actualiza_orden_telas()
        {
            querysadapter.actualiza_orden_tela(this.idorden, this.fecha_tela);
            return 1;
        }

    }
}
