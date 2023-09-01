using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class posicionCuadro : MonoBehaviour
{
    public Vector3 initialPosition;
    public bool moved;

    public Canvas targetCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        moved = false;
        initialPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!moved && transform.position != initialPosition)
        {
            moved = true;
            GameObject Elefante1 = GameObject.Instantiate(this.gameObject, initialPosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision");

        if (collision.gameObject.CompareTag("canvasNuevo"))
        {
            // Obtén la imagen que deseas mover
            RawImage imagenA = collision.gameObject.GetComponentInChildren<RawImage>();

            // Cambia el padre de la imagen al panel en el otro canvas
            if (imagenA != null)
            {
                imagenA.transform.SetParent(targetCanvas.transform, false);
            }
        }
    }



}
