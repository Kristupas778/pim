using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PimWebApp.Data
{
    public class Usuario
    {
        public int ID { get; set; }

        public string Direccion { get; set; }

        public string NombreUsuario { get; set; }

        public string Correo { get; set; }

        public string Contraseña { get; set; }

        public string Nota { get; set; }

    }
}
