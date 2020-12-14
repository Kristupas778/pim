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
        private IUsuario iusuario;
        private SqlConfiguracion configuracion;

        public ServicioUsuario(SqlConfiguracion c)
        {
            configuracion = c;
            iusuario = new SqlUsuario(configuracion.CadenaConexion);
        }

        public Task<bool> GuardarUsuario(Usuario usuario)
        {
            if (usuario.ID == 0)
                return iusuario.GuardarUsuario(usuario);
            else
                return null;
        }

        public Task<IEnumerable<Usuario>> ListarTodosLosUsuarios()
        {
            return iusuario.ListarTodosLosUsuarios();
        }
    }
}
