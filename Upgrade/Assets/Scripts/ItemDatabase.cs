using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Start()
    {
        items.Add(new Item("Dagger", 0, "A short blade", 5, 4, Item.ItemType.Weapon));
        items.Add(new Item("Axe", 1, "A simple wooden axe made for chopping wood", 7, 2, Item.ItemType.Weapon));
        items.Add(new Item("Potion", 2, "A potion that heals the wounds of battle", 0, 3, Item.ItemType.Consumable));
        items.Add(new Item("Bow", 3, "wooden arch held by a string ", 4, 2, Item.ItemType.Weapon));
    }

}
