using System.Collections.Generic;

namespace TaskManager.Requests
{
    public class DeleteTaskRequest
    {
        public IEnumerable<int> TaskIds { get; set; }
    }
}
