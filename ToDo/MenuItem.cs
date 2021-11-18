using System;

namespace ToDo
{
    public class MenuItem
    {
        public MenuItem(string title, string button, Action action)
        {
            Title = title;
            Button = button;
            Action = action;
        }

        public string Title { get; set; }

        public string Button { get; set; }

        public Action Action { get; set; }

    }
}
