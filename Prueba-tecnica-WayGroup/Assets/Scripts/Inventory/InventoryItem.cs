using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using static Item;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler,IDragHandler
{
    
    [Header("Ui")]
    public Image image;
    public TextMeshProUGUI CountText;
    public int count = 0;
    public Item item;

    [HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem)
    {
        count++;
        item = newItem;
        image.sprite = item.Image;
        RefreshCount();
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

    public void RefreshCount()
    {
        CountText.text = count.ToString();
        switch (count)
        {
            case 0:
                Destroy(gameObject);
                break;
            case 1:
                CountText.gameObject.SetActive(false);
                break;
            case 2:
                CountText.gameObject.SetActive(true);
                break;
        }
    }
    public void DropItem()
    {
        Destroy (gameObject);
    }
    public void EffectItem(GameObject player)
    {
        switch (item.type)
        {
            case ItemType.Health:
                Debug.Log("cura");
                break;
            case ItemType.Speed:
                Debug.Log("Aumenta la velocidad");
                break;
            case ItemType.Tesure:
                Debug.Log("Te hace rico");
                break;

        }
    }

}
