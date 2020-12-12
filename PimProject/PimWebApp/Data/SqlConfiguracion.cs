using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PimWebApp.Data
{
    public class SqlConfiguracion
    {
        private string cadenaConexion;

        public string CadenaConexion { get => cadenaConexion; }

        public SqlConfiguracion(string Conexion)
        {
            cadenaConexion = Conexion;
        }

    }
}
