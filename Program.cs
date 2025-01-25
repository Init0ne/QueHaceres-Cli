using QueHaceres_Cli.Helpers;
using QueHaceres_Cli.Managers;
using QueHaceres_Cli.Models;

namespace QueHaceres_Cli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileHelper.EnsureFileExists();

            Console.WriteLine("Bienvenido a QueHaceres-Cli. Escribe 'ayuda' para ver los comandos disponibles.");
            string input;
            do
            {
                Console.Write("\n> ");
                input = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrEmpty(input)) continue;

                string[] parts = input.Split(' ', 2);
                string command = parts[0].ToLower();
                string arguments = parts.Length > 1 ? parts[1] : "";

                switch (command)
                {
                    case "agregar":
                        if (string.IsNullOrWhiteSpace(arguments))
                        {
                            Console.WriteLine("Uso: agregar \"descripcion de la tarea\"");
                        }
                        else
                        {
                            TaskManager.AddTask(arguments);
                        }
                        break;

                    case "actualizar":
                        string[] updateParts = arguments.Split(' ', 2);
                        if (updateParts.Length < 2 || !int.TryParse(updateParts[0], out int updateId))
                        {
                            Console.WriteLine("Uso: actualizar [ID] \"nueva descripcion\"");
                        }
                        else
                        {
                            TaskManager.UpdateTask(updateId, updateParts[1]);
                        }
                        break;

                    case "eliminar":
                        if (!int.TryParse(arguments, out int deleteId))
                        {
                            Console.WriteLine("Uso: eliminar [ID]");
                        }
                        else
                        {
                            TaskManager.DeleteTask(deleteId);
                        }
                        break;

                    case "cambiar-estado":
                        string[] statusParts = arguments.Split(' ', 2);
                        if (statusParts.Length < 2 || !int.TryParse(statusParts[0], out int statusId))
                        {
                            Console.WriteLine("Uso: cambiar-estado [ID] [Estado]");
                        }
                        else if (!Enum.TryParse(statusParts[1], true, out TaskStatusEnum newStatus))
                        {
                            Console.WriteLine("Estado inválido. Usa: Pendiente, EnProgreso, Completada, Cancelada");
                        }
                        else
                        {
                            TaskManager.ChangeTaskStatus(statusId, newStatus);
                        }
                        break;

                    case "listar":
                        if (string.IsNullOrEmpty(arguments))
                        {
                            TaskManager.ListTasks();
                        }
                        else if (Enum.TryParse(arguments, true, out TaskStatusEnum filterStatus))
                        {
                            TaskManager.ListTasks(filterStatus);
                        }
                        else
                        {
                            Console.WriteLine("Estado inválido. Usa: Pendiente, EnProgreso, Completada, Cancelada");
                        }
                        break;

                    case "ayuda":
                        Console.WriteLine("\nComandos disponibles:");
                        Console.WriteLine("  agregar \"descripcion\"              - Agrega una nueva tarea");
                        Console.WriteLine("  actualizar [ID] \"descripcion\"      - Actualiza la descripción de una tarea");
                        Console.WriteLine("  eliminar [ID]                      - Elimina una tarea por ID");
                        Console.WriteLine("  cambiar-estado [ID] [Estado]       - Cambia el estado de una tarea (Pendiente, EnProgreso, Completada, Cancelada)");
                        Console.WriteLine("  listar [Estado]                    - Lista todas las tareas o filtra por estado");
                        Console.WriteLine("  salir                              - Salir del programa");
                        break;

                    case "salir":
                        Console.WriteLine("¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Comando desconocido. Escribe 'ayuda' para ver los comandos disponibles.");
                        break;
                }

            } while (input.ToLower() != "salir");
        }
    }
}