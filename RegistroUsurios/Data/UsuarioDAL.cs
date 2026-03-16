using RegistroUsurios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsurios.Data
{
    public class UsuarioDAL
    {
        // ============================
        // MÉTODOS QUE EL ESTUDIANTE DEBE CREAR
        // ============================

        // 1. Crear un método para LISTAR todos los usuarios
        // Este método debe devolver una lista de tipo List<Usuario>
        // Sugerencia de nombre: ObtenerTodos()
        public List<Usuario> ObtenerTodos()
        {
            // Aquí el estudiante debe:
            // 1. Crear la lista de usuarios
            // 2. Abrir conexión a la base de datos
            // 3. Ejecutar un SELECT * FROM Usuarios
            // 4. Recorrer los resultados con SqlDataReader
            // 5. Guardar cada registro en un objeto Usuario
            // 6. Agregar cada usuario a la lista
            // 7. Retornar la lista

            throw new System.NotImplementedException();
        }

        // 2. Crear un método para BUSCAR un usuario por ID
        // Este método debe devolver un objeto Usuario
        // Sugerencia de nombre: ObtenerPorId(int id)
        public Usuario ObtenerPorId(int id)
        {
            // Aquí el estudiante debe:
            // 1. Abrir conexión
            // 2. Ejecutar un SELECT con WHERE Id = @Id
            // 3. Usar parámetros
            // 4. Leer el resultado
            // 5. Si encuentra el registro, devolver un objeto Usuario
            // 6. Si no lo encuentra, devolver null

            throw new System.NotImplementedException();
        }

        // 3. Crear un método para INSERTAR un usuario
        // Este método debe devolver true si se insertó correctamente
        // Sugerencia de nombre: Insertar(Usuario usuario)
        public bool Insertar(Usuario usuario)
        {
            // Aquí el estudiante debe:
            // 1. Abrir conexión
            // 2. Crear un INSERT INTO Usuarios(...)
            // 3. Usar parámetros con AddWithValue
            // 4. Ejecutar ExecuteNonQuery()
            // 5. Retornar true si filas afectadas > 0

            throw new System.NotImplementedException();
        }

        // 4. Crear un método para ACTUALIZAR un usuario
        // Este método debe devolver true si se actualizó correctamente
        // Sugerencia de nombre: Actualizar(Usuario usuario)
        public bool Actualizar(Usuario usuario)
        {
            // Aquí el estudiante debe:
            // 1. Abrir conexión
            // 2. Crear un UPDATE Usuarios SET ...
            // 3. Actualizar Nombres, Apellidos, Correo, Edad y Activo
            // 4. Filtrar por Id
            // 5. Ejecutar ExecuteNonQuery()
            // 6. Retornar true si filas afectadas > 0

            throw new System.NotImplementedException();
        }

        // 5. Crear un método para ELIMINAR un usuario por ID
        // Este método debe devolver true si se eliminó correctamente
        // Sugerencia de nombre: Eliminar(int id)
        public bool Eliminar(int id)
        {
            // Aquí el estudiante debe:
            // 1. Abrir conexión
            // 2. Crear un DELETE FROM Usuarios WHERE Id = @Id
            // 3. Usar parámetro
            // 4. Ejecutar ExecuteNonQuery()
            // 5. Retornar true si filas afectadas > 0

            throw new System.NotImplementedException();
        }
    }
}
