using QueHaceres_Cli.Helpers;
using QueHaceres_Cli.Models;
using Task = QueHaceres_Cli.Models.Task;

namespace QueHaceres_Cli.Managers
{
    public static class TaskManager
    {
        /// <summary>
        /// Agrega una nueva tarea al sistema.
        /// </summary>
        /// <param name="description">Descripcion de la tarea,</param>
        public static void AddTask(string description)
        {
            List<Task> tasks = FileHelper.ReadTasks();

            Task newTask = new Task
            {
                Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
                Description = description,
                CreatedAt = DateTime.Now
            };

            tasks.Add(newTask);
            FileHelper.WriteTasks(tasks);

            Console.WriteLine($"Tarea agregada exitosamente con ID {newTask.Id}");
        }

        /// <summary>
        /// Elimina una tarea del sistema.
        /// </summary>
        /// <param name="id">ID de la tarea a actualizar.</param>
        /// <param name="newDescription">Nueva descripcion de la tarea.</param>
        public static void UpdateTask(int id, string newDescription)
        {
            List<Task> tasks = FileHelper.ReadTasks();
            Task? task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine($"No se encontró una tarea con ID {id}");
                return;
            }

            task.Description = newDescription;
            task.UpdatedAt = DateTime.Now;

            FileHelper.WriteTasks(tasks);
            Console.WriteLine($"Tarea con ID {id} actualizada exitosamente");
        }

        /// <summary>
        /// Elimina una tarea por su ID.
        /// </summary>
        /// <param name="id">ID de la tarea a eliminar.</param>
        public static void DeleteTask(int id)
        {
            List<Task> tasks = FileHelper.ReadTasks();
            Task? task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine($"No se encontró una tarea con ID {id}");
                return;
            }

            tasks.Remove(task);
            FileHelper.WriteTasks(tasks);
            Console.WriteLine($"Tarea con ID {id} eliminada exitosamente");
        }

        /// <summary>
        /// Cambia el estado de una tarea por su ID.
        /// </summary>
        /// <param name="id">ID de la tarea.</param>
        /// <param name="newStatus">Nuevo estado de la tarea.</param>
        public static void ChangeTaskStatus(int id, TaskStatusEnum newStatus)
        {
            List<Task> tasks = FileHelper.ReadTasks();
            Task? task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine($"No se encontró una tarea con ID {id}");
                return;
            }

            task.UpdateStatus(newStatus);
            FileHelper.WriteTasks(tasks);
            Console.WriteLine($"Estado de la tarea con ID {id} actualizado exitosamente");
        }

        /// <summary>
        /// Muestra una lista de tareas en el sistema, opcionalmente filtradas por estado.
        /// </summary>
        /// <param name="status">Estado por el cual filtrar (opcional)</param>
        public static void ListTasks(TaskStatusEnum? status = null)
        {
            List<Task> tasks = FileHelper.ReadTasks();

            List<Task> filteredTasks = status == null ? tasks : tasks.Where(t => t.Status == status).ToList();

            if (filteredTasks.Count == 0)
            {
                Console.WriteLine("No se encontraron tareas para mostrar");
                return;
            }

            foreach (Task task in filteredTasks)
            {
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Descripcion: {task.Description}");
                Console.WriteLine($"Estado: {task.Status}");
                Console.WriteLine($"Creada en: {task.CreatedAt}");
                Console.WriteLine($"Actualizada en: {task.UpdatedAt}");
                Console.WriteLine($"Completada en: {task.CompletedAt}");
                Console.WriteLine($"Cancelada en: {task.CancelledAt}");
                Console.WriteLine();
            }
        }
    }
}