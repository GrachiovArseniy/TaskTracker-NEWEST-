using UnityEngine;
using UnityEngine.UI;

public class ExecutorAppointer : OperatorWithFields
{
    [SerializeField] private InputField _newName;
    public int DeltaId;

    public override void Ability()
    {
        _tasksList.AppointExecutor(DeltaId, _newName.text);
        Window.Close();
    }

    protected override bool FieldsCorrect()
    {
        return string.IsNullOrWhiteSpace(_newName.text) == false;
    }
}
