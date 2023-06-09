using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour,IDropHandler
{
    [Header("Decoration Slot")]

    public Image image;
    public Color SelectColor, notSelectedColor;

    private void Awake()
    {
        Deselect();
    }
    #region Public fuctions
    public void Select()
    {
        image.color = SelectColor;
    }
    public void Deselect()
    {
        image.color = notSelectedColor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount==0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
    #endregion
}
