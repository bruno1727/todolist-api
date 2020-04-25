using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;
using TaskManager.Requests;

namespace TaskManager.Business
{
    public static class TaskBusiness
    {
        public static void AddTask(IncludeTaskRequest request)
        {
            using (var db = new TaskContext())
            {
                var task = new TaskModel
                {
                    Description = request.Task
                };
                db.Task.Add(task);
                db.SaveChanges();
            }
        }

        public static List<string> GetTasks()
        {
            using (var db = new TaskContext())
            {
                return db.Task.Select(t => t.Description).ToList();
            }
        }

        public static void RemoveTask(string task)
        {
            using (var db = new TaskContext())
            {
                var result = db.Task.FirstOrDefault(t => t.Description == task);
                db.Task.Remove(result);
            }
        }
    }
}
