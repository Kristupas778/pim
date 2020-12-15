using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PimWebApp.Data;

namespace PimWebApp.Interfaz
{
    interface IUsuarioServices
    {

        Task<bool> GuardarUsuario(Usuario usuario);

        Task<IEnumerable<Usuario>> ListarTodosLosUsuarios();

        Task<Usuario> ListarTodosLosUsuarios(int id);
    }
}
