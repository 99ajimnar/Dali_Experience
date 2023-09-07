using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private GameObject baseControllerGameObject;
    [SerializeField] private GameObject teleportationGameObject;

    [SerializeField] private InputActionReference teleportActivationReference;

    [Space]
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;
    
    void Start()
    {
        teleportActivationReference.action.performed += TeleportModeActivate;
        teleportActivationReference.action.canceled += TeleportModeCancel;
    }

    //Called when the finger is out of the thumbstick
    private void TeleportModeCancel(InputAction.CallbackContext context) => Invoke("DeactivateTeleporter", .1f);

    //Call TeleportModeCancel after a certain amount of time
    void DeactivateTeleporter() => onTeleportCancel.Invoke();

    //Called when de thumbstick is moved up
    private void TeleportModeActivate(InputAction.CallbackContext context) => onTeleportActivate.Invoke();
   
}
