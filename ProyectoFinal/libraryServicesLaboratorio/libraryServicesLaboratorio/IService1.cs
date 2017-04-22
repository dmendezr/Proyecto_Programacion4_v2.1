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

        [OperationContract]
        int ingresaTurno(int turno);

        [OperationContract]
        int modificaTurno(int idTurno, int turno);

        [OperationContract]
        List<Lab_Servidor> ObtieneLAB_Servidor();

        [OperationContract]
        int ingresaLAB_Servidor(int id_laboratorio, int id_servidor);

        [OperationContract]
        int modificaLAB_Servidor(int id_labServidor, int id_laboratorio, int id_servidor);

        [OperationContract]
        int ingresaLab_Software(string actualizado, int id_laboratorio, int id_software);

        [OperationContract]
        List<Lab_Software> obtieneLab_Software();

        [OperationContract]
        int modificaLab_Software(int id_labSW, string actualizado, int id_laboratorio, int id_software);

        [OperationContract]
        List<Laboratorio> obtienelaboratorio();

        [OperationContract]
        int ingresaLaboratorio(int cantEquipos, int piso, int ConjuntoCaract, string descripcion);

        [OperationContract]
        int modificaLaboratorio(int id_laboratorio, int cantEquipos, int piso, int ConjuntoCaract, string descripcion);

        [OperationContract]
        List<Persona> obtienePersona();

        [OperationContract]
        int ingresaPersona(int Cedula, string nombre, string apellido1, string apellido2);

        [OperationContract]
        int modificaPersona(int Cedula, string nombre, string apellido1, string apellido2);

        [OperationContract]
        List<Servidor> obtieneServidor();

        [OperationContract]
        int ingresaServidor(string servidor, string rol_servidor, string software_actual, string descripcion);

        [OperationContract]
        int modificaServidor(int id_Servidor, string servidor, string rol_servidor, string software_actual, string descripcion);

        [OperationContract]
        List<Software> obtieneSoftware();

        [OperationContract]
        int ingresaSoftware(string software, string version_sw, string descripcion);

        [OperationContract]
        int modificaSoftware(int id_software, string software, string version_sw, string descripcion);

        [OperationContract]
        List<Tipo_Usuario> obtieneTipo_Usuario();

        [OperationContract]
        int ingresaTipo_Usuario(int tipo_usuario);

        [OperationContract]
        int modificaTipo_Usuario(int id, int tipo_usuario);

        [OperationContract]
        List<Usuario> obtieneUsuario();

        [OperationContract]
        int ingresaUsuario(string username, string pass, int tipo_usuario, int cedula);

        [OperationContract]
        int modificaUsuario(int id_usuario, string username, string pass, int tipo_usuario, int cedula);

        [OperationContract]
        List<Solicitud> obtieneSolicitud();

        [OperationContract]
        List<Solicitud> EjecutaObtieneConsultas(String fecha_solicitud, int estado_solicitud, int id_Usuario, string fecha_final);

        [OperationContract]
        int EjecutaActualizaEstado(int id_Solicitud, string fecha_solicitud, int idTurno, int id_laboratorio);
    }



}
