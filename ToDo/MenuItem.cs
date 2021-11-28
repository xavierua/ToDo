using System;

namespace ToDo
{
    public class MenuItem
    {
        public MenuItem(string title, string button, Action action)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or empty.", nameof(title));
            }

            if (string.IsNullOrEmpty(button))
            {
                throw new ArgumentException($"'{nameof(button)}' cannot be null or empty.", nameof(button));
            }

            Title = title;
            Button = button;
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public string Title { get; }

        public string Button { get; }

        public Action Action { get; }
    }
}
