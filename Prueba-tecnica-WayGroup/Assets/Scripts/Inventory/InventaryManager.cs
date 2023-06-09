using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class InventaryManager : MonoBehaviour
{
    // si dectecta que preciono q y es una slot que tenga algo, voy al objeto y interactuo con el 
    public static InventaryManager Instance;

    public InventorySlot[] inventorySlots;
    public GameObject InventoryItemPrefab;

    [SerializeField] private int maxItemSlot;
    [SerializeField] private int SlotUi;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform dropPoint;

    private int SelectedSlot=-1;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        ChangeSlot();
        ActiveEffect();
        dropItem();
    }
    #region public fuctions
    /// <summary>
    /// Sistema para recivir el objeto y almacenarlo en las ranuras del los items
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool addItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemSlot = slot.GetComponentInChildren<InventoryItem>();

            if (itemSlot != null && itemSlot.item == item && maxItemSlot >= itemSlot.count)
            {
                itemSlot.count++;
                itemSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemSlot = slot.GetComponentInChildren<InventoryItem>();

            if (itemSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }
    #endregion

    #region Private fuctions
    /// <summary>
    /// sistema para cambiar entre los slot de la tecla 1-6 
    /// </summary>
    private void ChangeSlot()
    {
        if (Input.inputString != null)
        {
            int number;
            bool isNumber = int.TryParse(Input.inputString, out number);
            if (isNumber && number > 0 && number < SlotUi)
            {
                ChangeSelectedSlost(number - 1);
            }
        }
    }
    /// <summary>
    /// Activa el efecto del tipo que tenga health , speed 
    /// </summary>
    private void ActiveEffect()
    {
        if (SelectedSlot < 0)
        {
            return;
        }
        if ((Input.GetKeyDown(KeyCode.E)))
        {
            InventorySlot slot = inventorySlots[SelectedSlot];
            InventoryItem itemSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemSlot != null)
            {
               
                if (itemSlot.item.type == ItemType.Tesure)
                {
                    return;
                }
                itemSlot.count--;
                itemSlot.RefreshCount();
                itemSlot.EffectItem(player);
            }           
        }
    }
    /// <summary>
    /// Tira el item al frente 
    /// </summary>
    private void dropItem()
    {
        if (SelectedSlot < 0)
        {
            return;
        }
        if ((Input.GetKeyDown(KeyCode.Q)))
        {
            InventorySlot slot = inventorySlots[SelectedSlot];
            InventoryItem itemSlot = slot.GetComponentInChildren<InventoryItem>();

            if (itemSlot != null)
            {
                itemSlot.DropItem(dropPoint);
            }
        }
    }
    /// <summary>
    /// revisa si se puede cambiar el sloot y la deja selecionada 
    /// </summary>
    /// <param name="newValue"></param>
    private void ChangeSelectedSlost(int newValue)
    {
        if (SelectedSlot >= 0)
        {
            inventorySlots[SelectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        SelectedSlot = newValue;
    }
    
    /// <summary>
    /// crea en el inventario el proceso para a�adir item al inventario 
    /// </summary>
    /// <param name="item">el item que se va a guardad </param>
    /// <param name="slot">en el slot que se va a guardar </param>
    private void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(InventoryItemPrefab,slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    #endregion
}
