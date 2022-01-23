using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TaskTrecker.Model
{
    public class Saver
    {
        public Saver(TasksList taskList, string filePath)
        {
            _tasksList = taskList;
            _filePath = filePath;
        }

        private readonly TasksList _tasksList;
        private readonly string _filePath;
        private const string _fileName = "TaskTrackerSave.json";

        public void Save()
        {
            string json = JsonConvert.SerializeObject(_tasksList.List, Formatting.Indented);
            File.WriteAllText(_filePath + _fileName, json);
        }

        public void Restore()
        {
            if (File.Exists(_filePath + _fileName))
            {
                List<DeltaTask> deltaTasks = JsonConvert.DeserializeObject<List<DeltaTask>>(File.ReadAllText(_filePath + _fileName));

                List<Task> tasks = new List<Task>();

                foreach (DeltaTask task in deltaTasks)
                {
                    tasks.Add(new Task(task.Title, task.Description, task.DueDate, task.Tag, task.Executor, task.Status));
                }

                _tasksList.AddRange(tasks);
            }
        }

        private class DeltaTask
        {
            public TaskStatus Status;
            public string Title;
            public string Description;
            public string Executor;
            public string DueDate;
            public string Tag;
        }
    }
}