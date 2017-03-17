using System;
using System.Data;

namespace GrupoSM_Recepcion.DAO
{
    class TelasDAO
    {
        BO.DS_MasterDatasetTableAdapters.telasbodegavista_porProveedorTableAdapter telasbodegaproveedor = new BO.DS_MasterDatasetTableAdapters.telasbodegavista_porProveedorTableAdapter();
        BO.DS_MasterDatasetTableAdapters.telasbodegavista_porclienteTableAdapter telasbodegavistacliente = new BO.DS_MasterDatasetTableAdapters.telasbodegavista_porclienteTableAdapter();
        BO.DS_MasterDatasetTableAdapters.telaTableAdapter tablatela = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.telaTableAdapter();
        BO.DS_MasterDatasetTableAdapters.tela_bodegaTableAdapter tablatelabodega = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.tela_bodegaTableAdapter();
        BO.DS_MasterDatasetTableAdapters.ver_bodegatelas_tipoTableAdapter verbodega_tipo = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ver_bodegatelas_tipoTableAdapter();
        BO.DS_MasterDatasetTableAdapters.ver_asignados_tipoTableAdapter ver_asignados = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ver_asignados_tipoTableAdapter();
        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();
        BO.DS_MasterDatasetTableAdapters.telacosteoTableAdapter tablatelacosteo = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.telacosteoTableAdapter();
        BO.DS_MasterDatasetTableAdapters.ver_asignadostelasTableAdapter verasignados = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ver_asignadostelasTableAdapter();
        BO.DS_MasterDatasetTableAdapters.telasbodegavista_porNombreTableAdapter telasbodegapornombre = new BO.DS_MasterDatasetTableAdapters.telasbodegavista_porNombreTableAdapter();
        BO.DS_MasterDatasetTableAdapters.telas_produccioncorteTableAdapter tablatelasproduccion = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.telas_produccioncorteTableAdapter();
        BO.DS_MasterDatasetTableAdapters.telasbodegavistaTableAdapter telasbodegavista = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.telasbodegavistaTableAdapter();

        //idtela int not null identity(100,1) primary key,
        //                    cliente int not null foreign key references clientes(idclientes),
        //                    proveedor int not null foreign key references proveedor(idproveedor),
        //                    fecha_entrada datetime,
        //                    nombre_descripcion varchar(max),
        //                    metros float,
        //                    composicion varchar(max),
        //                    color varchar(max),
        //                    ancho float


        public int idtela_bodega { get; set; }
        public int cliente { get; set; }
        public int proveedor { get; set; }
        public DateTime fecha_entrada { get; set; }
        public string nombre_descripcion { get; set; }
        public double metros { get; set; }
        public string composicion { get; set; }
        public string color { get; set; }
        public double ancho { get; set; }
        public int tipo { get; set; }

        public int idtelacosteo { get; set; }
        public string nombretelacosteo { get; set; }
        public double precio { get; set; }

        public DataTable devuelvetelasbodegaNombre()
        {
            return telasbodegapornombre.GetData(this.nombre_descripcion);
        }

        public DataTable devuelvetelasbodegacliente()
        {
            return telasbodegavistacliente.GetData(this.cliente);
        }

        public DataTable devuelvetelasbodegaproveedor()
        {
            return telasbodegaproveedor.GetData(this.proveedor);
        }

        public string modifica_telascompleto()
        {
            try
            {
                querysadapter.modifica_telas_bodega(this.idtela_bodega, this.nombre_descripcion, Math.Round((this.metros), 2), this.composicion, this.color, this.ancho, this.tipo);

                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string borra_telasbodega()
        {
            try
            {
                querysadapter.borra_telabodega(this.idtela_bodega);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        //                      id_tela_produccion int not null identity(100,1) primary key,
        //                    
        //                    produccion int not null foreign key references produccion_detalle(id_produccion_detalle),
        //                    fecha_entrada_produccion datetime,
        //                    
        //                    largo_trazo float,
        //                    paños float,
        //                    utilizado_tela float,
        //                    retazo_tela float,
        //                    saldo_tela float,
        //                    faltante_tela float,
        //                    precio_metro float


        public int id_tela_produccion { get; set; }
        public int produccion { get; set; }
        public DateTime fecha_entrada_produccion { get; set; }
        public double largo_trazo { get; set; }
        public double paños { get; set; }
        public double utilizado_tela { get; set; }
        public double retazo_tela { get; set; }
        public double saldo_tela { get; set; }
        public double faltante_tela { get; set; }
        public double precio_metro { get; set; }

        public string actualizatelacorte()
        {
            try
            {
                querysadapter.actualiza_telascorte(this.id_tela_produccion, this.largo_trazo, this.paños, Math.Round((this.utilizado_tela), 2), Math.Round((this.retazo_tela), 2), Math.Round((this.saldo_tela), 2), Math.Round((this.faltante_tela), 2)); 
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }


        public DataTable telascorteproduccion()
        {
            return tablatelasproduccion.GetData(this.produccion);
        }

        public DataTable vertelasproduccion()
        {
            return verasignados.GetData(this.id_tela_produccion);
        }

        public string modificatela_bodega()
        {
            try
            {
                querysadapter.modificatelabodega(this.idtela_bodega, Math.Round((this.metros), 2));
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable tablatelascosteo()
        {
            return tablatelacosteo.GetData();
        }

        public string insertatelacosteo()
        {
            try
            {
                tablatelacosteo.Insert(this.nombretelacosteo, this.precio);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string modificatelascosteo()
        {
            try
            {
                querysadapter.modificatelacosteo(this.nombretelacosteo, this.precio, this.idtelacosteo);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string eliminatelascosteo()
        {
            try
            {
                querysadapter.eliminatelacosteo(this.idtelacosteo);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string insertatela()
        {
            tablatelabodega.Insert(this.cliente, this.proveedor, this.fecha_entrada, this.nombre_descripcion, Math.Round((this.metros), 2), this.composicion, this.color, this.ancho, this.tipo);
            return "Correcto";
        }

       

        public string elimina_entradatelaasignada()
        {
            try
            {
                querysadapter.borratelaproduccionasiganada(this.produccion, this.fecha_entrada, this.nombre_descripcion, this.tipo);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable tablatelas()
        {
            return telasbodegavista.GetData();
        }

        public DataTable bodegastipo()
        {
            return verbodega_tipo.GetData(this.cliente, this.tipo);
        }


        public DataTable vertelas_asignados()
        {
            return ver_asignados.GetData(this.tipo, this.produccion);
        }

        public string agregar_telaproduccion()
        {
            tablatela.Insert(this.cliente, this.proveedor, this.produccion, this.fecha_entrada_produccion, this.nombre_descripcion, Math.Round((this.metros), 2), this.composicion, this.color, this.ancho, this.largo_trazo, this.paños, Math.Round((this.utilizado_tela), 2), Math.Round((this.retazo_tela), 2), Math.Round((this.saldo_tela), 2), Math.Round((this.faltante_tela), 2), this.precio_metro, this.tipo);
            return "Correcto";
        }


        public string borratelabodega()
        {
            querysadapter.borratela_bodega(this.idtela_bodega);
            return "correcto";
        }

        public string borra_telasasignadas()
        {
            querysadapter.borra_telas_asignadas(this.tipo, this.produccion);
            return "correcto";
        }

    }
}
