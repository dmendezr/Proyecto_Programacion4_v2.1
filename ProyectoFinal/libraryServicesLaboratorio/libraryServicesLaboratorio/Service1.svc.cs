using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaBD;

namespace libraryServicesLaboratorio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<conjuntoCaracteristicas> obtieneCaracteristicas()
        {
            conjuntoCaracteristicas objCaract;
            List<conjuntoCaracteristicas> listCaract = new List<conjuntoCaracteristicas>();
            SqlDataReader dr;
            dr = CapaBD.metodosDatos.EjecutaProcedimientoSelect("sp_DevuelveCaracteristicas");
            while (dr.Read())
            {
               objCaract = new conjuntoCaracteristicas();
                objCaract.idConjunto = dr.GetInt32(0);
                objCaract.cantidadMemoria = dr.GetString(1);
                objCaract.cantidadHDD = dr.GetString(2);
                objCaract.procesador = dr.GetString(3);
                objCaract.velocidadProcesador = dr.GetString(4);
                objCaract.pantalla = dr.GetString(5);
                objCaract.SO = dr.GetString(6);
                objCaract.paridadSO = dr.GetString(7);
                objCaract.AC = dr.GetString(8);
                objCaract.VideoBeam = dr.GetString(9);
                listCaract.Add(objCaract);
            }
            CapaBD.metodosDatos.cierraConexion();
            return listCaract;
        }

        public int ingresaSolicitud (string fechaSolicitud, int estadoSolicitud, int idTurno, int idUsuario, int idLaboratorio,string idCurso)
        {
            estadoSolicitud = Convert.ToInt32(estadoSolicitud);
            idTurno = Convert.ToInt32(idTurno);
            idUsuario = Convert.ToInt32(idUsuario);
            idLaboratorio = Convert.ToInt32(idLaboratorio);
            return CapaBD.metodosDatos.InsertSolicitud(fechaSolicitud, estadoSolicitud, idTurno, idUsuario, idLaboratorio, idCurso);    
        }
    }
}