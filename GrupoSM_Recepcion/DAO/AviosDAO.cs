using System;
using System.Linq;
using System.Data;

namespace GrupoSM_Recepcion.DAO
{
    class AviosDAO
    {
        BO.DS_MasterDatasetTableAdapters.devuelvevistabodegaaviostipo2TableAdapter vistabodegareportetipo = new BO.DS_MasterDatasetTableAdapters.devuelvevistabodegaaviostipo2TableAdapter();
        BO.DS_MasterDatasetTableAdapters.ver_avios_fichasTableAdapter ver_aviosficha = new BO.DS_MasterDatasetTableAdapters.ver_avios_fichasTableAdapter();
        BO.DS_MasterDatasetTableAdapters.vistabodegaavios2TableAdapter vistabodegadeavios = new BO.DS_MasterDatasetTableAdapters.vistabodegaavios2TableAdapter();
        BO.DS_MasterDatasetTableAdapters.aviosTableAdapter tablaavios = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.aviosTableAdapter();
        BO.DS_MasterDatasetTableAdapters.busca_aviostipoBASEPortipoTableAdapter tablaaviosbasetipo = new BO.DS_MasterDatasetTableAdapters.busca_aviostipoBASEPortipoTableAdapter();
        BO.DS_MasterDatasetTableAdapters.avios_detalleTableAdapter tabladetalleavios = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.avios_detalleTableAdapter();
        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter querysadapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();
        BO.DS_MasterDatasetTableAdapters.avios_bodegaTableAdapter tablabodega = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.avios_bodegaTableAdapter();
        BO.DS_MasterDatasetTableAdapters.numeroaviosTableAdapter numeroavio = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.numeroaviosTableAdapter();
        BO.DS_MasterDatasetTableAdapters.avios_mas_bodegaTableAdapter aviosvista = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.avios_mas_bodegaTableAdapter();
        BO.DS_MasterDatasetTableAdapters.avios_produccionTableAdapter tablaaviosproduccion = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.avios_produccionTableAdapter();
        BO.DS_MasterDatasetTableAdapters.vistabodegaavios3TableAdapter vistabodegaaviosfaltantes = new BO.DS_MasterDatasetTableAdapters.vistabodegaavios3TableAdapter();
        BO.DS_MasterDatasetTableAdapters.vistabodegaavios4TableAdapter vistabodegaavioscatalogo = new BO.DS_MasterDatasetTableAdapters.vistabodegaavios4TableAdapter();
        BO.DS_MasterDatasetTableAdapters.Existen_aviosproduccionTableAdapter existeavioproduccion = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.Existen_aviosproduccionTableAdapter();
        BO.DS_MasterDatasetTableAdapters.avios_orden_asignacionesTableAdapter aviostablaasignaciones = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.avios_orden_asignacionesTableAdapter();
        BO.DS_MasterDatasetTableAdapters.busca_aviostipoTableAdapter aviostipo = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.busca_aviostipoTableAdapter();
        BO.DS_MasterDatasetTableAdapters.devuelveaviosproduccionTableAdapter aviosproduccion = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelveaviosproduccionTableAdapter();
        BO.DS_MasterDatasetTableAdapters.busca_tipo_aviosmasbodegaTableAdapter tipomasbodega = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.busca_tipo_aviosmasbodegaTableAdapter();
        BO.DS_MasterDatasetTableAdapters.devuelveavios_plantillaTableAdapter aviosplantilla;
        BO.DS_MasterDatasetTableAdapters.numeroaviosproduccionTableAdapter numeroaviosproduccion;
        BO.DS_MasterDatasetTableAdapters.ColorAvioTableAdapter tablacoloravios;
        BO.DS_MasterDatasetTableAdapters.avios_impresionTableAdapter impresionavios;
        BO.DS_MasterDatasetTableAdapters.avios_vistaasignacionTableAdapter aviosasignacion;
        BO.DS_MasterDatasetTableAdapters.devuelvenumeroprendascolorTableAdapter numeroprendascolor;
        BO.DS_MasterDatasetTableAdapters.AviosSubgruposTableAdapter aviossubgrupostabla;
        BO.DS_MasterDatasetTableAdapters.devuelvesubgruposcolorTableAdapter aviossubgrupos;
        
