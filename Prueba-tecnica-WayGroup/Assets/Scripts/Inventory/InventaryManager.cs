using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject InventoryItemPrefab;

    public void addItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemSlot = slot.GetComponentInChildren<InventoryItem>();
            Debug.Log(itemSlot);
            if (itemSlot == null)
            {
                SpawnNewItem(item,slot);
                Debug.Log("se esta colocando item");
                return;
            }
        }
    }
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(InventoryItemPrefab,slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
