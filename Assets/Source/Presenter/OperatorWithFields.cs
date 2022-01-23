using UnityEngine;
using UnityEngine.UI;

public abstract class OperatorWithFields : Operator
{
    [SerializeField] public Window Window;
    [SerializeField] protected Text _error;
    [Tooltip("If not all fields are filled in")]
    [SerializeField] protected string _errorText;

    protected abstract bool FieldsCorrect();

    public void Perform()
    {
        if (FieldsCorrect() == false)
        {
            _error.text = _errorText;
            return;
        }

        Ability();
    }

    public void ResetError()
    {
        _error.text = string.Empty;
    }
}
