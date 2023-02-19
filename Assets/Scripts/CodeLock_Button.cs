using System;
using TMPro;
using UnityEngine;

public class CodeLock_Button : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myNumberText;
    private int _myNumber;

    private void OnEnable()
    {
        UpdateView();
    }

    public int ReturnNumber()
    {
        return _myNumber;
    }

    private void UpdateView()
    {
        myNumberText.text = $"{_myNumber}";
    }

    public void UpScale()
    {
        _myNumber++;
        _myNumber %= 9;
        UpdateView();
    }

    public void DownScale()
    {
        if (_myNumber == 0)
        {
            _myNumber = 9;
        }
        else _myNumber--;
        UpdateView();
    }
}
