using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemcollect : MonoBehaviour
{
    public Item item;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aqu� puedes agregar la l�gica que deseas ejecutar cuando el objeto colisiona con el jugador
            Debug.Log("�El objeto colision� con el jugador!");
            bool Spawn = InventaryManager.Instance.addItem(item);

            Destroy(gameObject);
        }
    }
}