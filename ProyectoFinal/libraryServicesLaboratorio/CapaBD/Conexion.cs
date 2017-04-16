using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaBD
{
    class Conexion
    {
        static string cadenaConexion =
          @"Data Source=RIVERA;Initial Catalog=reservaLaboratorio;User ID=conexionBD;password=Password1234";

        public static string CadenaConexion
        {
            get { return cadenaConexion; }
        }
    }
}
