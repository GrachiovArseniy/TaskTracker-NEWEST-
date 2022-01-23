using TaskTrecker.Model;
using UnityEngine;

public abstract class Operator : MonoBehaviour
{
    public void Init(TasksList tasksList)
    {
        _tasksList = tasksList;
    }

    protected TasksList _tasksList;

    /// <summary>
    /// Interact with the model
    /// </summary>
    public abstract void Ability();
}
