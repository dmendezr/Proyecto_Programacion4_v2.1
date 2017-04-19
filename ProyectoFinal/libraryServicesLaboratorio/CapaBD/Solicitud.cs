using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaBD
{
    public class Solicitud
    {
        public int id_solicitud { get; set; }
        public String fecha_solicitud { get; set; }
        public int estado_solicitud { get; set; }
        public int idTurno { get; set; }
        public int id_Usuario {get;set;}
        public int id_laboratorio { get; set; }
        public string codCurso { get; set; }
    }
}