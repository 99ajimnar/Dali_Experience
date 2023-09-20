using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionSwitch : MonoBehaviour
{
    public GameObject xrJulia;
    public GameObject xrAlvaro;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            xrJulia.SetActive(false);   
            xrAlvaro.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            xrAlvaro.SetActive(false);
            xrJulia.SetActive(true);
          
        }
    }
}
