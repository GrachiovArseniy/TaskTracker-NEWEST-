using BarGraph.VittorCloud;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TaskTrecker.Model;

public class BarGraphView : MonoBehaviour
{
    public void Init(BarGraphGenerator barGraphGenerator, TasksList tasksList)
    {
        _barGraphGenerator = barGraphGenerator;
        _tasksList = tasksList;
    }

    public List<BarGraphDataSet> exampleDataSet; // public data set for inserting data into the bar graph
    private BarGraphGenerator _barGraphGenerator;
    private TasksList _tasksList;

    private void OnDisable()
    {
        _tasksList.Updated -= UnityEngine.PlayerLoop.Update;
    }
    
    void GenerateRandomData()
    {

        int dataSetIndex = UnityEngine.Random.Range(0, exampleDataSet.Count);
        int xyValueIndex = UnityEngine.Random.Range(0, exampleDataSet[dataSetIndex].ListOfBars.Count);
        exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue = UnityEngine.Random.Range(_barGraphGenerator.yMinValue, _barGraphGenerator.yMaxValue);
        _barGraphGenerator.AddNewDataSet(dataSetIndex, xyValueIndex, exampleDataSet[dataSetIndex].ListOfBars[xyValueIndex].YValue);
    }
}