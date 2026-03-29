using System;

namespace TaskManagerApp
{
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Done
    }

    public enum TaskPriority
    {
        High,
        Medium,
        Low
    }

    public class TaskItem
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public DateTime Deadline { get; set; }
        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
    }
}