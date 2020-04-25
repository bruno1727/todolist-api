using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;
using TaskManager.Requests;
using TaskManager.Response;

namespace TaskManager.Business
{
    public static class TaskBusiness
    {
        public static void AddTask(IncludeTaskRequest request)
        {
            using (var db = new TaskContext())
            {
                var tasks = request.Tasks.Select(t => new TaskModel { Description = t.Description });
                db.Task.AddRange(tasks);
                db.SaveChanges();
            }
        }

        public static IEnumerable<TaskModel> GetTasks()
        {
            using (var db = new TaskContext())
            {
                return db.Task.ToList();
            }
        }

        public static IEnumerable<TaskModel> RemoveTask(DeleteTaskRequest request)
        {
            using (var db = new TaskContext())
            {
                var deleted = new List<TaskModel>();
                foreach(var id in request.TaskIds)
                {
                    var task = db.Task.Find(id);
                    db.Task.Remove(task);
                    deleted.Add(task);
                }
                db.SaveChanges();
                return deleted;
            }
        }
    }
}
