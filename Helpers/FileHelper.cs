using System.Text.Json;
using Task = QueHaceres_Cli.Models.Task;

namespace QueHaceres_Cli.Helpers
{
    public class FileHelper
    {
        public static string FilePath = "tasks.json";

        /// <summary>
        /// Verifica si el archivo tasks.json existe, si no existe lo crea.
        /// </summary>
        public static void EnsureFileExists()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("El archivo tasks.json no existe. Creando uno nuevo...");
                File.WriteAllText(FilePath, "[]");
            }
        }

        /// <summary>
        /// Carga las tareas desde el archivo tasks.json
        /// </summary>
        /// <returns>Una lista de tareas deserializadas</returns>
        public static List<Task> ReadTasks()
        {
            try
            {
                EnsureFileExists();
                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Task>>(json) ?? [];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al leer el archivo tasks.json: {e.Message}");
                return [];
            }
        }

        /// <summary>
        /// Escribe las tareas en el archivo tasks.json
        /// </summary>
        /// <param name="tasks">Lista de tareas a guardar</param>
        public static void WriteTasks(List<Task> tasks)
        {
            try
            {
                EnsureFileExists();
                string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al escribir el archivo tasks.json: {e.Message}");
            }
        }
    }
}