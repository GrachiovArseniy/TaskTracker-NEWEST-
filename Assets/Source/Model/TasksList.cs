using System;
using System.Collections.Generic;

namespace TaskTrecker.Model
{
    public class TasksList
    {
        public IReadOnlyList<IReadOnlyTask> List => _list;

        private readonly List<Task> _list = new List<Task>();

        public event Action Updated;

        public void Add(string title, string description, string dueDate, string tag)
        {
            _list.Add(new Task(title, description, dueDate, tag));
            Updated?.Invoke();
        }

        public void AddRange(List<Task> readOnlyTasks)
        {
            foreach (Task task in readOnlyTasks)
            {
                _list.Add(new Task(task.Title, task.Description, task.DueDate, task.Tag, task.Executor, task.Status));
            }

            Updated?.Invoke();
        }

        public void Remove(int id)
        {
            _list.Remove(_list[id]);
            Updated?.Invoke();
        }

        /// <summary>
        /// Assigns an executor to the task, with the specified id
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <param name="executor">Executor name</param>
        public void AppointExecutor(int id, string executor)
        {
            _list[id].Appoint(executor);
            Updated?.Invoke();
        }

        public void UpdateStatusOf(int id)
        {
            _list[id].UpdateStatus();
            Updated?.Invoke();
        }

        public void Accept(int id)
        {
            _list[id].Accept();
            Updated?.Invoke();
        }

        public void Reject(int id)
        {
            _list[id].Reject();
            Updated?.Invoke();
        }
    }
}
