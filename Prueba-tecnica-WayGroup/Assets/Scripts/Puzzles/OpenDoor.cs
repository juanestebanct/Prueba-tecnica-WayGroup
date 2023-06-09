using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grabbed"))
        {
            Itemcollect item = other.GetComponent<Itemcollect>();
            if (item != null)
            {
                Debug.Log("Funciona");
            }
            else
            {
                Debug.Log("es nulo");
            }
        }
    }
}
