using System;

namespace ToDo
{
    public class Task
    {
        public Task(string title)
        {
            Title = title;
            Description = string.Empty;
            IsDone = false;
            CompletedAt = null;
            CreatedAt = DateTime.UtcNow;
        }

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
        public void ChangeDescription(string description)
        {
            Description = description;
        }
    }
}
