using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PimWebApp.Data;
using PimWebApp.Interfaz;

namespace PimWebApp.Servicios
{
    public class ServicioUsuario:IUsuarioServices
    {
        private SqlUsuario sqlUsuario;
        private SqlConfiguracion configuracion;

        public ServicioUsuario(SqlConfiguracion c)
        {
            configuracion = c;
            sqlUsuario = new SqlUsuario(configuracion.CadenaConexion);
        }

        public Task<bool> GuardarUsuario(Usuario usuario)
        {
            if (usuario.ID == 0)
                return sqlUsuario.GuardarUsuario(usuario);
            else
                return null;
        }
    }
}
