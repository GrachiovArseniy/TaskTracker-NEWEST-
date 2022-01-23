using System.Linq;
using Extentions;
using TaskTrecker.Model;
using UnityEngine;
using UnityEngine.UI;

public class TaskPresenter : MonoBehaviour
{
    public void Init(IReadOnlyTask task, TasksList taskList, ExecutorAppointer executorAppointer)
    {
        _taskList = taskList;
        _task = task;
        _executorAppointer = executorAppointer;
        _removeOperator.Init(taskList);
        _removeOperator.Id = Id;
        OnStateUpdated();

        _task.Updated += OnStateUpdated;
    }

    [SerializeField] private RemoveOperator _removeOperator;
    [SerializeField] private Text _title;
    [SerializeField] private Text _description;
    [SerializeField] private Text _executor;
    [SerializeField] private Text _dueDate;
    [SerializeField] private Text _status;

    private TasksList _taskList;
    private IReadOnlyTask _task;
    private ExecutorAppointer _executorAppointer;

    public int Id => _taskList.List.ToList().IndexOf(_task);

    public void UpdateState()
    {
        _taskList.UpdateStatusOf(Id);
    }

    public void OpenExecutorAppointerWindow()
    {
        _executorAppointer.Window.Open();
        _executorAppointer.DeltaId = Id;
    }

    private void OnStateUpdated()
    {
        _title.text = _task.Title;
        _description.text = _task.Description;
        _executor.text = _task.Executor;
        _dueDate.text = _task.DueDate;
        _status.text = _task.Status.GetString();
    }

    private void OnDisable()
    {
        _task.Updated -= OnStateUpdated;
    }
}
