using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Requests;

namespace TaskManager.Business
{
    public static class Task
    {
        private static List<string> Tasks { get; set; } = new List<string>()
        {
            "Escovar os dentes",
            "Tomar café da manha",
            "Ir trabalhar",
        };

        public static void AddTask(IncludeTaskRequest request)
        {
            Tasks.Add(request.Task);
        }

        public static List<string> GetTasks()
        {
            return Tasks;
        }

        public static void RemoveTask(string task)
        {
            Tasks.Remove(task);
        }
    }
}
