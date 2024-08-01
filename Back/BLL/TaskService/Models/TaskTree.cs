namespace BLL.TaskService.Models
{
    public class TaskTreeNode<T> where T : class
    {
        public T Data { get; set; }
        public List<TaskTreeNode<T>> Children { get; set; }

        public TaskTreeNode(T data)
        {
            Data = data;
            Children = [];
        }

        public void AddChild(TaskTreeNode<T> child)
        {
            Children.Add(child);
        }
    }

    public class TaskTree<T> where T : class
    {
        public TaskTreeNode<T> Root { get; set; }

        public TaskTree(TaskTreeNode<T> root)
        {
            Root = root;
        }
    }
}
