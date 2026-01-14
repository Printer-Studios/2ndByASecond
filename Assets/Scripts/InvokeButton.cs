using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InvokeButton : MonoBehaviour
{
    public Button buttonToClick;
    public InputActionReference actionReference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (buttonToClick == null && gameObject.GetComponent<Button>() != null)
        {
            buttonToClick = gameObject.GetComponent<Button>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (actionReference.action.WasPressedThisFrame())
        {
            buttonToClick.onClick.Invoke();
        }
    }
}
