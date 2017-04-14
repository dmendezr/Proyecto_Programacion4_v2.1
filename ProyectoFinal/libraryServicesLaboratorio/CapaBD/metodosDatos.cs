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
    }
}
