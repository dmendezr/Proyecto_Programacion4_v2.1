using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaBD
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string username { get; set; }
        public string pass  { get; set; } 
        public int tipo_usuario { get; set; }
        public int cedula { get; set; }

        
    }

}