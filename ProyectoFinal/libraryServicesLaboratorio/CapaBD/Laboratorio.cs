﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaBD
{
    public class Laboratorio
    {
        public int id_laboratoio { get; set; }
        public int cantequipos { get; set; }
        public int piso { get; set; }
        public int conjutoCaract { get; set; }
        public string descripcion { get; set; }
    }
}