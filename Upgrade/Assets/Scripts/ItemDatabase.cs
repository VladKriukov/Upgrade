using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Start()
    {
        items.Add(new Item("Dagger", 0, "A short blade", 5, 4, Item.ItemType.Weapon));
        items.Add(new Item("Mace", 1, "A blunt ball on a rod of wood", 7, 2, Item.ItemType.Weapon));
        items.Add(new Item("Potion", 2, "A potion that heals the wounds of battle", 0, 3, Item.ItemType.Consumable));
    }

}
