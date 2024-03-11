using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TodoList
{
    class Program
    {
        static void Main(string[] args)
        {
            Todo todo = new Todo(); // create an instance of Todo
            var appRun = true;
            Console.WriteLine("Welcome to my To Do List");
            // If input start with command, app will do as required.
            // '3': Exit App
            // '2': Display TodoList
            // '1': Add item to TodoList
            while (appRun)
            {
                Console.WriteLine("What do you want?");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Show All Todo List");
                Console.WriteLine("3. Exit");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("List name: ");
                        string taskListName = Console.ReadLine();
                        Console.WriteLine("Task Name: ");
                        string taskName = Console.ReadLine();
                        todo.AddTask(taskListName, taskName);
                        break;
                    case "2":
                        todo.ShowAllTask();
                        break;
                    case "3":
                        appRun = false;
                        break;
                    default:
                        Console.WriteLine("Have some issue with command! What do you want?");
                        break;
                }
            }
        }
    }
}