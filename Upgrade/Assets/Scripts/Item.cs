using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item
{
    public string itemname;
    public int itemID;
    public string itemDesc;
    public Texture2D itemIcon;
    public int itemPower;
    public int itemSpeed;
    public ItemType itemType;

    public enum ItemType {
        Weapon,
        Consumable,
        Quest
    }

    public Item(string name,int id,string desc, int power,int speed,ItemType type)
    {
        itemname = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = Resources.Load<Texture2D>("Item Icon/" + name);
        itemPower = power;
        itemType = type;
    }
    public Item()
    {
        itemID = -1;
    }



}
