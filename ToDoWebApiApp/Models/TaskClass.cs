namespace ToDoWebApiApp.Models
{
    public class TaskClass
    {
        public TaskClass()
        {

        }

        public TaskClass(string title, string description)
        {
            Title = title;
            Description = description;
        }

        
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Priority Priority { get; set; } = Priority.Low;
        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.NotStarted;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
