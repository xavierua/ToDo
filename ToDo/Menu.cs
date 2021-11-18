
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
            Title = title;
        }

        public string Title { get; }

        public void AddNewItem(string title, string button, Action action)
        {
            var newItem = new MenuItem(title, button, action);
            _items[button] = newItem;
        }

        public string GetItems()
        {
            var listOfItems = new StringBuilder();
            foreach (MenuItem item in _items.Values)
            {
                listOfItems
                    .Append($"To {item.Title} press \'{item.Button}\'")
                    .AppendLine();
            }
            return listOfItems.ToString();
        }


        //private List<MenuItem> _itemsMenu = new();

        //public void AddMenuItem(string title, string button, Action action)
        //{
        //    MenuItem newMenuItem = new(title, button, action);
        //    _itemsMenu.Add(newMenuItem);
        //}

        //public bool IsButtonValid(string button)
        //{
        //    foreach (MenuItem item in _itemsMenu)
        //    {
        //        if (item.Button == button)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //public bool CheckButton(string button)
        //{
        //    foreach (MenuItem item in _itemsMenu)
        //    {
        //        if (item.Button == button)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public int FindIndexOfItem (string button)
        //{
        //    int itemIndex = -1;

        //    if (CheckButton(button))
        //    {
        //        for (int index = 0; index < _itemsMenu.Count; index++)
        //        {
        //            if(_itemsMenu[index].Button == button)
        //            {
        //                itemIndex = index;
        //                break;
        //            }
        //        }
        //    }

        //    return itemIndex;
        //}

        //public void ChangeButton(string button)
        //{
        //    int index = FindIndexOfItem(button);
        //}

        //public void DeleteItemMenu()
        //{   
        //}

        //public string ShowMenuItem()
        //{
        //    var menuInfo = new StringBuilder();

        //    foreach (MenuItem item in _itemsMenu)
        //    {
        //        menuInfo.Append($"Press \"{item.Button}\" to execute \"{item.Title}\"").AppendLine();
        //    }

        //    return menuInfo.ToString();
        //}


    }
}
