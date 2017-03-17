using System;
using System.Linq;
using System.Data;

namespace GrupoSM_Recepcion.DAO
{
    class SalidasMaquilaDAO
    {
        BO.DS_MasterDatasetTableAdapters.vista_prendas_maquilaTableAdapter prendasmaquila = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.vista_prendas_maquilaTableAdapter();
        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter queriesadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();
        BO.DS_MasterDatasetTableAdapters.vista_prendas_entradaTableAdapter vistaentrada = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.vista_prendas_entradaTableAdapter();
        BO.DS_MasterDatasetTableAdapters.prendas_entradaTableAdapter vistaprendas_entrada = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.prendas_entradaTableAdapter();
        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter queryesadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();

        public int idsalida { get; set; }
        public int idproduccion { get; set; }
        public int maquilador { get; set; }
        public int prendas_enviadas { get; set; }
        public int prendas_recibidas { get; set; }
        public double manobra { get; set; }

        //create table salidamaquiladetalle(id_salidadetalle int not null identity(100,1) primary key,
        //                            idproduccion int not null foreign key references orden_produccion(id_orden),
        //                            Fecha datetime,
        //                            Modelo varchar(max),
        //                            Mano_de_obra decimal(18, 2),
        //                            Prenda varchar(max),
        //                            Tela varchar(max),
        //                            Notas varchar(max),
        //                            Especificaciones varchar(max),
        //                            Pagare varchar(max),
        //                            Maquilador varchar(max));
        //                            GO


        public int id_salidadetalle { get; set; }
        public int idficha { get; set; }
        public DateTime Fecha { get; set; }
        public string Modelo { get; set; }
        public string Prenda { get; set; }
        public string Tela { get; set; }
        public string Notas { get; set; }
        public string Especificaciones { get; set; }
        public string Pagare { get; set; }
        public string MaquiladorT { get; set; }
        public string texto1 { get; set; }
        public string texto2 { get; set; }

        public decimal consumocosturaficha()
        {
            BO.DS_MasterDatasetTableAdapters.devuelvetiempodecosturaTableAdapter tiempo = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelvetiempodecosturaTableAdapter();
            return Convert.ToDecimal(tiempo.GetData(this.idficha).Max().tiempo_costura.ToString());
        }

        public string termina_acabados()
        {
            try
            {
                queriesadapter.prendas_termina_acabados(idproduccion);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string ingresa_devoluciones()
        {
            try
            {
                queriesadapter.actualiza_prendas_devoluciones(@idproduccion, this.prendas_recibidas);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string actualizaproduccionmaquilainterior()
        {
            try
            {
                queriesadapter.actualiza_produccionmaquilainterior(this.idproduccion);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }
        public DataTable prendas_entrada_cotejo()
        {
            return vistaprendas_entrada.GetData(this.idproduccion);
        }

        public DataTable prendas_entrada()
        {
            return vistaentrada.GetData();
        }

        public DataTable vistamaquila()
        {
            return prendasmaquila.GetData();
        }


        public string salidamaquila()
        {
            try
            {
                queriesadapter.actualiza_prendasalidamaquila(this.idproduccion, this.maquilador, this.prendas_enviadas, Math.Round((this.manobra), 2));
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion SALIDA MAQUILA";
            }
        }

        public string insertadetallesalida()
        {
            try
            {
                queriesadapter.salidamaquiladetalleinsert(this.idproduccion, this.Fecha, this.Modelo, Convert.ToDecimal(Math.Round((this.manobra), 2)), this.Prenda, this.Tela, this.Notas, this.Especificaciones, this.Pagare, this.MaquiladorT);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion INSERTA DETALLES";
            }
        }

        public string insertadetallesalidaavios()
        {
            try
            {
                BO.DS_MasterDatasetTableAdapters.salidadetalleaviosTableAdapter salida = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.salidadetalleaviosTableAdapter();
                salida.Insert(this.idproduccion, this.texto1, this.texto2);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string ELIMINAdetallesalidaavios()
        {
            try
            {
                queriesadapter.eliminadetallesalidaavios(this.id_salidadetalle);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion SALIDA MAQUILA";
            }
        }

        

        public DataTable salidasavios()
        {
            BO.DS_MasterDatasetTableAdapters.devuelvesalidaaviosTableAdapter salidas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelvesalidaaviosTableAdapter();
            return salidas.GetData(this.idproduccion);
        }

        public DataTable devuelvedetallesalidas()
        {
            BO.DS_MasterDatasetTableAdapters.devuelvesalidadetalleTableAdapter salidas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelvesalidadetalleTableAdapter();
            return salidas.GetData(this.idproduccion);
        }


        public DataTable devuelvehojacorte1()
        {
            BO.DS_MasterDatasetTableAdapters.vistahojacorte1TableAdapter vista = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.vistahojacorte1TableAdapter();
            return vista.GetData(this.idproduccion);
        }

    }
}
