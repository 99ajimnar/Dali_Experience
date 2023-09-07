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


    public void OnGrab()
    {
        animator.SetTrigger(triggerAnimationName);
      
    }
}
