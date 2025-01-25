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

            Console.WriteLine("Bienvenido a QueHaceres-Cli. Escribe 'help' para ver los comandos disponibles.");
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
                    case "add":
                        if (string.IsNullOrWhiteSpace(arguments))
                        {
                            Console.WriteLine("Uso: add \"descripcion de la tarea\"");
                        }
                        else
                        {
                            TaskManager.AddTask(arguments);
                        }
                        break;

                    case "update":
                        string[] updateParts = arguments.Split(' ', 2);
                        if (updateParts.Length < 2 || !int.TryParse(updateParts[0], out int updateId))
                        {
                            Console.WriteLine("Uso: update [ID] \"nueva descripcion\"");
                        }
                        else
                        {
                            TaskManager.UpdateTask(updateId, updateParts[1]);
                        }
                        break;

                    case "delete":
                        if (!int.TryParse(arguments, out int deleteId))
                        {
                            Console.WriteLine("Uso: delete [ID]");
                        }
                        else
                        {
                            TaskManager.DeleteTask(deleteId);
                        }
                        break;

                    case "change-status":
                        string[] statusParts = arguments.Split(' ', 2);
                        if (statusParts.Length < 2 || !int.TryParse(statusParts[0], out int statusId))
                        {
                            Console.WriteLine("Uso: change-status [ID] [Estado]");
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

                    case "list":
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

                    case "help":
                        Console.WriteLine("\nComandos disponibles:");
                        Console.WriteLine("  add \"descripcion\"          - Agrega una nueva tarea");
                        Console.WriteLine("  update [ID] \"descripcion\"  - Actualiza la descripción de una tarea");
                        Console.WriteLine("  delete [ID]                 - Elimina una tarea por ID");
                        Console.WriteLine("  change-status [ID] [Estado] - Cambia el estado de una tarea (Pendiente, EnProgreso, Completada, Cancelada)");
                        Console.WriteLine("  list [Estado]               - Lista todas las tareas o filtra por estado");
                        Console.WriteLine("  exit                        - Salir del programa");
                        break;

                    case "exit":
                        Console.WriteLine("¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Comando desconocido. Escribe 'help' para ver los comandos disponibles.");
                        break;
                }

            } while (input.ToLower() != "exit");
        }
    }
}