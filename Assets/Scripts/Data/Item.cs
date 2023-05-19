using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//pelo proprio menu da unity posso criar um objeto do tipo Item que por sua vez é colocado no ItemInventory
[CreateAssetMenu(menuName = "Data/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public bool stackable;
    public Sprite icon;
}
