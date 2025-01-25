namespace QueHaceres_Cli.Models
{
    /// <summary>
    /// Representa una tarea en el sistema.
    /// </summary>
    public class Task
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Pendiente;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; }
        public DateTime? CancelledAt { get; set; }

        /// <summary>
        /// Actualiza el estado de la tarea y ajusta las fechas correspondientes.
        /// </summary>
        /// <param name="newStatus">Nuevo estado de la tarea.</param>
        public void UpdateStatus(TaskStatusEnum newStatus)
        {
            Status = newStatus;
            UpdatedAt = DateTime.Now;

            DateTime? now = DateTime.Now;
            CompletedAt = newStatus == TaskStatusEnum.Completada ? now : null;
            CancelledAt = newStatus == TaskStatusEnum.Cancelada ? now : null;
        }
    }
}