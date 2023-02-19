using UnityEngine;

public class CodeLock_Core : MonoBehaviour
{
    private CodeLock_Button[] _buttons;

    [SerializeField] private string setupCode;

    private void OnEnable()
    {
        _buttons = GetComponentsInChildren<CodeLock_Button>();
    }

    public void CheckCode()
    {
        string codeToCheck = "";
        foreach (var button in _buttons)
        {
            codeToCheck += button.ReturnNumber();
        }
        
        if(codeToCheck == setupCode)
            Debug.Log("OPEN!");
    }
}
