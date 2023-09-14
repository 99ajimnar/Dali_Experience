using System.Collections.Generic;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	private GameObject containerImage;
	
	private string _tag;
	public GameObject imagenFondoPrefab;
	public GameObject imagenPrefab;
	private List<Sprite> addedSprites = new List<Sprite>();
	private Sprite dropSprite;
	

    public void Awake()
    {
		containerImage = this.gameObject;
    }


    public void Update()
    {
		
	if (Input.GetKeyDown(KeyCode.Space))
		RemoveLastChildObject();


    }

    public void OnDrop(PointerEventData data)
    {
        Debug.Log("OnDrop");

        Vector2 localRayPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), data.position, data.pressEventCamera, out localRayPosition);

        dropSprite = GetDropSprite(data); //Sacar la informacion del sprite recibido

        if (dropSprite != null)
        {
            Image newImage;
            if (_tag == "guardaAspecto")
            {
                GameObject newImageObject = Instantiate(imagenPrefab, GetComponentInParent<RectTransform>());
                newImage = newImageObject.GetComponent<Image>();

                newImage.preserveAspect = true;
                newImage.rectTransform.localPosition = localRayPosition;
            }
            else
            {
                GameObject newImageObject = Instantiate(imagenFondoPrefab, GetComponentInParent<RectTransform>());
                newImage = newImageObject.GetComponent<Image>();
            }

            newImage.sprite = dropSprite;
            addedSprites.Add(dropSprite);
            //receivingImage.sprite = dropSprite;

        }
    }

    public void RemoveLastChildObject()
    {
       
        if (this.gameObject.transform.childCount > 0)
        {
            Transform lastChild = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1);
            Destroy(lastChild.gameObject);
        }
    }


    public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;

    }

	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;
		
		var dragMe = originalObj.GetComponent<DragMe>();
		if (dragMe == null)
			return null;
		
		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;
		_tag = originalObj.transform.tag;
		return srcImage.sprite;
	}



}
