using System.Collections.Generic;
using System.Linq;
using Extentions;
using TaskTrecker.Model;
using UnityEngine.SceneManagement;

public class PiechartGraphView : GraphView
{
    public void Init(PieChart.ViitorCloud.PieChart pieChart, TasksList tasksList)
    {
        _pieChart = pieChart;
        _tasksList = tasksList;

        InitGraph();
    }

    private readonly List<string> _dataNames = new List<string>
    {
        TaskStatus.Backlog.GetString(),
        TaskStatus.Appointed.GetString(),
        TaskStatus.InProgress.GetString(),
        TaskStatus.UnderReview.GetString(),
        TaskStatus.Accepted.GetString(),
        TaskStatus.NotAccepred.GetString(),
    };

    private PieChart.ViitorCloud.PieChart _pieChart;

    private void InitGraph()
    {
        for (int i = 0; i < _pieChart.Data.Length; i++)
        {
            _pieChart.Data[i] = _tasksList.List.Where(t => t.Status.GetString() == _dataNames[i]).Count();
        }

        _pieChart.enabled = true;
    }

    public void UpdateGraph()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
