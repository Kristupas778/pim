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
                if (usuario.NombreUsuario == null)
                    usuario.NombreUsuario = " ";
                Comm.Parameters.Add("@NombreUsuario", SqlDbType.NChar, 30).Value = usuario.NombreUsuario;
                Comm.Parameters.Add("@Correo", SqlDbType.NChar, 50).Value = usuario.Correo;
                Comm.Parameters.Add("@Contraseña", SqlDbType.NChar, 30).Value = usuario.Contraseña;
                if (usuario.Nota == null)
                    usuario.Nota= " ";
                Comm.Parameters.Add("@Nota", SqlDbType.NChar, 50).Value = usuario.Nota;
                Comm.Parameters.Add("@ID_Categoria", SqlDbType.Int).Value = usuario.ID_Categoria;


                if (usuario.Direccion != null && usuario.NombreUsuario != null && usuario.Correo != null && usuario.Contraseña != null && usuario.Nota != null)
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
    
        public async Task<IEnumerable<Usuario>> ListarTodosLosUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlConnection sqlConexion = Conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuariosLista";
                Comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Usuario u = new Usuario();
                    u.ID = Convert.ToInt32(reader["ID"]);
                    u.Direccion = reader["Direccion"].ToString();
                    u.NombreUsuario = reader["NombreUsuario"].ToString();
                    u.Correo = reader["Correo"].ToString();
                    u.Contraseña = reader["Contraseña"].ToString();
                    u.Nota = reader["Nota"].ToString();
                    u.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                    lista.Add(u);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error guardando los datos" + ex.Message);
            }
            finally
            {
                Comm.Dispose();
            }
            return lista;
        }
        
        public async Task<Usuario> ListarTodosLosUsuarios(int id)
        {
            Usuario u = new Usuario();
            SqlConnection sqlConexion = Conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuariosLista";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                while (reader.Read())
                {
                    u.ID = Convert.ToInt32(reader["ID"]);
                    u.Direccion = reader["Direccion"].ToString();
                    u.NombreUsuario = reader["NombreUsuario"].ToString();
                    u.Correo = reader["Correo"].ToString();
                    u.Contraseña = reader["Contraseña"].ToString();
                    u.Nota = reader["Nota"].ToString();
                    u.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error guardando los datos" + ex.Message);
            }
            finally
            {
                Comm.Dispose();
            }
            return u;
        }
       
        public async Task<bool> ModificarUsuario(Usuario usuario)
        {
            Boolean usuarioModificado = false;
            SqlConnection sqlConexion = Conexion();
            SqlCommand Comm = null;

            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuarioAlta";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@Direccion", SqlDbType.NChar, 500).Value = usuario.Direccion;
                if (usuario.NombreUsuario == null)
                    usuario.NombreUsuario = " ";
                Comm.Parameters.Add("@NombreUsuario", SqlDbType.NChar, 30).Value = usuario.NombreUsuario;
                Comm.Parameters.Add("@Correo", SqlDbType.NChar, 50).Value = usuario.Correo;
                Comm.Parameters.Add("@Contraseña", SqlDbType.NChar, 30).Value = usuario.Contraseña;
                if (usuario.Nota == null)
                    usuario.Nota = " ";
                Comm.Parameters.Add("@Nota", SqlDbType.NChar, 50).Value = usuario.Nota;
                Comm.Parameters.Add("@ID", SqlDbType.Int).Value = usuario.ID;
                Comm.Parameters.Add("@ID_Categoria", SqlDbType.Int).Value = usuario.ID_Categoria;

                if (usuario.Direccion != null && usuario.NombreUsuario != null && usuario.Correo != null && usuario.Contraseña != null && usuario.Nota != null)
                    await Comm.ExecuteNonQueryAsync();
                usuarioModificado= true;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Guardando los datos del usuario" + ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return usuarioModificado;
        }

        public async Task<bool> BorrarUsuario(int id)
        {
            Boolean usuarioBorrado = false;
            SqlConnection sqlConexion = Conexion();
            SqlCommand Comm = null;

            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuarioBaja";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                if (id > 0)
                    await Comm.ExecuteNonQueryAsync();
                usuarioBorrado = true;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Borrando los datos del usuario" + ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return usuarioBorrado;
        }

        public async Task<IEnumerable<Categorias>> ListarCategorias()
        {
            List<Categorias> lista = new List<Categorias>();
            SqlConnection sqlConexion = Conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.CategoriasLista";
                Comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader reade = await Comm.ExecuteReaderAsync();
                while (reade.Read())
                {
                    Categorias c = new Categorias();
                    c.ID = Convert.ToInt32(reade["ID"]);
                    c.Nombre = reade["Nombre"].ToString();
                    lista.Add(c);
                }
                reade.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error guardando los datos" + ex.Message);
            }
            finally
            {
                Comm.Dispose();
            }
            return lista;
        }

        public async Task<IEnumerable<Usuario>> ListarTodosLosUsuarios(string cadenaBusqueda)
        {

            List<Usuario> lista = new List<Usuario>();
            SqlConnection sqlConexion = Conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuariosLista";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@busqueda", SqlDbType.NChar, 500).Value = cadenaBusqueda;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Usuario u = new Usuario();
                    u.ID = Convert.ToInt32(reader["ID"]);
                    u.Direccion = reader["Direccion"].ToString();
                    u.NombreUsuario = reader["NombreUsuario"].ToString();
                    u.Correo = reader["Correo"].ToString();
                    u.Contraseña = reader["Contraseña"].ToString();
                    u.Nota = reader["Nota"].ToString();
                    u.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                    lista.Add(u);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error guardando los datos" + ex.Message);
            }
            finally
            {
                Comm.Dispose();
            }
            return lista;

        }
    }
}
