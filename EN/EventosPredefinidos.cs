﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class EventosPredefinidos
    {
        public long EventoPredefinidoID { get; set; }
        public string NombreEvento { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal PrecioBase { get; set; }
    }
}
