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
        public void AddTask(string taskListName, string taskName)
        {
            using (var db = new TodoListContext())
            {
                // Check if the task list exists, create a new one if not
                var taskList = db.TaskLists.Include(tl => tl.Task)
                                    .FirstOrDefault(tl => tl.ListName.Equals(taskListName, StringComparison.OrdinalIgnoreCase));

                if (taskList == null)
                {
                    taskList = new TaskList { ListName = taskListName };
                    db.TaskLists.Add(taskList);
                    var task = new Task { TaskId = 1, Name = taskName, Status = 0 };
                    if (taskList.Task == null) taskList.Task = new List<Task>();
                    taskList.Task.Add(task);
                }
                else
                {
                    // Create a new task and add it to the task list
                    var task = new Task { Name = taskName, Status = 0 };
                    if (taskList.Task == null) taskList.Task = new List<Task>();
                    taskList.Task.Add(task);
                }

                // Save changes to the database
                db.SaveChanges();

                Console.WriteLine($"Task added successfully to the '{taskListName}' task list.");
            }
        }
    }
}
