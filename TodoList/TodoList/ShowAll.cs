using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TodoList
{
    public partial class Todo
    {
        public void ShowAllTask()
        {
            using (var db = new TodoListContext())
            {
                Console.WriteLine("\n---------- Todo List ----------");
                //Display all TaskLists from the database
                var query = from l in db.TaskLists
                            join t in db.Tasks
                            on l.TaskListId equals t.TaskListId
                            orderby l.TaskListId
                            select new
                            {
                                l.TaskListId,
                                l.ListName,
                                t.TaskId,
                                t.Name,
                                t.Status
                            };
                Console.WriteLine("All Tasklists: ");
                Console.WriteLine($"{"ListID"}{"ListName",10}{"TaskID",10}{"TaskName",10}{"Status",15}");
                foreach (var item in query)
                {
                    Console.WriteLine($"{item.TaskListId,3}{item.ListName,10}{item.TaskId,10}{item.Name,10}{item.Status,20}");
                }
                Console.WriteLine("----------   Done!   ----------\n");
            }

        }
    }
}