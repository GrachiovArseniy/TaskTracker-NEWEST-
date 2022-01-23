using UnityEngine;
using TaskTrecker.Model;

public class SaverPresenter : MonoBehaviour
{
    public void Init(Saver model)
    {
        _model = model;
        _model.Restore();
    }

    private Saver _model;

    private void OnDisable()
    {
        _model.Save();
    }
}