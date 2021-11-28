using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public class Menu
    {
        private Dictionary<string, MenuItem> _items = new();

        public Menu(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
            }

            Title = title;
        }

        public string Title { get; }

        public void AddNewItem(string title, string button, Action action)
        {
            var newItem = new MenuItem(title, button, action);
            _items[button] = newItem;
        }

        public void ExecuteItem(string key)
        {
            if(CheckIsKeyValid(key))
            {
                _items[key].Action();
            }
            
        }

        public List<MenuItem> GetItems()
        {
            List<MenuItem> itemsList = new();
            foreach (MenuItem item in _items.Values)
            {
                itemsList.Add(item);
            }
            return itemsList;
        }

        private bool CheckIsKeyValid(string key)
        {
            return _items.ContainsKey(key);
        }
    }
}