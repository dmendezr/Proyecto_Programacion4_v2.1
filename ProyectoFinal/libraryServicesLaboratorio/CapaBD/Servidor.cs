using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaBD
{
    public class Servidor
    {
        public int id_Servidor { get; set; }
        public string servidor { get; set; }
        public string rol_servidor { get; set; }
        public string software_actual { get; set; }
        public string descripcion { get; set; }
    }
}