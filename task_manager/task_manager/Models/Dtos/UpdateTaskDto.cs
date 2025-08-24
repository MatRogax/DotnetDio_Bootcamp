namespace task_manager.Models.Dtos
{
    public class UpdateTaskDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public EnumTaskStatus? Status { get; set; }
    }
}
