using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Start()
    {
        // Name, ID, Lore, Power, Speed, Item Type

        items.Add(new Item("Dagger", 0, "a short blade, useful for small enemies. \n\n Sell Price: 2$", 2, 2, Item.ItemType.Weapon));
        items.Add(new Item("Axe", 1, "a simple wooden axe, used for woodcutting. \n\n CANNOT SELL", 7, 2, Item.ItemType.Weapon));
        items.Add(new Item("Health Potion", 2, "a simple health potion, regenerates 50HP \n\n Sell Price: 2$", 0, 3, Item.ItemType.Consumable));
        items.Add(new Item("Bow", 3, "wooden arch held by a string ", 4, 2, Item.ItemType.Weapon));
        items.Add(new Item("Basic Backpack", 4, "a basic backpack \n\n CANNOT SELL", 0, 0, Item.ItemType.Consumable));
        items.Add(new Item("Upgraded Backpack", 5, "upgrades the backpack by 5 slots \n\n CANNOT SELL", 0, 0, Item.ItemType.Consumable));
        items.Add(new Item("Sword", 6, "a long sword, useful for bigger enemies. \n\n Sell Price: 5$", 4, 3, Item.ItemType.Weapon));
    }
}