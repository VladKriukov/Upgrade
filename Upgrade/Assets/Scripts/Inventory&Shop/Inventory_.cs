using System.Collections.Generic;
using UnityEngine;

public class _Inventory : MonoBehaviour
{
    public List<GameObject> inventorylist = new List<GameObject>();
    public List<GameObject> itemlist = new List<GameObject>();

    private void Start()
    {
        inventorylist[0].name = "ItemSlot1";
        inventorylist[1].name = "ItemSlot2";
        inventorylist[2].name = "ItemSlot3";
        inventorylist[3].name = "ItemSlot4";
        inventorylist[4].name = "ItemSlot5";
        inventorylist[5].name = "ItemSlot6";
        inventorylist[6].name = "ItemSlot7";
        inventorylist[7].name = "ItemSlot8";
    }

    public void remove()
    {

    }
}