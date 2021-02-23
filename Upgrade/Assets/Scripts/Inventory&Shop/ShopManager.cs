using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject inv;
    [SerializeField] int daggerCost;
    [SerializeField] int swordCost;
    [SerializeField] int healthPotionCost;
    [SerializeField] int upgradeBackpackCost;
    int playerBalance;

    void Start()
    {
        playerBalance = 10; //GameManager.score;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void BuyDagger()
    {
        if (playerBalance >= daggerCost)
        {
            inv.GetComponent<Inventory>().Additem(0);
            playerBalance -= daggerCost;
        }
    }

    public void BuySword()
    {
        if (playerBalance >= swordCost)
        {
            inv.GetComponent<Inventory>().Additem(6);
            playerBalance -= swordCost;
        }
    }

    public void GiveHealthPotion()
    {
        if (playerBalance >= healthPotionCost)
        {
            inv.GetComponent<Inventory>().Additem(2);
            playerBalance -= healthPotionCost;
        }
    }

    public void UpgradeBackpack()
    {

    }
}
