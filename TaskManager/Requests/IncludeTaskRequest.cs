using System.Collections.Generic;

namespace TaskManager.Requests
{
    public class IncludeTaskRequest
    {
        public IEnumerable<TaskRequest> Tasks { get; set; }
    }
}
