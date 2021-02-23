using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Start()
    {
        // Name, ID, Lore, Power, Speed, Item Type

        items.Add(new Item("Dagger", 0, "A short blade", 2, 2, Item.ItemType.Weapon));
        items.Add(new Item("Axe", 1, "A simple wooden axe made for chopping wood", 7, 2, Item.ItemType.Weapon));
        items.Add(new Item("Health Potion", 2, "A simple health potion, regenerating 50HP", 0, 3, Item.ItemType.Consumable));
        items.Add(new Item("Bow", 3, "wooden arch held by a string ", 4, 2, Item.ItemType.Weapon));
        items.Add(new Item("Basic Backpack", 4, "Basic backpack ", 0, 0, Item.ItemType.Consumable));
        items.Add(new Item("Upgraded Backpack", 5, "Upgraded backpack ", 0, 0, Item.ItemType.Consumable));
        items.Add(new Item("Sword", 6, "a long sword", 4, 3, Item.ItemType.Weapon));
    }

}
