using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo
{
    class Program
    {
        private static TaskList _listOfTasks = new();
        private static int _positionInTask = 0;
        private static int _numberOfTask;
        private static Menu _menu = new("Main Menu");

        static void Main(string[] args)
        {
            _menu.AddNewItem("add new task", "a", ExecuteAddNewTask);
            _menu.AddNewItem("add description", "e", ExecuteAddDescription);
            _menu.AddNewItem("remove task", "x", );
            _menu.AddNewItem("mark task  as done", "d", );
            Console.WriteLine(_menu.GetItems());
            while (true)
            {
                Console.WriteLine(NavigationMenu());
                //Console.WriteLine(_numberOfTasks);
                Console.WriteLine(_positionInTask);

                ShowTaskList();
                _numberOfTask = GetNumberOfTask();

                var userChoice = Console.ReadKey();

                switch (userChoice.Key)
                {
                    case ConsoleKey.A:
                        ExecuteAddNewTask();
                        break;
                    case ConsoleKey.E:
                        ExecuteAddDescription();
                        break;
                    case ConsoleKey.D:
                        ExecuteStatusTask("done");
                        break;
                    case ConsoleKey.U:
                        ExecuteStatusTask("undone");
                        break;
                    case ConsoleKey.X:
                        ExecuteDeleteTask();
                        break;
                    case ConsoleKey.W:
                        ExecuteChangePosition(_positionInTask, "up");
                        break;
                    case ConsoleKey.S:
                        ExecuteChangePosition(_positionInTask, "down");
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
            _listOfTasks.AddToList(newTask);
        }

        public static void ExecuteAddDescription()
        {
            Task task = _listOfTasks.GetTaskList()[_positionInTask];
            Console.Write($"\nEnter desription for {task.Title}: ");
            string userInput = Console.ReadLine();
            task.AddDescription(userInput);
        }

        public static void ExecuteStatusTask(string status)
        {
            if (status == "done")
            {
                _listOfTasks.GetTaskList()[_positionInTask].MarkAsDone();
            }
            else
            {
                _listOfTasks.GetTaskList()[_positionInTask].MarkAsUndone();
            }
        }

        public static void ExecuteDeleteTask()
        {
            if (_positionInTask > 0)
            {
                _listOfTasks.DeleteTask(_positionInTask);
                _positionInTask -= 1;
            }
            else
            {
                _listOfTasks.DeleteTask(_positionInTask);
            }
        }

        public static void ExecuteChangePosition(int index, string direction)
        {
            if (direction == "up")
            {
                if (IsIndexValid(index, direction))
                {
                    _positionInTask -= 1;
                }
            }
            else
            {
                if (IsIndexValid(index, direction))
                {
                    _positionInTask += 1;
                }
            }

        }

        public static string NavigationMenu()
        {
            var menuInfo = new StringBuilder();

            

            Console.ForegroundColor = ConsoleColor.Green;
            return menuInfo.ToString();
        }

        public static void ShowTaskList()
        {
            List<Task> taskList = _listOfTasks.GetTaskList();

            for (int i = 0; i < taskList.Count(); i++)
            {
                if (_positionInTask == i)
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
                    .AppendLine($"\tName: {taskList[i].Title}")
                    .AppendLine($"\tDescription: {taskList[i].Description}")
                    .AppendLine($"\tCreated At: {taskList[i].CreatedAt}")
                    .AppendLine($"\tCompleted At: {(taskList[i].IsDone ? taskList[i].CompletedAt : "Not complite")}");

                Console.WriteLine(builder.ToString());
                if (!_listOfTasks.IsEmpty())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(new string('-', 40));
                }
            }
        }

        public static int GetNumberOfTask()
        {
            return _listOfTasks.GetTaskList().Count;
        }

        public static bool IsValid(string userInput)
        {

            return userInput != string.Empty;
        }

        public static bool IsIndexValid(int index, string wayToMove)
        {
            bool moveUP = 0 < index;
            bool moveDown = index < _numberOfTask - 1;

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
