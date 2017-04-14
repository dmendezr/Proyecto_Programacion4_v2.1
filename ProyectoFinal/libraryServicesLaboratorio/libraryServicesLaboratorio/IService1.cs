using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CapaBD;

namespace libraryServicesLaboratorio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<conjuntoCaracteristicas> obtieneCaracteristicas();
        // TODO: Add your service operations here
        [OperationContract]
        int ingresaSolicitud(string fechaSolicitud, int estadoSolicitud, int idTurno, int idUsuario, int idLaboratorio, string idCurso);

        [OperationContract]
        List<Turno> obtieneTurno();

        [OperationContract]
        List<Usuario> obtieneUsername();

        [OperationContract]
        List<Curso> obtieneCursos();

        [OperationContract]
        int ingresaCurso(string codCurso, string curso);

        [OperationContract]
        int modificaCurso(string codCurso, string curso);
    }



}
