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
        public static SqlConnection _conexion = new SqlConnection();

        public static void cierraConexion()
        {
            _conexion.Dispose();
            _conexion.Close();
        }

        public static SqlDataReader EjecutaProcedimientoSelect(string nombreProc)
        {
            try
            {
                SqlDataReader dr;
                string _cadenaConexion = Conexion.CadenaConexion;
                
                _conexion.ConnectionString = _cadenaConexion;
                SqlCommand comando = new SqlCommand(nombreProc,_conexion);
                comando.CommandTimeout = 0;
                _conexion.Open();
                comando.ExecuteNonQuery();
                dr = comando.ExecuteReader();
                return dr;
            }
            catch { throw; }
        }

        public static int InsertSolicitud (string fechaSolicitud, int estadoSolicitud, int idTurno, int idUsuario, int idLaboratorio, string idCurso)
        {
            try
            {
                string _cadenaConexion = Conexion.CadenaConexion;

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
        } 
    }
}
