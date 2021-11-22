using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo
{
    internal class Program
    {
        private static int _position = 0;
        private static TaskList _taskList = new();
        private static Menu _menu = new("Main Menu");
        public static void Main(string[] args)
        {
            _menu.AddNewItem("add new task", "a", ExecuteAddNewTask);
            _menu.AddNewItem("add description", "e", ExecuteChangeDescription);
            _menu.AddNewItem("remove task", "x", ExecuteDeleteTask);
            _menu.AddNewItem("mark task as done", "d", () => ExecuteStatusTask(_position, "done"));
            _menu.AddNewItem("mark task as undone", "u", () => ExecuteStatusTask(_position, "undone"));
            _menu.AddNewItem("move up", "w", () => ExecuteChangePosition(_position, "up"));
            _menu.AddNewItem("move down", "s", () => ExecuteChangePosition(_position, "down"));
            while (true)
            {
                PrintMenu(_menu);
                PrintTaskList(_taskList);
                var userChoice = Console.ReadKey();
                string userKey = userChoice.Key.ToString().ToLower();
                switch (userChoice.Key)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.E:
                    case ConsoleKey.D:
                    case ConsoleKey.U:
                    case ConsoleKey.X:
                    case ConsoleKey.W:
                    case ConsoleKey.S:
                        _menu.ExecuteItem(userKey);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.Write("Wrong button, try again: ");
                        break;
                }
                Console.Clear();
            }
        }
        public static void ExecuteAddNewTask()
        {
            Console.Write("\nEnter name of task: ");
            string taskTitle = Console.ReadLine();
            while (!IsValid(taskTitle))
            {
                Console.Write("The name of task can not be empty!\nEnter name of task: ");

                taskTitle = Console.ReadLine();
            }
            Task newTask = new(taskTitle);
            _taskList.AddToList(newTask);
        }
        public static void ExecuteChangeDescription()
        {
            Task task = _taskList.GetTaskByIndex(_position);
            Console.Write($"\nEnter desription for {task.Title}: ");
            string userInput = Console.ReadLine();
            task.ChangeDescription(userInput);
        }
        public static void ExecuteStatusTask(int index, string status)
        {
            if(_taskList.IsIndexValid(_position))
            {
                var task = _taskList.GetTaskByIndex(index);
                if (status == "done")
                {
                    task.MarkAsDone();
                }
                else
                {
                    task.MarkAsUndone();
                }
            }
            else
            {
                Console.WriteLine("The task list is empty!");
            }
        }
        public static void ExecuteDeleteTask()
        {
            if(!_taskList.IsEmpty())
            {
                if (_position > 0)
                {
                    _taskList.DeleteTask(_position);
                    _position -= 1;
                }
                else
                {
                    _taskList.DeleteTask(_position);
                }
            }
            else
            {
                Console.WriteLine("The task list is empty!");
            }
        }
        public static void ExecuteChangePosition(int index, string direction)
        {
            if (direction == "up")
            {
                if (IsPositionValid(index, direction))
                {
                    _position -= 1;
                }
            }
            else
            {
                if (IsPositionValid(index, direction))
                {
                    _position += 1;
                }
            }

        }
        public static void PrintMenu(Menu menu)
        {
            var items = menu.GetItems();
            Console.ForegroundColor = ConsoleColor.Green;
            var menuInfo = new StringBuilder();
            menuInfo
                .Append($"\t{_menu.Title}")
                .AppendLine();
            foreach (MenuItem item in items)
            {
                menuInfo
                    .AppendLine()
                    .Append($"Press \'{item.Button}\' - to {item.Title}");
            }
            menuInfo
                .AppendLine()
                .Append('=', 40);
            Console.WriteLine(menuInfo.ToString());
        }
        public static void PrintTaskList(TaskList taskList)
        {
            var tasks = taskList.ListOfTask();
            for (int i = 0; i < tasks.Count; i++)
            {
                if (_position == i)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                var builder = new StringBuilder();
                builder
                    .Append($"{i + 1}")
                    .AppendLine($"\tName: {tasks[i].Title}")
                    .AppendLine($"\tDescription: {tasks[i].Description}")
                    .AppendLine($"\tCreated At: {tasks[i].CreatedAt}")
                    .AppendLine($"\tCompleted At: {(tasks[i].IsDone ? tasks[i].CompletedAt : "Not complite")}");
                Console.WriteLine(builder.ToString());
                if (!_taskList.IsEmpty())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(new string('-', 40));
                }
            }
        }
        public static bool IsValid(string userInput)
        {

            return userInput != string.Empty || userInput != null;
        }
        public static bool IsPositionValid(int position, string wayToMove)
        {
            bool moveUP = 0 < position;
            bool moveDown = position < _taskList.Count - 1;
            if (wayToMove == "up")
            {
                return moveUP;
            }
            else
            {
                return moveDown;
            }
        }
    }
}
