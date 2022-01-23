using System.Collections.Generic;
using BarGraph.VittorCloud;
using Extentions;
using TaskTrecker.Model;
using UnityEngine;

public class BarGraphView : GraphView
{
    public void Init(BarGraphGenerator barGraphGenerator, TasksList tasksList)
    {
        _barGraphGenerator = barGraphGenerator;
        _tasksList = tasksList;
        UpdateModel();

        _tasksList.Updated += UpdateModel;
    }

    [Header("Colors of bars")]
    [SerializeField] private Material _backlog;
    [SerializeField] private Material _appointed;
    [SerializeField] private Material _inProgress;
    [SerializeField] private Material _underReview;
    [SerializeField] private Material _accepted;
    [SerializeField] private Material _notAccepted;
    private BarGraphGenerator _barGraphGenerator;

    private void UpdateModel()
    {
        List<BarGraphDataSet> dataSets = new List<BarGraphDataSet>();
        List<string> executorNames = new List<string>();

        foreach (Task task in _tasksList.List)
        {
            if (executorNames.Contains(task.Executor) == false)
            {
                executorNames.Add(task.Executor);
            }
        }

        foreach (Task task in _tasksList.List)
        {
            BarGraphDataSet set = dataSets.FindOrCreate(new BarGraphDataSet(), (i => i.GroupName == task.Status.GetString()));

            if (set.ListOfBars == null)
            {
                set.ListOfBars = new List<XYBarValues>();

                foreach (string name in executorNames)
                {
                    set.ListOfBars.Add(new XYBarValues(name));
                }
            }

            set.GroupName = task.Status.GetString();
            set.ListOfBars.Find(i => i.XValue == task.Executor).YValue++;

            if (set.barMaterial == null)
            {
                switch (task.Status)
                {
                    case TaskStatus.Backlog:
                        set.barMaterial = _backlog;
                        break;
                    case TaskStatus.Appointed:
                        set.barMaterial = _appointed;
                        break;
                    case TaskStatus.InProgress:
                        set.barMaterial = _inProgress;
                        break;
                    case TaskStatus.UnderReview:
                        set.barMaterial = _underReview;
                        break;
                    case TaskStatus.Accepted:
                        set.barMaterial = _accepted;
                        break;
                    case TaskStatus.NotAccepred:
                        set.barMaterial = _notAccepted;
                        break;
                }
            }
        }

        try
        {
            Destroy(GetComponentInChildren<BarGraphManager>().gameObject); // Deleting the previous graph
        }
        catch { }

        _barGraphGenerator.GeneratBarGraph(dataSets);
    }

    private void OnDisable()
    {
        _tasksList.Updated -= UpdateModel;
    }
}