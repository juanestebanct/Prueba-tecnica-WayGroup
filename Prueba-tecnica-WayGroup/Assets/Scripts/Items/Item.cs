using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Scriptable objecct/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public ItemType type;
    public GameObject Prefab;
    public Sprite Image;

    [Header("Tesure")]
    public float Points;

    [Header("Health")]
    public float Healt;

    [Header("speed")]
    public float Speed;

    public enum ItemType
    {
        Health,
        Tesure,
        Speed
    }
    public void HealPlayer(GameObject player)
    {
        player.GetComponent<PlayerStats>().ResiveHealt(Healt);
        Debug.Log("se aplico curacion de " +Healt);
    }
    public void SpeedPlayer(GameObject player)
    {
        player.GetComponent<PlayerStats>().ChangeSpeed(Speed);
    }
}
