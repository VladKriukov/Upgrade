using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Start()
    {
        items.Add(new Item("dagger", 0, "a short blade", 5, 4, Item.ItemType.Weapon));
        items.Add(new Item("mace", 1, "a blunt ball on a rod of wood", 7, 2, Item.ItemType.Weapon));
    }

}
