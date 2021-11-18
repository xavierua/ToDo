using System.Collections.Generic;

namespace ToDo
{
    public class TaskList
    {
        private List<Task> _tasks = new();

        public void AddToList(Task task)
        {
            _tasks.Add(task);
        }

        public bool DeleteTask(int taskId)
        {
            var indexIsInvalid = _tasks.Count == 0
                || taskId >= _tasks.Count
                || taskId < 0;
            return indexIsInvalid
                ? false
                : _tasks.Remove(_tasks[taskId]);
        }

        public List<Task> GetTaskList()
        {
            return _tasks;
        }

        public bool IsEmpty()
        {
            return _tasks.Count == 0;
        }
    }
}
