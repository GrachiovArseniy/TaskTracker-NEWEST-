using UnityEngine;
using UnityEngine.UI;

public class TaskCreator : OperatorWithFields
{
    [SerializeField] private InputField _title;
    [SerializeField] private InputField _description;
    [SerializeField] private InputField _dueDate;
    [SerializeField] private InputField _tag;

    public override void Ability()
    {
        _tasksList.Add(_title.text, _description.text, _dueDate.text, _tag.text);
        Window.Close();
    }

    protected override bool FieldsCorrect()
    {
        return string.IsNullOrWhiteSpace(_title.text) == false || string.IsNullOrWhiteSpace(_description.text) == false || string.IsNullOrWhiteSpace(_dueDate.text) == false || string.IsNullOrWhiteSpace(_tag.text) == false;
    }
}