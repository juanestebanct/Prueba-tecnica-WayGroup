using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject Mensaje;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grabbed"))
        {
            Itemcollect item = other.GetComponent<Itemcollect>();
            if (item != null)
            {
                OpenDoorAndDestroy();
                Destroy(other.gameObject);
                Destroy(Mensaje);
            }
        }
    }
    private void OpenDoorAndDestroy()
    {
        Door.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
