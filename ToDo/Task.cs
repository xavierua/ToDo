using System;

namespace ToDo
{
    public class Task
    {

        private static int ID = 0;
        public Task(string title)
        {
            TaskID = ID;
            Title = title;
            Description = string.Empty;
            IsDone = false;
            CompletedAt = null;
            CreatedAt = DateTime.UtcNow;
            ID += 1;
        }
        public int TaskID { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public DateTime? CreatedAt { get; private set; }

        public override string ToString()
        {
            return $"Title: {Title}\n\tDescription: {Description}\n\tIs Done: {IsDone}\n\tCreated At: {CreatedAt}\n\tCompleted At: {CompletedAt}\n";
        }

        public void MarkAsDone()
        {
            IsDone = true;
            CompletedAt = DateTime.UtcNow;
        }

        public void MarkAsUndone()
        {
            IsDone = false;
            CompletedAt = null;
        }

        public void AddDescription(string description)
        {
            Description = description;
        }
    }
}
