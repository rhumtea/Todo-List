using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_TodoList
{
    public class Todo
    {
        public static void ListItem()
        {
            var toDoList = new List<string>();
            var appRun = true;
            Console.WriteLine("Welcome to my first Simple To Do List");
            // If input start with command, app will do as required.
            // '-Exit': Exit App
            // '-Show': Display TodoList
            // '-Remove': Remove item
            // default: Add item to TodoList
            while (appRun)
            {
                Console.WriteLine("What do you want?");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Show Todo List");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Which task do you want to add?");
                        var taskNameAdd = Console.ReadLine();
                        toDoList.Add(taskNameAdd);
                        break;
                    case "2":
                        Console.WriteLine("\n---------- Todo List ----------");
                        foreach (var task in toDoList)
                        {
                            Console.WriteLine(task);
                        }
                        Console.WriteLine("----------   Done!   ----------\n");
                        break;
                    case "3":
                        Console.WriteLine("Which task do you want to remove?");
                        var taskNameRemove = Console.ReadLine();
                        if (toDoList.Contains(taskNameRemove))
                        {
                            toDoList.Remove(taskNameRemove);
                            Console.WriteLine("Removed {0} \n", taskNameRemove);
                        }
                        else
                        {
                            Console.WriteLine("{0} is not in todo list", taskNameRemove);
                        }
                        break;
                    case "4":
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
