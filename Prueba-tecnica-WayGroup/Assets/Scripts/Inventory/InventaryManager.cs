using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                itemSlot.count--;
                itemSlot.RefreshCount();
                itemSlot.EffectItem(player);
            }           
        }
    }
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
                Debug.Log("se tira objeto");
            }
        }
    }

    private void ChangeSelectedSlost(int newValue)
    {
        if (SelectedSlot >= 0)
        {
            inventorySlots[SelectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        SelectedSlot = newValue;
    }
    
    private void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(InventoryItemPrefab,slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
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
                Debug.Log("aumenta el objeto");
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
                Debug.Log("se esta colocando item");
                return true;
            }
        }
        return false;
    }
}
