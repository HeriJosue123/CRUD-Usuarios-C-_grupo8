using RegistroUsurios.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroUsurios
{
    internal class Program
    {
        static UsuarioDAL usuarioDAL = new UsuarioDAL();

        static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("   SISTEMA DE REGISTRO DE USUARIOS  ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Listar usuarios");
                Console.WriteLine("2. Buscar usuario por ID");
                Console.WriteLine("3. Registrar usuario");
                Console.WriteLine("4. Actualizar usuario");
                Console.WriteLine("5. Eliminar usuario");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        ListarUsuarios();
                        break;
                    case 2:
                        BuscarUsuarioPorId();
                        break;
                    case 3:
                        RegistrarUsuario();
                        break;
                    case 4:
                        ActualizarUsuario();
                        break;
                    case 5:
                        EliminarUsuario();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 6);
        }

        static void ListarUsuarios()
        {
            // El estudiante debe:
            // 1. Llamar usuarioDAL.ObtenerTodos()
            // 2. Guardar la lista en una variable
            // 3. Validar si la lista está vacía
            // 4. Mostrar cada usuario en pantalla

            Console.WriteLine("Método pendiente de completar.");
        }

        static void BuscarUsuarioPorId()
        {
            // El estudiante debe:
            // 1. Pedir el ID
            // 2. Validar que sea numérico
            // 3. Llamar usuarioDAL.ObtenerPorId(id)
            // 4. Mostrar el usuario si existe
            // 5. Mostrar mensaje si no existe

            Console.WriteLine("Método pendiente de completar.");
        }

        static void RegistrarUsuario()
        {
            // El estudiante debe:
            // 1. Crear un objeto Usuario
            // 2. Pedir nombres, apellidos, correo y edad
            // 3. Asignar Activo = true
            // 4. Llamar usuarioDAL.Insertar(usuario)
            // 5. Mostrar mensaje según el resultado

            Console.WriteLine("Método pendiente de completar.");
        }

        static void ActualizarUsuario()
        {
            // El estudiante debe:
            // 1. Pedir ID
            // 2. Buscar si el usuario existe con usuarioDAL.ObtenerPorId(id)
            // 3. Si existe, pedir nuevos datos
            // 4. Llamar usuarioDAL.Actualizar(usuario)
            // 5. Mostrar mensaje de éxito o error

            Console.WriteLine("Método pendiente de completar.");
        }

        static void EliminarUsuario()
        {
            // El estudiante debe:
            // 1. Pedir ID
            // 2. Buscar si el usuario existe
            // 3. Confirmar eliminación
            // 4. Llamar usuarioDAL.Eliminar(id)
            // 5. Mostrar mensaje según el resultado

            Console.WriteLine("Método pendiente de completar.");
        }
    }
}
