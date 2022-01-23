using System;

namespace TaskTrecker.Model
{
    public class IReadOnlyTask
    {
        public event Action Check;
        public event Action Updated;

        public TaskStatus Status { get; protected set; } = TaskStatus.Backlog;
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Executor { get; protected set; } = "Not appoint";
        public string DueDate { get; protected set; }
        public string Tag { get; protected set; }

        protected void Update()
        {
            Updated?.Invoke();
        }

        protected void InvokeCheckAction()
        {
            Check?.Invoke();
        }
    }
}