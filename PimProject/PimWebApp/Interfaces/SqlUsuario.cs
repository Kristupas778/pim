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
            CadenaConexion =cadenaConexion;
        }

        private SqlConnection Conexion()
        {
            return new SqlConnection(CadenaConexion);
        }
        public async Task<bool> GuardarUsuario(Usuario usuario)
        {
            Boolean usuarioCreado = false;
            SqlConnection sqlConexion = Conexion();
            SqlCommand Comm = null;

            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuarioAlta";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@Direccion", SqlDbType.NChar, 500).Value = usuario.Direccion;
                Comm.Parameters.Add("@NombreUsuario", SqlDbType.NChar, 30).Value = usuario.NombreUsuario;
                Comm.Parameters.Add("@Correo", SqlDbType.NChar, 50).Value = usuario.Correo;
                Comm.Parameters.Add("@Contraseña", SqlDbType.NChar, 30).Value = usuario.Contraseña;
                Comm.Parameters.Add("@Nota", SqlDbType.NChar, 50).Value = usuario.Nota;

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
