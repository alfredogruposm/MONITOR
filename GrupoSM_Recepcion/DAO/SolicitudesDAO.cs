using System;
using System.Linq;
using System.Data;

namespace GrupoSM_Recepcion.DAO
{
    class SolicitudesDAO
    {
        
        BO.DS_MasterDatasetTableAdapters.solicitudTableAdapter tablasolicitud = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.solicitudTableAdapter();
        //BO.DS_MasterDatasetTableAdapters.solicitudTableAdapter tablasolicituds = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.solicitudTableAdapter();
        BO.DS_MasterDatasetTableAdapters.vistasolicitudes2TableAdapter solicitudes2 = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.vistasolicitudes2TableAdapter();

        BO.DS_MasterDatasetTableAdapters.numerosolicitudTableAdapter numerosolicitud = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.numerosolicitudTableAdapter();


        BO.DS_MasterDatasetTableAdapters.versolicitudesTableAdapter ver_vistasolicitudes = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.versolicitudesTableAdapter();

        BO.DS_MasterDatasetTableAdapters.devuelvesolicitudTableAdapter versolicitud = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.devuelvesolicitudTableAdapter();

        BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter querysadaptapter = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.QueriesTableAdapter();

        BO.DS_MasterDatasetTableAdapters.solicitudesrespondidasTableAdapter respondidas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.solicitudesrespondidasTableAdapter();

        BO.DS_MasterDatasetTableAdapters.VclientefichasTableAdapter vistafichasrespondidas = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.VclientefichasTableAdapter();

        BO.DS_MasterDatasetTableAdapters.solicitudclientesTableAdapter clientessolicitud = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.solicitudclientesTableAdapter();

        BO.DS_MasterDatasetTableAdapters.solicitudrespuestaTableAdapter tablasolicitudrespuesta = new GrupoSM_Recepcion.BO.DS_MasterDatasetTableAdapters.solicitudrespuestaTableAdapter();

        // idsolicitud int not null identity(100,1) primary key,
				//		 id_cliente int not null foreign key references clientes(idclientes),
				//		 asunto varchar(max),
				//		 fecha datetime,
				//		 respondido int,
				//		 descripcion varchar(max)

        public int idsolicitud { get; set; }
        public int idcliente { get; set; }
        public string asunto { get; set; }
        public DateTime fecha { get; set; }
        public int respondido { get; set; }
        public string descripcion { get; set; }

        public int devuelvenumsolicitud()
        {
            return Convert.ToInt32(numerosolicitud.GetData().Max().Column1);
        }

        public string crearespuestasolicitud()
        {
            try
            {

                querysadaptapter.creasolicitudrespuesta(this.idsolicitud);
                return "Correcto";
            }
            catch
            {
                return "Error De Coneccion";
            }
        }

        public string ingresasolicitudrespuesta()
        {
            try
            {

                tablasolicitudrespuesta.Insert(this.idsolicitud, this.fecha);
                return "Correcto";
            }
            catch
            {
                return "Error De Coneccion";
            }
        }

        public DataTable solicitudesrespondidas()
        {
            return solicitudes2.GetData();
        }

        public string ingresafechasolicitud()
        {
            
            try
            {

                querysadaptapter.respuestasolicitud(this.idsolicitud, this.fecha); 
                return "Correcto";
            }
            catch
            {
                return "Error De Coneccion";
            }
        }

        public DataTable versolicitudes()
        {
            return tablasolicitud.GetData();

        }

        public string insertasolicitud()
        {
            try
            {
                
                tablasolicitud.Insert(this.idcliente, this.asunto, this.fecha, this.respondido, this.descripcion);
                return "Solicitud Agregada Correctamente";
            }
            catch
            {
                return "Error De Coneccion";
            }
        }

        public string actualizasolicitud()
        {
            try
            {
                querysadaptapter.actualizasolicitud(this.idsolicitud, this.idcliente, this.asunto, this.descripcion);
                return "Solicitud Actualizada";
            }
            catch
            {
                return "Error de coneccion";
            }
           
        }


        public DataTable contestadas()
        {
            return vistafichasrespondidas.GetData();
        }

        public string establecerespondido()
        {
            try
            {
                querysadaptapter.establece_solicitudrespondida(this.idsolicitud);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }

        }

        public DataTable solicitudesclientes()
        {
            return clientessolicitud.GetData();
        }

       

    }
}
