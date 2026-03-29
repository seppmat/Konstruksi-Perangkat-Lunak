using System.Collections.Generic;

namespace TaskManagerApp
{
    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public List<TaskItem> GetAll()
        {
            return tasks;
        }

        public void Add(TaskItem task)
        {
            tasks.Add(task);
        }

        public void Update(int index, TaskItem task)
        {
            tasks[index] = task;
        }

        public void Delete(int index)
        {
            tasks.RemoveAt(index);
        }
    }
}