using RegistroUsurios.Data;
using RegistroUsurios.Models; // Agregamos esto para que reconozca la clase Usuario
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
            Console.WriteLine("--- LISTA DE USUARIOS ---");

            var listaUsuarios = usuarioDAL.ObtenerTodos();

            if (listaUsuarios == null || listaUsuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados en el sistema.");
                return;
            }

            foreach (var u in listaUsuarios)
            {
                // Como le pusiste un ToString() súper bueno a tu clase Usuario, solo imprimimos la "u"
                Console.WriteLine(u);
            }
        }

        static void BuscarUsuarioPorId()
        {
            Console.WriteLine("--- BUSCAR USUARIO ---");
            Console.Write("Ingrese el ID del usuario que desea buscar: ");

            if (int.TryParse(Console.ReadLine(), out int idBuscado))
            {
                var usuario = usuarioDAL.ObtenerPorId(idBuscado);

                if (usuario != null)
                {
                    Console.WriteLine("\nUsuario encontrado:");
                    Console.WriteLine(usuario); // Usa tu ToString()
                }
                else
                {
                    Console.WriteLine("\nEl usuario con ese ID no existe.");
                }
            }
            else
            {
                Console.WriteLine("Error: Por favor ingrese un número de ID válido.");
            }
        }

        static void RegistrarUsuario()
        {
            Console.WriteLine("--- REGISTRAR NUEVO USUARIO ---");

            Console.Write("Ingrese los nombres: ");
            string nombres = Console.ReadLine();

            Console.Write("Ingrese los apellidos: ");
            string apellidos = Console.ReadLine();

            Console.Write("Ingrese el correo: ");
            string correo = Console.ReadLine();

            Console.Write("Ingrese la edad: ");
            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                Console.WriteLine("Edad no válida. Registro cancelado.");
                return;
            }

            var nuevoUsuario = new Usuario
            {
                Nombres = nombres,
                Apellidos = apellidos,
                Correo = correo,
                Edad = edad,
                Activo = true
            };

            bool resultado = usuarioDAL.Insertar(nuevoUsuario);

            if (resultado)
                Console.WriteLine("\n¡Usuario registrado con éxito!");
            else
                Console.WriteLine("\nHubo un error al intentar registrar el usuario.");
        }

        static void ActualizarUsuario()
        {
            Console.WriteLine("--- ACTUALIZAR USUARIO ---");

            Console.Write("Ingrese el ID del usuario que desea actualizar: ");
            if (int.TryParse(Console.ReadLine(), out int idActualizar))
            {
                var usuarioExistente = usuarioDAL.ObtenerPorId(idActualizar);

                if (usuarioExistente != null)
                {
                    Console.WriteLine($"\nEditando a: {usuarioExistente.Nombres} {usuarioExistente.Apellidos}");

                    Console.Write("Nuevos nombres (deje en blanco para no cambiar): ");
                    string nuevosNombres = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevosNombres)) usuarioExistente.Nombres = nuevosNombres;

                    Console.Write("Nuevos apellidos (deje en blanco para no cambiar): ");
                    string nuevosApellidos = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevosApellidos)) usuarioExistente.Apellidos = nuevosApellidos;

                    Console.Write("Nuevo correo (deje en blanco para no cambiar): ");
                    string nuevoCorreo = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nuevoCorreo)) usuarioExistente.Correo = nuevoCorreo;

                    Console.Write("Nueva edad (deje en blanco o ponga 0 para no cambiar): ");
                    if (int.TryParse(Console.ReadLine(), out int nuevaEdad) && nuevaEdad > 0)
                    {
                        usuarioExistente.Edad = nuevaEdad;
                    }

                    bool actualizado = usuarioDAL.Actualizar(usuarioExistente);

                    if (actualizado)
                        Console.WriteLine("\n¡Usuario actualizado exitosamente!");
                    else
                        Console.WriteLine("\nError al actualizar el usuario en la base de datos.");
                }
                else
                {
                    Console.WriteLine("\nNo se encontró un usuario con ese ID para actualizar.");
                }
            }
            else
            {
                Console.WriteLine("Error: Por favor ingrese un número de ID válido.");
            }
        }

        static void EliminarUsuario()
        {
            Console.WriteLine("--- ELIMINAR USUARIO ---");

            Console.Write("Ingrese el ID del usuario que desea eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idEliminar))
            {
                var usuarioExistente = usuarioDAL.ObtenerPorId(idEliminar);

                if (usuarioExistente != null)
                {
                    Console.WriteLine($"\nEstá a punto de eliminar a: {usuarioExistente.Nombres} {usuarioExistente.Apellidos}");
                    Console.Write("¿Está seguro? (S/N): ");
                    string confirmacion = Console.ReadLine();

                    if (confirmacion.Trim().ToUpper() == "S")
                    {
                        bool eliminado = usuarioDAL.Eliminar(idEliminar);

                        if (eliminado)
                            Console.WriteLine("\n¡Usuario eliminado correctamente!");
                        else
                            Console.WriteLine("\nError al intentar eliminar al usuario.");
                    }
                    else
                    {
                        Console.WriteLine("\nEliminación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo se encontró ningún usuario con ese ID.");
                }
            }
            else
            {
                Console.WriteLine("Error: Por favor ingrese un número de ID válido.");
            }
        }
    }
}