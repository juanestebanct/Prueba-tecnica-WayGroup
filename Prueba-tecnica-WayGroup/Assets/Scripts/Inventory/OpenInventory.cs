using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    [Header("Inventari open")]

    [SerializeField] private GameObject Inventary;
    [SerializeField] private GameObject PointToViw;

    private bool InventoryIsOpen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            OpenMenu();
        }
    }
    #region Private Funtions 
    /// <summary>
    /// Habre y cierra el menu
    /// </summary>
    private void OpenMenu()
    {
        if (!InventoryIsOpen)
        {
            Inventary.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            InventoryIsOpen = !InventoryIsOpen;
            PointToViw.SetActive(false);
        }
        else
        {
            Inventary.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            InventoryIsOpen = !InventoryIsOpen;
            PointToViw.SetActive(true);

        }
    }
    #endregion
}
