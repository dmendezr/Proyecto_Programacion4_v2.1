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
            return metodosDatos.EjecutarObtieneCaracteristicas();
        }

        public List<Turno> obtieneTurno () {
                return metodosDatos.EjecutaObtieneTurnos();
        }

        public List<Usuario> obtieneUsername()
        {

            return metodosDatos.EjecutaObtieneUsuarios();   
        }

        public List <Curso> obtieneCursos()
        {
            return metodosDatos.EjecutaObtieneCursos();
        }

        public int ingresaCurso (string codCurso, string curso)
        {
            try
            {
                return CapaBD.metodosDatos.EjecutaInsertCurso(codCurso, curso);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int modificaCurso (string codCurso, string curso)
        {
            return CapaBD.metodosDatos.EjecutaUpdateCurso(codCurso, curso);
        }

        public int ingresaSolicitud (string fechaSolicitud, int estadoSolicitud, int idTurno, int idUsuario, int idLaboratorio,string idCurso)
        {
            try
            {
                estadoSolicitud = Convert.ToInt32(estadoSolicitud);
                idTurno = Convert.ToInt32(idTurno);
                idUsuario = Convert.ToInt32(idUsuario);
                idLaboratorio = Convert.ToInt32(idLaboratorio);
                return CapaBD.metodosDatos.InsertSolicitud(fechaSolicitud, estadoSolicitud, idTurno, idUsuario, idLaboratorio, idCurso);
            }
            finally
            {

            }
           
        }
    }
}