using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartAnimation : MonoBehaviour
{

    [SerializeField] private string triggerAnimationName;
    [SerializeField] private Animator animator;

    private void Start()
    {
        GetComponent<XRSocketInteractor>().selectEntered.AddListener(OnGrab);
    }
    public void OnGrab(SelectEnterEventArgs args)
    {    
        animator.SetTrigger(triggerAnimationName);     
    }
}
