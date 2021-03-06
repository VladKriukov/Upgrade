﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int slotsx, slotsy;
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private ItemDatabase database;
    private bool showinventory=true;
    public static bool showShop = true;
    private bool showtooltip;
    private string tooltip;
    private bool draggingitem;
    private Item draggeditem;
    private int previndex;


    [SerializeField] Text openTip;
    [SerializeField] Canvas shopUI;
    [SerializeField] int paddingX;
    [SerializeField] int paddingY;


    private void Start()
    {
        for (int i = 0; i < (slotsx * slotsy); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            showinventory = !showinventory;
        }

        if (Input.GetButtonDown("Shop")&&showShop)
        {
            showShop = !showShop;
            LevelManager.LoadNextLevel();
        }
    }

    private void OnGUI()
    {
        /*if (GUI.Button(new Rect(40, 400, 100, 40), "save"))
        {
            saveinventory();
        }
        if (GUI.Button(new Rect(40, 450, 100, 40), "load"))
        {
            loadinventory();
        }
        if (GUI.Button(new Rect(40, 350, 100, 40), "Add"))
        {
            Additem(3);
        }*/
        tooltip = "";
        GUI.skin = skin;

        if (showinventory)
        {
            DrawInventory();
        }
        else
        {
            showtooltip = false;
            openTip.text = "open shop ( e )";
        }
        if (showtooltip)
        {
            GUI.Box(new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 260, 200), tooltip, skin.GetStyle("tooltip"));
        }
        if (draggingitem)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x-50, Event.current.mousePosition.y-50, 110, 110), draggeditem.itemIcon);
        }

        if (showShop)
        {
            shopUI.gameObject.SetActive(true);
            openTip.text = "close shop ( e )";
            showinventory = true;
            Debug.Log("Rendering Shop");
        }
        else
        {
            shopUI.gameObject.SetActive(false);
            showinventory = false;
            showShop = false;
            //Debug.Log("Hiding Shop");

        }
    }

    private void DrawInventory()
    {
        Event e = Event.current;
        int i = 0;

        for (int y = 0; y < slotsy; y++)
        {
            for (int x = 0; x < slotsx; x++)
            {
                Rect slotrect = new Rect((x * 120)+paddingX, (y * 120)+paddingY, 110, 110);
                GUI.Box(new Rect(slotrect), "", skin.GetStyle("slot"));
                slots[i] = inventory[i];
                Item item = slots[i];
                if (slots[i].itemname != null)
                {
                    GUI.DrawTexture(slotrect, slots[i].itemIcon);
                    if (slotrect.Contains(Event.current.mousePosition))
                    {
                        tooltip = createtooltip(slots[i]);
                        showtooltip = true;
                        if (e.button == 0 && e.type == EventType.MouseDrag && !draggingitem)
                        {
                            draggingitem = true;
                            previndex = i;
                            draggeditem = slots[i];
                            inventory[i] = new Item();
                        }

                        if (e.type == EventType.MouseUp && draggingitem)
                        {
                            inventory[previndex] = inventory[i];
                            inventory[i] = draggeditem;
                            draggingitem = false;
                            draggeditem = null;
                        }

                        if (Input.GetMouseButtonDown(1))
                        {
                            if (item.itemType == Item.ItemType.Consumable)
                            {
                                useconsumable(slots[i].itemname, i, true);
                            }
                        }
                    }
                }

                if (slotrect.Contains(Event.current.mousePosition))
                {
                    if (e.type == EventType.MouseUp && draggingitem)
                    {
                        inventory[i] = draggeditem;
                        draggingitem = false;
                        draggeditem = null;
                    }
                }

                if (tooltip == "")
                {
                    showtooltip = false;
                }

                i++;
            }
        }
    }

    private string createtooltip(Item item)
    {
        tooltip = item.itemname + "\n\n" + item.itemDesc;
        return tooltip;
    }

    private void removeitem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemID == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }

    public void Additem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemname == null)
            {
                for (int j = 0; j < database.items.Count; j++)
                {
                    if (database.items[j].itemID == id)
                    {
                        inventory[i] = database.items[j];
                    }
                }
                break;
            }
        }
    }

    private bool inventorycontains(int id)
    {
        bool result = false;
        for (int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemID == id;
            if (result)
            {
                break;
            }
        }
        return result;
    }

    private void useconsumable(string item, int slot, bool deleteitem)
    {
        Debug.Log("Item: " + item);
        Debug.Log("Slot: " + slot);

        switch (item)
        {
            case "Health Potion": //use the id to set the consumables
                {
                    break;
                }
            case "Backpack Upgrade":
                {
                    slotsy += 1;

                    for (int i = 0; i < (slotsx * slotsy); i++)
                    {
                        slots.Add(new Item());
                        inventory.Add(new Item());
                    }

                    break;
                }
        }

        if (deleteitem)
        {
            Debug.Log("Removing Item: " + slots[slot].itemname);
            inventory[slot] = new Item();
        }
    }

    private void saveinventory()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            PlayerPrefs.SetInt("inventory " + i, inventory[i].itemID);
        }
    }

    private void loadinventory()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i] = PlayerPrefs.GetInt("inventory " + i, -1) >= 0 ? database.items[PlayerPrefs.GetInt("inventory" + 1)] : new Item();
        }
    }
}