using UnityEngine;
using UnityEngine.InputSystem;
using static WSTInput;

[CreateAssetMenu(fileName = "InputReaderSO", menuName = "Scriptable Objects/InputReaderSO")]
public class InputReaderSO : ScriptableObject, IMouseActions
{
    private WSTInput inputs;
    public Vector2 mousePos { get; private set; }
    public LayerMask layerMask;

    private bool canRotate;

    private void OnEnable()
    {
        if(inputs == null)
        {
            inputs = new WSTInput();
        }

        inputs.Mouse.SetCallbacks(this);
        inputs.Mouse.Enable();
    }

    private void OnDisable()
    {
        inputs.Mouse.Disable();
    }
    public void OnAim(InputAction.CallbackContext context)
    {
        if(canRotate)
        mousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void OnCanRotate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            canRotate = true;
        }
        if (context.canceled)
        {
            canRotate = false;
        }
    }
}
