using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLevel : MonoBehaviour
{
    [Header("Ui Mensaje")]

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject pointToViw;

    private bool win;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           if(!win) ActivePanel();
            
        }
    }
    private void ActivePanel()
    {
        win = true;
        winPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pointToViw.SetActive(false);
    }
}
