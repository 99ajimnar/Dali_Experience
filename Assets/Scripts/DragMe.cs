using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

[RequireComponent(typeof(Image))]
public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public bool dragOnSurfaces = true;
	private Dictionary<int,GameObject> draggingIcons = new Dictionary<int, GameObject>();
	private Dictionary<int, RectTransform> draggingPlanes = new Dictionary<int, RectTransform>();
	//public Vector2 dimensiones;
	

	void Start()
	{
		//GameObject im = GameObject.FindGameObjectWithTag("imagenCargada");
        
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		var canvas = FindInParents<Canvas>(gameObject);
		if (canvas == null)
			return;

		// We have clicked something that can be dragged.
		// What we want to do is create an icon for this.
		draggingIcons[eventData.pointerId] = new GameObject("icon");

		draggingIcons[eventData.pointerId].transform.SetParent (canvas.transform, false);
		draggingIcons[eventData.pointerId].transform.SetAsLastSibling();
		
		var image = draggingIcons[eventData.pointerId].AddComponent<Image>();
		// The icon will be under the cursor.
		// We want it to be ignored by the event system.
		var group = draggingIcons[eventData.pointerId].AddComponent<CanvasGroup>();
		group.blocksRaycasts = false;

		image.sprite = GetComponent<Image>().sprite;
		
		
		var rectTransform = GetComponent<RectTransform>();
		
		

		if (dragOnSurfaces)
			draggingPlanes[eventData.pointerId] = transform as RectTransform;
		else
			draggingPlanes[eventData.pointerId]  = canvas.transform as RectTransform;
		
		SetDraggedPosition(eventData);
        

    }

	public void OnDrag(PointerEventData eventData)
	{
		if (draggingIcons[eventData.pointerId] != null)
		{
			SetDraggedPosition(eventData);
		
        }
	}

	private void SetDraggedPosition(PointerEventData eventData)
	{
		if (dragOnSurfaces && eventData.pointerEnter != null && eventData.pointerEnter.transform as RectTransform != null)
			draggingPlanes[eventData.pointerId] = eventData.pointerEnter.transform as RectTransform;
		
		var rt = draggingIcons[eventData.pointerId].GetComponent<RectTransform>();
		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingPlanes[eventData.pointerId], eventData.position, eventData.pressEventCamera, out globalMousePos))
		{
			rt.position = globalMousePos;
			rt.rotation = draggingPlanes[eventData.pointerId].rotation;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		
		if (draggingIcons[eventData.pointerId] != null)
			Destroy(draggingIcons[eventData.pointerId]);

		draggingIcons[eventData.pointerId] = null;
	}

	static public T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null) return null;
		var comp = go.GetComponent<T>();

		if (comp != null)
			return comp;
		
		var t = go.transform.parent;
		while (t != null && comp == null)
		{
			comp = t.gameObject.GetComponent<T>();
			t = t.parent;
		}
		return comp;
	}
}
