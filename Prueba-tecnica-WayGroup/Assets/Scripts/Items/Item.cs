using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Scriptable objecct/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public ItemType type;
    public GameObject _Item;
    public Sprite Image;

    [Header("Tesure")]
    public float Points;

    [Header("Health")]
    public float healt;

    [Header("Speed")]
    public float Speed;

    public enum ItemType
    {
        Health,
        Tesure,
        Speed
    }
    /// <summary>
    /// Dependiendo del tipo se activa, añadir la vida al player, speed o calcula el tesoro 
    /// </summary>
    /// <param name="player"></param>
    public void AplicateEfect(GameObject player)
    {
        switch (type)
        {
            case ItemType.Health:
                break;
            case ItemType.Speed:
                break;
            case ItemType.Tesure:
                break;

        }
    }
}
