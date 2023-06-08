using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemcollect : MonoBehaviour
{
    public InventaryManager inventaryManager;
    public Item item;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aquí puedes agregar la lógica que deseas ejecutar cuando el objeto colisiona con el jugador
            Debug.Log("¡El objeto colisionó con el jugador!");
            inventaryManager.addItem(item);
        }
    }
}