        //                    id_avios int not null identity(100,1) primary key,						
        //                    nombre varchar(max),
        //                    tipo int not null,
        //                    precio float
        //                    id_avios_detalle int not null identity(100,1) primary key,							
        //                    id_ficha int not null foreign key references ficha_tecnica(idficha_tecnica),
        //                    id_avio int not null foreign key references avios(id_avios),
        //                    cantidad float not null,
        //                    costo float not null

        public int id_ficha_avio { get; set; }
        public int idavios { get; set; }
        public int idplantilla { get; set; }
        public string nombre { get; set; }
        public string Color { get; set; }
        public int tipo { get; set; }
        public double precio { get; set; }
        public int iddetalle { get; set; }
        public double cantidad { get; set; }
        public double costo { get; set; }
        public int idaviosbodega { get; set; }
        public int idproduccion { get; set; }
        public double cantidadasignada { get; set; }
        public double cantidadbodega { get; set; }
        public DateTime fecha { get; set; }
        public double cantidad_ficha { get; set; }
        //Convert.ToInt32(numeroavio.GetData().Max().Column1);
        
            public DataTable devuelvebodegaaviosparaimprimir()
        {
            return vistabodegadeavios.GetData();
        }

        public DataTable devuelvefaltantesaviosbodega()
        {
            return vistabodegaaviosfaltantes.GetData();
        }

        public DataTable devuelvecatalogoaviosbodega()
        {
            return vistabodegaavioscatalogo.GetData();
        }

        public string Actualizaaviosproduccion()
        {
            try
            {
                querysadapter.actualizaavioproduccionsubgrupo(this.idavios, this.iddetalle);
                return "Correcto";
            }
            catch
            {
                return "Error(ActualizaProducSubGrupos)";
            }
        }

        public DataTable vistaimpresionbodegaaviosportipo()
        {
            return vistabodegareportetipo.GetData(this.tipo);
        }
        public string eliminaaviossubgruposcolor()
        {
            try
            {
                querysadapter.eliminaaviossubgrupos(this.idavios);
                return "Correcto";
            }
            catch
            {
                return "Error(eliminaviossubgrupos)";
            }
        }

        public string ingresaaviossubgrupos()
        {
            try
            {
                aviossubgrupostabla = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.AviosSubgruposTableAdapter();
                aviossubgrupostabla.Insert(this.idavios, this.iddetalle);
                return "Correcto";
            }
            catch
            {
                return "Error(ingresasubgrupos)";
            }
        }

        public DataTable devuelveaviossubgruposcolor()
        {
            aviossubgrupos = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelvesubgruposcolorTableAdapter();
            return aviossubgrupos.GetData(this.idavios);
        }

        public DataTable devuelveaviostipobase()
        {
            BO.DS_MasterDatasetTableAdapters.busca_aviostipoBASETableAdapter aviosbase = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.busca_aviostipoBASETableAdapter();
            return aviosbase.GetData();
        }

        public int numerocolorprendas()
        {
            numeroprendascolor = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelvenumeroprendascolorTableAdapter();
            return Convert.ToInt32(numeroprendascolor.GetData(this.idproduccion, this.Color).Max().Cantidad_prendas);

        }

        public DataTable devuelveaviosasignaciones()
        {
            aviosasignacion = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.avios_vistaasignacionTableAdapter();
            return aviosasignacion.GetData(this.idproduccion);
            //return aviostablaasignaciones.GetData(this.idproduccion);
        }

        public DataTable avios_asignacionbodega()
        {
            aviosasignacion = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.avios_vistaasignacionTableAdapter();
            return aviosasignacion.GetData(this.idproduccion);
        }

        public DataTable aviosimpresion()
        {
            impresionavios = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.avios_impresionTableAdapter();
            return impresionavios.GetData(this.idproduccion);
        }

        public DataTable devuelveplantillaavios()
        {
            aviosplantilla=new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelveavios_plantillaTableAdapter();
            return aviosplantilla.GetData(this.idplantilla);
        }

