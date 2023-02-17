﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio1_3.Modelo
{
    public class Gente
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string edad { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
    }
}
