using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PimWebApp.Data;
using System.Data;

namespace PimWebApp.Interfaz
{
    public class SqlUsuario:IUsuario
    {
        private string CadenaConexion;

        public SqlUsuario(String cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private SqlConnection conexion()
        {
            return new SqlConnection(CadenaConexion);
        }
        public async Task<bool> GuardarUsuario(Usuario usuario)
        {
            Boolean usuarioCreado = false;
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;

            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo,UsuarioAlta";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@URL", SqlDbType.NChar, 500).Value = usuario.URL;
                Comm.Parameters.Add("@NombreUsuario", SqlDbType.NChar, 500).Value = usuario.NombreUsuario;
                Comm.Parameters.Add("@Correo", SqlDbType.NChar, 500).Value = usuario.Correo;
                Comm.Parameters.Add("@Contraseña", SqlDbType.NChar, 500).Value = usuario.Contraseña;
                Comm.Parameters.Add("@Nota", SqlDbType.NChar, 500).Value = usuario.Nota;
               

                await Comm.ExecuteNonQueryAsync();
                usuarioCreado = true;
            }
            catch(SqlException ex)
            {
                throw new Exception("Error Guardando los datos del usuario"+ ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return usuarioCreado;

        }
    }
}
