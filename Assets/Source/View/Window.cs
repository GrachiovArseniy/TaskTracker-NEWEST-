using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _blocker;

    public void Open()
    {
        _panel.SetActive(true);
        _blocker.SetActive(true);
    }

    public void Close()
    {
        _panel.SetActive(false);
        _blocker.SetActive(false);
    }
}
