using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public enum Status
    {
        NotCompleted = 0,
        Completed = 1
    }
    public class TaskList
    {
        private static int id = 1;
        int generateTaskLisId()
        {

            return id++;
        }
        public int TaskListId
        {
            get { return id; }
            set { id = value; }
        }
        public string ListName { get; set; }
        public List<Task> Task { get; set; }
    }
    public class Task
    {
        private int id = 1;

        public int TaskId
        {
            get { return id; }
            set { id = value; }
        }
        public string Name { get; set; }
        public Status Status { get; set; }
        public int TaskListId { get; set; }
        public TaskList TaskList { get; set; }
    }
    public class TodoListContext : DbContext
    {
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
