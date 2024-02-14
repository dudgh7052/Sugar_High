using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 Movement { get; private set; }

    private Controls m_controls;

    void Start()
    {
        m_controls = new Controls();
        m_controls.Player.AddCallbacks(this);
        m_controls.Enable();
    }

    void OnDestroy()
    {
        m_controls.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
    }
}
