using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemcollect : MonoBehaviour
{
    [Header("TypeItem")]

    public typeUse tesure;

    [SerializeField] private Item item;
  
    public enum typeUse
    {
        Item,
        tesure
    }
    /// <summary>
    /// Si collisiona con el jugador y este tiene espacio destruye el objeto, si no el objeto no se destruye 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (tesure != typeUse.tesure)
            {
                bool Spawn = InventaryManager.Instance.addItem(item);

                if (Spawn)
                {
                    Destroy(gameObject);
                }
              
            }
        }
    }
    
}
