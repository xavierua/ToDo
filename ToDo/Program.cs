using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo
{
    internal class Program
    {
        private static int _position = 0;

        public static void Main(string[] args)
        {
            var taskList = new TaskList();
            var menu = new Menu("Main Menu");

            menu.AddNewItem("add new task", "a", () => ExecuteAddNewTask(taskList));
            menu.AddNewItem("add description", "e", () => ExecuteChangeDescription(taskList, _position));
            menu.AddNewItem("remove task", "x", () => ExecuteDeleteTask(taskList, _position));
            menu.AddNewItem("mark task as done", "d", () => ExecuteStatusTask(taskList, _position, "done"));
            menu.AddNewItem("mark task as undone", "u", () => ExecuteStatusTask(taskList, _position, "undone"));
            menu.AddNewItem("move up", "w", () => ExecuteChangePosition(taskList, _position, "up"));
            menu.AddNewItem("move down", "s", () => ExecuteChangePosition(taskList, _position, "down"));

            while (true)
            {
                PrintMenu(menu);
                PrintTaskList(taskList);

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
                        menu.ExecuteItem(userKey);
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

        public static void ExecuteAddNewTask(TaskList taskList)
        {
            Console.Write("\nEnter name of task: ");
            string taskTitle = Console.ReadLine();
            while (!IsValid(taskTitle))
            {
                Console.Write("The name of task can not be empty!\nEnter name of task: ");

                taskTitle = Console.ReadLine();
            }
            Task newTask = new(taskTitle);
            taskList.AddToList(newTask);
        }

        public static void ExecuteChangeDescription(TaskList taskList, int index)
        {
            Task task = taskList.GetTaskByIndex(index);
            Console.Write($"\nEnter desription for {task.Title}: ");
            string userInput = Console.ReadLine();
            task.ChangeDescription(userInput);
        }

        public static void ExecuteStatusTask(TaskList taskList, int index, string status)
        {
            if(taskList.IsIndexValid(_position))
            {
                var task = taskList.GetTaskByIndex(index);
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

        public static void ExecuteDeleteTask(TaskList taskList, int index)
        {
            if(!taskList.IsEmpty())
            {
                if (index > 0)
                {
                    taskList.DeleteTask(index);
                    _position -= 1;
                }
                else
                {
                    taskList.DeleteTask(index);
                }
            }
            else
            {
                Console.WriteLine("The task list is empty!");
            }
        }

        public static void ExecuteChangePosition(TaskList taskList, int index, string direction)
        {
            if (direction == "up")
            {
                if (IsPositionValid(taskList.Count, index, direction))
                {
                    _position -= 1;
                }
            }
            else
            {
                if (IsPositionValid(taskList.Count, index, direction))
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
                .Append($"\t{menu.Title}")
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
            for (int i = 0; i < taskList.Count; i++)
            {
                var task = taskList.GetTaskByIndex(i);

                Console.ForegroundColor = _position == i ? ConsoleColor.Blue : ConsoleColor.Yellow;

                var builder = new StringBuilder();
                builder
                    .Append($"{i + 1}")
                    .AppendLine($"\tName: {task.Title}")
                    .AppendLine($"\tDescription: {task.Description}")
                    .AppendLine($"\tCreated At: {task.CreatedAt}")
                    .AppendLine($"\tCompleted At: {(task.IsDone ? task.CompletedAt : "Not complete")}");
                Console.WriteLine(builder.ToString());
                if (!taskList.IsEmpty())
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

        public static bool IsPositionValid(int taskCount, int position, string wayToMove)
        {
            bool moveUP = 0 < position;
            bool moveDown = position < taskCount - 1;
            return wayToMove == "up" ? moveUP : moveDown;
        }
    }
}
