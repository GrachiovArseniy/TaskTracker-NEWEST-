using System.Collections.Generic;
using System.Linq;
using TaskTrecker.Model;
using UnityEngine;

public class TasksListBuilder : MonoBehaviour
{
    public void Init(TasksList tasksList, ExecutorAppointer executorAppointer)
    {
        _tasksList = tasksList;
        _executorAppointer = executorAppointer;
        Build();

        _tasksList.Updated += Build;
    }

    [Tooltip("Must have component TaskPresenter")]
    [SerializeField] private GameObject _taskPrefab;
    [SerializeField] private Transform _tasksParent;
    [SerializeField] private int _positionOfFirst = -390;
    [SerializeField] private int _distanceBetweenCases = 900;

    private readonly List<GameObject> _viewedTasks = new List<GameObject>();
    private TasksList _tasksList;
    private ExecutorAppointer _executorAppointer;

    public void Build()
    {
        _viewedTasks.ForEach(i => Destroy(i));
        _viewedTasks.Distinct();

        for (int i = 0; i < _tasksList.List.Count; i++)
        {
            GameObject deltaTask = Instantiate(_taskPrefab, _tasksParent);
            deltaTask.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, _positionOfFirst - (_distanceBetweenCases * i));
            deltaTask.name = i.ToString();
            deltaTask.GetComponent<TaskPresenter>().Init(_tasksList.List[i], _tasksList, _executorAppointer);
            _viewedTasks.Add(deltaTask);
        }

        _tasksParent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, _distanceBetweenCases * _viewedTasks.Count);
    }

    private void OnValidate()
    {
        if (_taskPrefab.TryGetComponent<TaskPresenter>(out _) == false)
        {
            Debug.LogError("Task prefab don't have TaskPresenter!");
        }
    }

    private void OnDisable()
    {
        _tasksList.Updated -= Build;
    }
}