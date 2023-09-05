using System.Collections.Generic;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public GameObject containerImage;
	//private Image receivingImage;
	private string _tag;
	//private Color normalColor;
	public Color highlightColor = Color.yellow;
	public GameObject imagenFondoPrefab;
	public GameObject imagenPrefab;
	public List<Sprite> addedSprites = new List<Sprite>();
	private Sprite dropSprite;
	public DragMe dimension;


    public void Awake()
    {
		containerImage = this.gameObject;
    }
    public void Update()
    {
		if (this.gameObject.transform.childCount > 0)
		{
			if (Input.GetKeyDown(KeyCode.Space))
				RemoveLastChildObject();

						
		}
	}
    public void OnDrop(PointerEventData data)
	{
        

        Vector2 localMousePosition;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(),Input.mousePosition, data.pressEventCamera, out localMousePosition);

		dropSprite = GetDropSprite(data); //Sacar la informacion del sprite recibido

		if (dropSprite != null)
		{
			Image newImage;
            if (_tag == "guardaAspecto")
            {
                GameObject newImageObject = Instantiate(imagenPrefab, GetComponentInParent<RectTransform>());
                newImage = newImageObject.GetComponent<Image>();
				
                newImage.preserveAspect = true;
                newImage.rectTransform.localPosition = localMousePosition;
				
                Debug.Log("sizeDelta.x DropMe" + newImage.rectTransform.sizeDelta.x);
                Debug.Log("sizeDelta.y DropMe" + newImage.rectTransform.sizeDelta.y);


            }
			else
			{
                GameObject newImageObject = Instantiate(imagenFondoPrefab, GetComponentInParent<RectTransform>());
                newImage = newImageObject.GetComponent<Image>();
            }
			
            newImage.sprite = dropSprite;
			
			Debug.Log(newImage.transform.position);
           

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
		
		Sprite dropSprite = GetDropSprite (data);
		//if (dropSprite != null)
		//	containerImage.color = highlightColor;
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		//containerImage.color = normalColor;
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
