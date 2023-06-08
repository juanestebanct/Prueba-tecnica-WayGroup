
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler,IDragHandler
{
    [Header("Ui")]
    public Image image;
    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem)
    {
        image.sprite = newItem.Image;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag=transform.parent; 
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position=Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      image.raycastTarget = true;
      transform.SetParent(parentAfterDrag);
    }

}
