using System.Collections.Generic;

namespace ToDo
{
    public class TaskList
    {
        private List<Task> _tasks = new();

        public int Count { get { return _tasks.Count; } }

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
        public List<Task> ListOfTask()
        {
            return _tasks;
        }
        public Task GetTaskByIndex(int index)
        {
            return _tasks[index];
        }
        public bool IsIndexValid(int index)
        {
            if(!IsEmpty())
            {
                if (0 <= index && index < _tasks.Count)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsEmpty()
        {
            return _tasks.Count == 0;
        }
    }
}
