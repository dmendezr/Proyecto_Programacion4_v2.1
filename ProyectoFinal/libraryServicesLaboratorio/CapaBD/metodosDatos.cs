using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CapaBD
{
    public class metodosDatos
    {
        //public static SqlConnection _conexion = new SqlConnection();

        public static SqlDataReader EjecutaProcedimientoSelect(string nombreProc, SqlConnection _conexion)
        {
            try
            {
                SqlDataReader dr;
                string _cadenaConexion = Conexion.CadenaConexion;
                
                _conexion.ConnectionString = _cadenaConexion;
                SqlCommand comando = new SqlCommand(nombreProc,_conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 0;
                _conexion.Open();
                comando.ExecuteNonQuery();
                dr = comando.ExecuteReader();
                return dr;
            }
            catch { throw; }
        }

        public static List<Turno> EjecutaObtieneTurnos()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Turno> listTurno = new List<Turno>();
                SqlDataReader dr;   
                dr = EjecutaProcedimientoSelect("sp_DevuelveTurnos",_conexion);
                while (dr.Read())
                {
                    Turno objTurno = new Turno();
                    objTurno.idTurno = (dr.GetInt32(0));
                    objTurno.turno = (dr.GetInt32(1));
                    listTurno.Add(objTurno);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listTurno;
            }
            catch { throw; }
        }

        public static List<Curso> EjecutaObtieneCursos()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Curso> listCurso = new List<Curso>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_obtieneCursos", _conexion);
                while (dr.Read())
                {
                    Curso objCurso = new Curso();
                    objCurso.codCurso = (dr.GetString(0));
                    objCurso.curso = (dr.GetString(1));
                    listCurso.Add(objCurso);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listCurso;
            }
            catch { throw; }
        }

        public static int EjecutaInsertCurso(string codCurso, string curso)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_IngresaCurso", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@codCurso", SqlDbType.NVarChar).Value = codCurso;
            comando.Parameters.Add("@curso", SqlDbType.NVarChar).Value = curso;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static int EjecutaUpdateCurso (string codCurso, string curso)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_ModificaCurso", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@codCurso", SqlDbType.NVarChar).Value = codCurso;
            comando.Parameters.Add("@curso", SqlDbType.NVarChar).Value = curso;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static List<conjuntoCaracteristicas> EjecutarObtieneCaracteristicas()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<conjuntoCaracteristicas> listCaract = new List<conjuntoCaracteristicas>();
                SqlDataReader dr;
                dr = CapaBD.metodosDatos.EjecutaProcedimientoSelect("sp_DevuelveCaracteristicas",_conexion);
                while (dr.Read())
                {
                    conjuntoCaracteristicas objCaract = new conjuntoCaracteristicas();
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
                _conexion.Dispose();
                _conexion.Close();
                return listCaract;
            }
            catch { throw; }
        }

        public static List<Usuario> EjecutaObtieneUsuarios()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Usuario> listUsuario = new List<Usuario>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_ObtieneUserName", _conexion);
                while (dr.Read())
                {
                    Usuario objUser = new Usuario();
                    objUser.id_usuario = dr.GetInt32(0);
                    objUser.username = dr.GetString(1);
                    listUsuario.Add(objUser);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listUsuario;
            }
            catch { throw; }
        }

        public static int InsertSolicitud (string fechaSolicitud, int estadoSolicitud, int idTurno, int idUsuario, int idLaboratorio, string idCurso)
        {
            try
            {
                string _cadenaConexion = Conexion.CadenaConexion;
                SqlConnection _conexion = new SqlConnection();
                _conexion.ConnectionString = _cadenaConexion;
                SqlCommand comando = new SqlCommand("sp_IngresaNuevaSolicitud", _conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@fechaSolicitud",SqlDbType.NVarChar).Value = fechaSolicitud;
                comando.Parameters.Add("@estadoSolicitud", SqlDbType.Int).Value = estadoSolicitud;
                comando.Parameters.Add("@idTurno", SqlDbType.Int).Value = idTurno;
                comando.Parameters.Add("@id_Usuario", SqlDbType.Int).Value = idUsuario;
                comando.Parameters.Add("@id_Laboratorio", SqlDbType.Int).Value = idLaboratorio;
                comando.Parameters.Add("@curso", SqlDbType.VarChar).Value = idCurso;
                comando.CommandTimeout = 0;
                _conexion.Open();
                return comando.ExecuteNonQuery(); 
            }
            catch { throw; }
            finally
            {
                
            }
        }


        public static int EjecutaInsertTurno(int turno)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_IngresaTurno", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@Turno", SqlDbType.NVarChar).Value = turno;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static int EjecutaUpdateTurno(int idTurno,int turno)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_ModificaTurno", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@idTurno", SqlDbType.Int).Value = idTurno;
            comando.Parameters.Add("@Turno", SqlDbType.Int).Value = turno;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static List<Lab_Servidor> EjecutaObtieneLab_Servidor()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Lab_Servidor> listLab_Servidor = new List<Lab_Servidor>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_DevuelveLAB_Servidor", _conexion);
                while (dr.Read())
                {
                    Lab_Servidor objLAB_Servidor = new Lab_Servidor();
                    objLAB_Servidor.id_labServidor = (dr.GetInt32(0));
                    objLAB_Servidor.id_laboratorio = (dr.GetInt32(1));
                    objLAB_Servidor.id_servidor = (dr.GetInt32(2));
                    listLab_Servidor.Add(objLAB_Servidor);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listLab_Servidor;
            }
            catch { throw; }
        }

        public static int EjecutaInsertLAB_Servidor(int id_laboratorio, int id_servidor)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_IngresaLAB_Servidor", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_laboratorio", SqlDbType.Int).Value = id_laboratorio;
            comando.Parameters.Add("@id_servidor", SqlDbType.Int).Value = id_servidor;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static int EjecutaUpdateLAB_Servidor(int id_labServidor, int id_laboratorio, int id_servidor)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_ModificaLAB_Servidor", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_labServidor", SqlDbType.Int).Value = id_labServidor;
            comando.Parameters.Add("@id_laboratorio", SqlDbType.Int).Value = id_laboratorio;
            comando.Parameters.Add("@id_servidor", SqlDbType.Int).Value = id_servidor;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static int EjecutaInsertLab_Software(string actualizado, int id_laboratorio, int id_software)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_IngresaLab_Software", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@actualizado", SqlDbType.NVarChar).Value = actualizado;
            comando.Parameters.Add("@id_laboratorio", SqlDbType.Int).Value = id_laboratorio;
            comando.Parameters.Add("@id_software", SqlDbType.NVarChar).Value = id_software;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static List<Lab_Software> EjecutaObtieneLab_Software()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Lab_Software> listLab_Software = new List<Lab_Software>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_DevuelveLab_Software", _conexion);
                while (dr.Read())
                {
                    Lab_Software objLab_Software = new Lab_Software();
                    objLab_Software.id_labSW = (dr.GetInt32(0));
                    objLab_Software.actualizado = (dr.GetString(1));
                    objLab_Software.id_laboratorio = (dr.GetInt32(2));
                    objLab_Software.id_software = (dr.GetInt32(3));
                    listLab_Software.Add(objLab_Software);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listLab_Software;
            }
            catch { throw; }
        }

        public static int EjecutaUpdateLab_Software(int id_labSW, string actualizado, int id_laboratorio, int id_software)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_ModificaLab_Software", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_labSW", SqlDbType.Int).Value = id_labSW;
            comando.Parameters.Add("@actualizado", SqlDbType.NVarChar).Value = actualizado;
            comando.Parameters.Add("@id_laboratorio", SqlDbType.Int).Value = id_laboratorio;
            comando.Parameters.Add("@id_software", SqlDbType.Int).Value = id_software;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }


        public static List<Laboratorio> EjecutaObtienelaboratorio()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Laboratorio> listlaboratorio = new List<Laboratorio>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_Devuelvelaboratorio", _conexion);
                while (dr.Read())
                {
                    Laboratorio objlaboratorio = new Laboratorio();
                    objlaboratorio.id_laboratoio = (dr.GetInt32(0));
                    objlaboratorio.cantequipos = (dr.GetInt32(1));
                    objlaboratorio.piso = (dr.GetInt32(2));
                    objlaboratorio.conjutoCaract = (dr.GetInt32(3));
                    objlaboratorio.descripcion = (dr.GetString(4));
                    listlaboratorio.Add(objlaboratorio);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listlaboratorio;
            }
            catch { throw; }
        }

        public static int EjecutaInsertLaboratorio(int cantEquipos, int piso, int ConjuntoCaract, string descripcion)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_IngresaLaboratorio", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@cantEquipos", SqlDbType.Int).Value = cantEquipos;
            comando.Parameters.Add("@piso", SqlDbType.Int).Value = piso;
            comando.Parameters.Add("@ConjuntoCaract", SqlDbType.Int).Value = ConjuntoCaract;
            comando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static int EjecutaUpdateLaboratorio(int id_laboratorio, int cantEquipos, int piso, int ConjuntoCaract, string descripcion)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_ModificaLaboratorio", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_laboratorio", SqlDbType.Int).Value = id_laboratorio;
            comando.Parameters.Add("@cantEquipos", SqlDbType.Int).Value = cantEquipos;
            comando.Parameters.Add("@piso", SqlDbType.Int).Value = piso;
            comando.Parameters.Add("@ConjuntoCaract", SqlDbType.Int).Value = ConjuntoCaract;
            comando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static List<Persona> EjecutaObtienePersona()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Persona> listPersona = new List<Persona>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_DevuelvePersona", _conexion);
                while (dr.Read())
                {
                    Persona objPersona = new Persona();
                    objPersona.cedula = (dr.GetInt32(0));
                    objPersona.nombre = (dr.GetString(1));
                    objPersona.apellido1 = (dr.GetString(2));
                    objPersona.apellido2 = (dr.GetString(3));
                    listPersona.Add(objPersona);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listPersona;
            }
            catch { throw; }
        }

        public static int EjecutaInsertPersona(int Cedula, string nombre, string apellido1, string apellido2)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_IngresaPersona", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@Cedula", SqlDbType.Int).Value = Cedula;
            comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
            comando.Parameters.Add("@apellido1", SqlDbType.NVarChar).Value = apellido1;
            comando.Parameters.Add("@apellido2", SqlDbType.NVarChar).Value = apellido2;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static int EjecutaUpdatePersona(int Cedula, string nombre, string apellido1, string apellido2)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_ModificaPersona", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@Cedula", SqlDbType.Int).Value = Cedula;
            comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
            comando.Parameters.Add("@apellido1", SqlDbType.NVarChar).Value = apellido1;
            comando.Parameters.Add("@apellido2", SqlDbType.NVarChar).Value = apellido2;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static List<Servidor> EjecutaObtieneServidor()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Servidor> listServidor = new List<Servidor>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_DevuelveServidor", _conexion);
                while (dr.Read())
                {
                    Servidor objServidor = new Servidor();
                    objServidor.id_Servidor = (dr.GetInt32(0));
                    objServidor.servidor = (dr.GetString(1));
                    objServidor.rol_servidor = (dr.GetString(2));
                    objServidor.software_actual = (dr.GetString(3));
                    objServidor.descripcion = (dr.GetString(4));
                    listServidor.Add(objServidor);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listServidor;
            }
            catch { throw; }
        }

        public static int EjecutaInsertServidor(string servidor, string rol_servidor, string software_actual, string descripcion)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_IngresaServidor", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@servidor", SqlDbType.NVarChar).Value = servidor;
            comando.Parameters.Add("@rol_servidor", SqlDbType.NVarChar).Value = rol_servidor;
            comando.Parameters.Add("@software_actual", SqlDbType.NVarChar).Value = software_actual;
            comando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static int EjecutaUpdateServidor(int id_Servidor, string servidor, string rol_servidor, string software_actual, string descripcion)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_ModificaServidor", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_Servidor", SqlDbType.Int).Value = id_Servidor;
            comando.Parameters.Add("@servidor", SqlDbType.NVarChar).Value = servidor;
            comando.Parameters.Add("@rol_servidor", SqlDbType.NVarChar).Value = rol_servidor;
            comando.Parameters.Add("@software_actual", SqlDbType.NVarChar).Value = software_actual;
            comando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static List<Software> EjecutaObtieneSoftware()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Software> listSoftware = new List<Software>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_DevuelveSoftware", _conexion);
                while (dr.Read())
                {
                    Software objSoftware = new Software();
                    objSoftware.id_software = (dr.GetInt32(0));
                    objSoftware.software = (dr.GetString(1));
                    objSoftware.version_sw = (dr.GetString(2));
                    objSoftware.descripcion = (dr.GetString(3));
                    listSoftware.Add(objSoftware);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listSoftware;
            }
            catch { throw; }
        }

        public static int EjecutaInsertSoftware(string software, string version_sw, string descripcion)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_IngresaSoftware", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@software", SqlDbType.NVarChar).Value = software;
            comando.Parameters.Add("@version_sw", SqlDbType.NVarChar).Value = version_sw;     
            comando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }


        public static int EjecutaUpdateSoftware(int id_software, string software, string version_sw, string descripcion)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_ModificaSoftware", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_software", SqlDbType.Int).Value = id_software;
            comando.Parameters.Add("@software", SqlDbType.NVarChar).Value = software;
            comando.Parameters.Add("@version_sw", SqlDbType.NVarChar).Value = version_sw;
            comando.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = descripcion;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static List<Tipo_Usuario> EjecutaObtieneTipo_Usuario()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Tipo_Usuario> listTipo_Usuario = new List<Tipo_Usuario>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_DevuelveTipo_Usuario", _conexion);
                while (dr.Read())
                {
                    Tipo_Usuario objTipo_Usuario = new Tipo_Usuario();
                    objTipo_Usuario.id = (dr.GetInt32(0));
                    objTipo_Usuario.tipo_usuario = (dr.GetInt32(1));
                    listTipo_Usuario.Add(objTipo_Usuario);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listTipo_Usuario;
            }
            catch { throw; }
        }

        public static int EjecutaInsertTipo_Usuario(int tipo_usuario)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_Ingresatipo_Usuario", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@tipo_usuario", SqlDbType.NVarChar).Value = tipo_usuario;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static int EjecutaUpdateTipo_Usuario(int id, int tipo_usuario)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_ModificaTipo_Usuario", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
            comando.Parameters.Add("@tipo_usuario", SqlDbType.Int).Value = tipo_usuario;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static List<Usuario> EjecutaObtieneUsuario()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Usuario> listUsuario = new List<Usuario>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_DevuelveUsuario", _conexion);
                while (dr.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.id_usuario = (dr.GetInt32(0));
                    objUsuario.username = (dr.GetString(1));
                    objUsuario.pass = (dr.GetString(2));
                    objUsuario.tipo_usuario = (dr.GetInt32(3));
                    objUsuario.cedula = (dr.GetInt32(4));
                    listUsuario.Add(objUsuario);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listUsuario;
            }
            catch { throw; }
        }

        public static int EjecutaInsertUsuario(string username, string pass, int tipo_usuario, int cedula)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_IngresaUsuario", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            comando.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pass;
            comando.Parameters.Add("@tipo_usuario", SqlDbType.Int).Value = tipo_usuario;
            comando.Parameters.Add("@cedula", SqlDbType.Int).Value = cedula;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static int EjecutaUpdateUsuario(int id_usuario,string username, string pass, int tipo_usuario, int cedula)
        {
            string _cadenaConexion = Conexion.CadenaConexion;
            SqlConnection _conexion = new SqlConnection();
            _conexion.ConnectionString = _cadenaConexion;
            SqlCommand comando = new SqlCommand("sp_ModificaUsuario", _conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id_usuario;
            comando.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            comando.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pass;
            comando.Parameters.Add("@tipo_usuario", SqlDbType.Int).Value = tipo_usuario;
            comando.Parameters.Add("@cedula", SqlDbType.Int).Value = cedula;
            comando.CommandTimeout = 0;
            _conexion.Open();
            return comando.ExecuteNonQuery();
        }

        public static List<Solicitud> EjecutaObtieneSolicitud()
        {
            try
            {
                SqlConnection _conexion = new SqlConnection();
                List<Solicitud> listSolicitud = new List<Solicitud>();
                SqlDataReader dr;
                dr = EjecutaProcedimientoSelect("sp_DevuelveSolicitud", _conexion);
                while (dr.Read())
                {
                    Solicitud objSolicitud = new Solicitud();
                    objSolicitud.id_solicitud = (dr.GetInt32(0));
                    objSolicitud.fecha_solicitud = (Convert.ToString(dr.GetDateTime(1).ToShortDateString()));
                    objSolicitud.estado_solicitud = (dr.GetInt32(2));
                    objSolicitud.idTurno = (dr.GetInt32(3));
                    objSolicitud.id_Usuario = (dr.GetInt32(4));
                    objSolicitud.id_laboratorio = (dr.GetInt32(5));
                    objSolicitud.codCurso = (dr.GetString(6));
                    listSolicitud.Add(objSolicitud);
                }
                _conexion.Dispose();
                _conexion.Close();
                return listSolicitud;
            }
            catch { throw; }
        }








    }//fin public class Metodos
    }