        public string insertaaviosplantilla()
        {
            try
            {

                querysadapter.insertaplantilla_avios(this.idplantilla, this.idavios, this.cantidad, this.costo);
                return "Correcto";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        public string eliminaaviosplantilla()
        {
            try
            {

                querysadapter.eliminaplantilla_avios(this.idplantilla, this.idavios);
                return "Correcto";
            }
            catch
            {
                return "Error(eliminaaviosplantilla)";
            }
        }

        public DataTable aviosproduc()
        {
            return aviosproduccion.GetData(this.idproduccion);
        }

        public string actualizabodegaavios()
        {
            try
            {
                int numero = Convert.ToInt32(this.cantidad);
                querysadapter.actualizabodegaavios(this.idavios, numero);
                return "Correcto";
            }
            catch
            {
                return "A habido un error";
            }
        }

        public string eliminaaviosproduccion()
        {
            try
            {
                querysadapter.eliminaaviosproduccion(this.idproduccion);
                return "Correcto";
            }
            catch
            {
                return "A habido un error";
            }
        }

        public string actualizabodega_avios()
        {
            querysadapter.actualiza_bodegaavios(this.idaviosbodega, Math.Round((this.cantidad), 2));
            return "Correcto";
        }

        public DataTable aviosbodega()
        {
            return aviosvista.GetData();
        }

        public int numeros_avios()
        {
            return Convert.ToInt32(numeroavio.GetData().Max().Column1);
        }

        public int numero_avios_produccion()
        {
            numeroaviosproduccion = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.numeroaviosproduccionTableAdapter();
            return Convert.ToInt32(numeroaviosproduccion.GetData().Max().Column1);
        }

        public string ingresacoloravios()
        {
            try
            {
                tablacoloravios = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.ColorAvioTableAdapter();
                int numero = numero_avios_produccion();
                tablacoloravios.Insert(numero, this.Color);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable sacar_avios()
        {
            return ver_aviosficha.GetData(this.id_ficha_avio);
        }


        public string insertabodega()
        {

            tablabodega.Insert(idavios, this.cantidad);
            return "correcto";

        }


        public string agregar_avios()
        {
            try
            {
                tablaavios.Insert(this.nombre, this.tipo, Convert.ToDouble(this.precio));
                return "Agregado Correctamente";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string agregar_detalle()
        {
            try
            {
                querysadapter.insertaficha_avios(this.id_ficha_avio, this.idavios, Math.Round((this.cantidad), 2), this.costo);
                return "Agregado Correctamente";
            }
            catch(Exception ex) 
            {
                return ex.ToString();
            }
        }

        public DataTable sacartodosavios()
        {
            return tablaavios.GetData();
        }

        public string actualizaavios()
        {
            try
            {
                querysadapter.actualiza_avios(this.idavios, this.nombre, this.tipo, this.precio);
                return "Actualizado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string ingresaavios_produccion()
        {
            try
            {
                tablaaviosproduccion.Insert(this.idavios, this.idproduccion, this.cantidad, this.cantidad_ficha);
                return "Agregado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public int existe_produccionavios()
        {
            return Convert.ToInt32(existeavioproduccion.GetData(this.idproduccion).Max().Return_Status);
        }

        

        public string verificaavios()
        {
            try
            {
                querysadapter.verificaordenavios(this.idproduccion, this.id_ficha_avio, this.fecha);
                return "Agregado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }


        public string actualizaavios_bodegaasignaciones()
        {
            try
            {

                querysadapter.actualiza_bodega_asignaciones(this.idavios, this.idproduccion, Math.Round((this.cantidadasignada), 2), Math.Round((this.cantidadbodega), 2), this.iddetalle);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable busca_aviosportipo()
        {
            return aviostipo.GetData(this.tipo);
        }

        public DataTable busca_aviosportipobase()
        {
            return tablaaviosbasetipo.GetData(this.tipo); 
        }

        public string borra_avioficha()
        {
            try
            {
                querysadapter.borra_aviosficha(this.idavios, this.id_ficha_avio);
                return "Borrado";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable buscatipobodega()
        {
            return tipomasbodega.GetData(this.tipo);
        }

    }
}
