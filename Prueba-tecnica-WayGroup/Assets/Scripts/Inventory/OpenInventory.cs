using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    private bool InventoryIsOpen;

    [SerializeField] private GameObject Inventary;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            OpenMenu();
        }
    }
    private void OpenMenu()
    {
        if (!InventoryIsOpen)
        {
            Inventary.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            InventoryIsOpen = !InventoryIsOpen;
        }
        else
        {
            Inventary.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            InventoryIsOpen = !InventoryIsOpen;

        }
    }
}
