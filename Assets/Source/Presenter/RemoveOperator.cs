using UnityEngine;

public class RemoveOperator : Operator
{
    [HideInInspector] public int Id;

    public override void Ability()
    {
        _tasksList.Remove(Id);
    }
}
