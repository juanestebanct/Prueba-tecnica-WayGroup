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

    #region public fuctions
    /// <summary>
    /// Inicializa el item en el inventario 
    /// </summary>
    /// <param name="newItem">el item </param>
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
    /// <summary>
    /// refresca el contador de items 
    /// </summary>
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
    public void DropItem(Transform PointSpawn)
    {
       SpawnObject(PointSpawn);
        Destroy (gameObject);
    }

    /// <summary>
    /// Se ve que tipo es para que ejecute un efecto 
    /// </summary>
    /// <param name="player">el player para aplicar los efectos</param>
    public void EffectItem(GameObject player)
    {
        switch (item.type)
        {
            case ItemType.Health:
                item.HealPlayer(player);
                break;
            case ItemType.Speed:
                item.SpeedPlayer(player);
                break;
            case ItemType.Tesure:
                break;

        }
    }
    #endregion

    #region End fuctions
    /// <summary>
    /// Para spawnear el objeto que se va a soltar 
    /// </summary>
    /// <param name="PointSpawn">punto para spawnear</param>
    private void SpawnObject(Transform PointSpawn)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(item.Prefab, PointSpawn.position, Quaternion.identity);
        }
    }
    #endregion

}
