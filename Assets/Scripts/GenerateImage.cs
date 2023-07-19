using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateImage : MonoBehaviour
{
    public Texture2D photoPrefab;
    public Canvas canvas;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Vector2 clickPosition = Input.mousePosition;
            generateImage(clickPosition);
        }
    }

    void generateImage(Vector2 clickPosition)
    {
        RectTransform canvasRecTransform = canvas.GetComponent<RectTransform>(); //Controla la posicion, rotacion y escala de un objeto bidimensional
        
        /* 
        Debemos pasar la posicion dónde se ha hecho click a la posición local del canvas. 
        Para ello se utiliza la siguiente funcion
         */
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRecTransform, //Es el rectangulo de transformacion del canvas al que se desea convertir la posición.
            clickPosition, //Posición de la pantalla que se intenta convertir.
            null, //Plano de referencia, se pone null porque se v a utilizar el plano del canvas.
            out Vector2 localPosition); //Es el parámetro de salida. Aqui se almacenará la posicion convertida.

        Texture2D newTexture = Instantiate(photoPrefab);
        newTexture.wrapMode = TextureWrapMode.Clamp;
        newTexture.Apply();

        GameObject textureGameObject = new GameObject("GeneratedTexture");
        RawImage rawImage = textureGameObject.AddComponent<RawImage>();
        rawImage.texture = newTexture;
        rawImage.rectTransform.SetParent(canvas.transform, false);
        rawImage.rectTransform.localPosition = localPosition;

    }

    public void setImage(Texture2D photo)
    {
        photoPrefab = photo;
    }
}
