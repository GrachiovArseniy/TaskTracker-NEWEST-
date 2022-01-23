namespace TaskTrecker.Model
{
    public enum TaskStatus
    {
        Backlog,
        Appointed,
        InProgress,
        UnderReview,
        Accepted,
        NotAccepred
    }

    public class Task : IReadOnlyTask
    {
        public Task(string title, string description, string dueDate, string tag)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Tag = tag;
        }

        public Task(string title, string description, string dueDate, string tag, string executor, TaskStatus status)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Tag = tag;
            Executor = executor;
            Status = status;
        }

        internal void Appoint(string executor)
        {
            Executor = executor;
            Status = TaskStatus.Appointed;
            Update();
        }

        internal void UpdateStatus()
        {
            if (Status == TaskStatus.UnderReview)
            {
                InvokeCheckAction();
                return;
            }

            switch (Status)
            {
                case TaskStatus.Appointed:
                    Status = TaskStatus.InProgress;
                    break;
                case TaskStatus.InProgress:
                    Status = TaskStatus.UnderReview;
                    break;
            }

            Update();
        }

        internal void Accept()
        {
            Status = TaskStatus.Accepted;
            Update();
        }

        internal void Reject()
        {
            Status = TaskStatus.NotAccepred;
            Update();
        }
    }
}