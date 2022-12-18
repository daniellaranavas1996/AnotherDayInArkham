using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler,IDropHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Zone begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Zone drag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("XAXAXA " + gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Zone end drag");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
