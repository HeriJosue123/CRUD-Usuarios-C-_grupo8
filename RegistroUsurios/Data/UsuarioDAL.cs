using RegistroUsurios.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RegistroUsurios.Data
{
    public class UsuarioDAL
    {
        // 1. LISTAR todos los usuarios
        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string query = "SELECT Id, Nombres, Apellidos, Correo, Edad, Activo FROM Usuarios";
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombres = reader["Nombres"].ToString(),
                                Apellidos = reader["Apellidos"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Edad = Convert.ToInt32(reader["Edad"]),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los usuarios: " + ex.Message);
                }
            }
            return lista;
        }

        // 2. BUSCAR un usuario por ID
        public Usuario ObtenerPorId(int id)
        {
            Usuario usuario = null;

            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string query = "SELECT Id, Nombres, Apellidos, Correo, Edad, Activo FROM Usuarios WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombres = reader["Nombres"].ToString(),
                                Apellidos = reader["Apellidos"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Edad = Convert.ToInt32(reader["Edad"]),
                                Activo = Convert.ToBoolean(reader["Activo"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al buscar el usuario: " + ex.Message);
                }
            }
            return usuario;
        }

        // 3. INSERTAR un usuario
        public bool Insertar(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string query = "INSERT INTO Usuarios (Nombres, Apellidos, Correo, Edad, Activo) VALUES (@Nombres, @Apellidos, @Correo, @Edad, @Activo)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                cmd.Parameters.AddWithValue("@Activo", usuario.Activo);

                try
                {
                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al registrar el usuario: " + ex.Message);
                    return false;
                }
            }
        }

        // 4. ACTUALIZAR un usuario
        public bool Actualizar(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string query = "UPDATE Usuarios SET Nombres = @Nombres, Apellidos = @Apellidos, Correo = @Correo, Edad = @Edad, Activo = @Activo WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", usuario.Id);
                cmd.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                cmd.Parameters.AddWithValue("@Activo", usuario.Activo);

                try
                {
                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el usuario: " + ex.Message);
                    return false;
                }
            }
        }

        // 5. ELIMINAR un usuario por ID
        public bool Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string query = "DELETE FROM Usuarios WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    con.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el usuario: " + ex.Message);
                    return false;
                }
            }
        }
    }
}