using UnityEngine;

public class GraphSwitch : MonoBehaviour
{
    [SerializeField] private Animation[] _graphs;
    [SerializeField] private string _openAnimationName = "Open";
    [SerializeField] private string _closeAnimationName = "Close";
    private int _deltaId = 0;

    public void Next()
    {
        _graphs[_deltaId].Play(_closeAnimationName);
        _deltaId++;

        if (_deltaId == _graphs.Length)
        {
            _deltaId = 0;
        }

        _graphs[_deltaId].Play(_openAnimationName);
    }

    private void OnValidate()
    {
        for (int i = 0; i < _graphs.Length; i++)
        {
            try
            {
                _graphs[i].GetClip("Open");
                _graphs[i].GetClip("Close");
            }
            catch (System.Exception)
            {
                Debug.LogError($"Graph with id {i} must have animations with names {_openAnimationName} and {_closeAnimationName}!");
            }
        }

        if (_graphs.Length < 2)
        {
            Debug.LogError("The number of graphs must be at least 2!");
        }
    }
}