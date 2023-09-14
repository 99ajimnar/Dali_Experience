using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowClockPosition : MonoBehaviour
{
    [SerializeField] private GameObject clueObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clueObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clueObject.SetActive(false);
        }
    }
}
