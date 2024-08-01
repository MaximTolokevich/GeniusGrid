using BLL.UserService.Models;

namespace BLL.TaskService.Models
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User AssignetBy { get; set; }
        public User AssignetTo { get; set; }
        public Range<DateTime> Range { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public DateTime Complited { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
        public TaskTree<TaskItem> SubTasks { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Created;
    }
}
