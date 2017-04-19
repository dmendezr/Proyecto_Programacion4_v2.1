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

        public List<Turno> obtieneTurno()
        {
            return metodosDatos.EjecutaObtieneTurnos();
        }

        public List<Usuario> obtieneUsername()
        {

            return metodosDatos.EjecutaObtieneUsuarios();
        }

        public List<Curso> obtieneCursos()
        {
            return metodosDatos.EjecutaObtieneCursos();
        }

        public int ingresaCurso(string codCurso, string curso)
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

        public int modificaCurso(string codCurso, string curso)
        {
            return CapaBD.metodosDatos.EjecutaUpdateCurso(codCurso, curso);
        }

        public int ingresaSolicitud(string fechaSolicitud, int estadoSolicitud, int idTurno, int idUsuario, int idLaboratorio, string idCurso)
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

        public int ingresaTurno(int turno)
        {
            try
            {
                turno = Convert.ToInt32(turno);

                return CapaBD.metodosDatos.EjecutaInsertTurno(turno);
            }
            finally
            {

            }

        }

        public int modificaTurno(int idTurno, int turno)
        {
            
            return CapaBD.metodosDatos.EjecutaUpdateTurno(idTurno, turno);
        }

        public List<Lab_Servidor> ObtieneLAB_Servidor()
        {
            return metodosDatos.EjecutaObtieneLab_Servidor();
        }

        public int ingresaLAB_Servidor(int id_laboratorio, int id_servidor)
        {
            try
            {
                id_laboratorio = Convert.ToInt32(id_laboratorio);
                id_servidor = Convert.ToInt32(id_servidor);

                return CapaBD.metodosDatos.EjecutaInsertLAB_Servidor(id_laboratorio, id_servidor);
            }
            finally
            {

            }

        }
        
        public int modificaLAB_Servidor(int id_labServidor, int id_laboratorio, int id_servidor)
        {

            return CapaBD.metodosDatos.EjecutaUpdateLAB_Servidor(id_labServidor, id_laboratorio, id_servidor);
        }

        public int ingresaLab_Software(string actualizado, int id_laboratorio, int id_software)
        {
            try
            {

                id_laboratorio = Convert.ToInt32(id_laboratorio);
                id_software = Convert.ToInt32(id_software);

                return CapaBD.metodosDatos.EjecutaInsertLab_Software(actualizado,id_laboratorio, id_software);
            }
            finally
            {

            }

        }

        public List<Lab_Software> obtieneLab_Software()
        {
            return metodosDatos.EjecutaObtieneLab_Software();
        }

        public int modificaLab_Software(int id_labSW, string actualizado, int id_laboratorio, int id_software)
        {

            return CapaBD.metodosDatos.EjecutaUpdateLab_Software(id_labSW, actualizado, id_laboratorio, id_software);
        }


        public List<Laboratorio> obtienelaboratorio()
        {
            return metodosDatos.EjecutaObtienelaboratorio();
        }

        public int ingresaLaboratorio(int cantEquipos, int piso, int ConjuntoCaract, string descripcion)
        {
            try
            {

                cantEquipos = Convert.ToInt32(cantEquipos);
                piso = Convert.ToInt32(piso);
                ConjuntoCaract = Convert.ToInt32(ConjuntoCaract);

                return CapaBD.metodosDatos.EjecutaInsertLaboratorio(cantEquipos,piso,ConjuntoCaract,descripcion);
            }
            finally
            {

            }

        }

        public int modificaLaboratorio(int id_laboratorio, int cantEquipos, int piso, int ConjuntoCaract, string descripcion)
        {

            return CapaBD.metodosDatos.EjecutaUpdateLaboratorio(id_laboratorio,cantEquipos,piso,ConjuntoCaract,descripcion);
        }

        public List<Persona> obtienePersona()
        {
            return metodosDatos.EjecutaObtienePersona();
        }



        public int ingresaPersona(int Cedula, string nombre, string apellido1, string apellido2)
        {
            try
            {

                Cedula = Convert.ToInt32(Cedula);
             
                return CapaBD.metodosDatos.EjecutaInsertPersona(Cedula,nombre,apellido1,apellido2);
            }
            finally
            {

            }

        }


        public int modificaPersona(int Cedula, string nombre, string apellido1, string apellido2)
        {

            return CapaBD.metodosDatos.EjecutaUpdatePersona(Cedula, nombre, apellido1, apellido2);
        }

        public List<Servidor> obtieneServidor()
        {
            return metodosDatos.EjecutaObtieneServidor();
        }

        public int ingresaServidor(string servidor, string rol_servidor, string software_actual, string descripcion)
        {
            try
            {

                return CapaBD.metodosDatos.EjecutaInsertServidor(servidor, rol_servidor, software_actual,descripcion);
            }
            finally
            {

            }

        }

        public int modificaServidor(int id_Servidor, string servidor, string rol_servidor, string software_actual, string descripcion)
        {

            return CapaBD.metodosDatos.EjecutaUpdateServidor(id_Servidor,servidor,rol_servidor,software_actual,descripcion);
        }

        public List<Software> obtieneSoftware()
        {
            return metodosDatos.EjecutaObtieneSoftware();
        }

        public int ingresaSoftware(string software, string version_sw, string descripcion)
        {
            try
            {

                return CapaBD.metodosDatos.EjecutaInsertSoftware(software, version_sw, descripcion);
            }
            finally
            {

            }

        }


        public int modificaSoftware(int id_software, string software, string version_sw, string descripcion)
        {

            return CapaBD.metodosDatos.EjecutaUpdateSoftware(id_software,software, version_sw, descripcion);
        }
  
        public List<Tipo_Usuario> obtieneTipo_Usuario()
        {
            return metodosDatos.EjecutaObtieneTipo_Usuario();
        }

        public int ingresaTipo_Usuario(int tipo_usuario)
        {
            try
            {
                tipo_usuario = Convert.ToInt32(tipo_usuario);

                return CapaBD.metodosDatos.EjecutaInsertTipo_Usuario(tipo_usuario);
            }
            finally
            {

            }

        }

        public int modificaTipo_Usuario(int id, int tipo_usuario)
        {

            return CapaBD.metodosDatos.EjecutaUpdateTipo_Usuario(id, tipo_usuario);
        }

        public List<Usuario> obtieneUsuario()
        {
            return metodosDatos.EjecutaObtieneUsuario();
        }

        public int ingresaUsuario(string username, string pass, int tipo_usuario, int cedula)
        {
            try
            {
                tipo_usuario = Convert.ToInt32(tipo_usuario);
                cedula = Convert.ToInt32(cedula);

                return CapaBD.metodosDatos.EjecutaInsertUsuario(username, pass, tipo_usuario, cedula);
            }
            finally
            {

            }

        }


        public int modificaUsuario(int id_usuario,string username, string pass,int tipo_usuario, int cedula)
        {

            return CapaBD.metodosDatos.EjecutaUpdateUsuario(id_usuario,username,pass,tipo_usuario,cedula);
        }

        public List<Solicitud> obtieneSolicitud()
        {
            return metodosDatos.EjecutaObtieneSolicitud();
        }







    }//fin del public class
}