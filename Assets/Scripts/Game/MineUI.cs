using System;
using UnityEngine;

public class MineUI : MonoBehaviour
{
    public event EventHandler Clicked;

    [SerializeField]
    private GameObject _mineUI;

    public void Click()
    {
        Clicked.Invoke(this, EventArgs.Empty);
    }

    public void SetShow(bool show)
    {
        _mineUI.SetActive(show);
    }
}
