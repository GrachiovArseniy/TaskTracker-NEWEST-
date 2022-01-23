using BarGraph.VittorCloud;
using TaskTrecker.Model;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private TaskCreator _taskCreator;
    [SerializeField] private ExecutorAppointer _executorAppointer;
    [SerializeField] private TasksListBuilder _tasksListBuilder;
    [SerializeField] private SaverPresenter _saverPresenter;
    [SerializeField] private GraphSwitch _graphSwitch;
    [SerializeField] private BarGraphGenerator _barGraphGenerator;
    [SerializeField] private BarGraphView _barGraphView;
    [SerializeField] private PieChart.ViitorCloud.PieChart _pieChart;
    [SerializeField] private PiechartGraphView _piechartGraphView;
    [SerializeField] private string _jsonFilePath;

    private TasksList _tasksList;
    private Saver _saver;

    private void Awake()
    {
        _tasksList = new TasksList();
        _saver = new Saver(_tasksList, _jsonFilePath);

        _taskCreator.Init(_tasksList);
        _executorAppointer.Init(_tasksList);
        _tasksListBuilder.Init(_tasksList, _executorAppointer);
        _saverPresenter.Init(_saver);
        _barGraphView.Init(_barGraphGenerator, _tasksList);
        _piechartGraphView.Init(_pieChart, _tasksList);
    }
}
