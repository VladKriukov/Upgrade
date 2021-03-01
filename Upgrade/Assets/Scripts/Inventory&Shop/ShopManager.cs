using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject inv;
    [SerializeField] int daggerCost;
    [SerializeField] int swordCost;
    [SerializeField] int healthPotionCost;
    [SerializeField] int upgradeBackpackCost;
    [SerializeField] Text currentBalance;
    private int playerBalance;

    private void Start()
    {
       
        playerBalance = 20; //GameManager.score;
        currentBalance.text = playerBalance.ToString();
    }

    public void BuyDagger()
    {
        if (playerBalance >= daggerCost)
        {
            inv.GetComponent<Inventory>().Additem(0);
            playerBalance -= daggerCost;
        }
        currentBalance.text = playerBalance.ToString();
    }
    
    public void BuySword()
    {
        if (playerBalance >= swordCost)
        {
            inv.GetComponent<Inventory>().Additem(6);
            playerBalance -= swordCost;
        }
        currentBalance.text = playerBalance.ToString();
    }

    public void GiveHealthPotion()
    {
        if (playerBalance >= healthPotionCost)
        {
            inv.GetComponent<Inventory>().Additem(2);
            playerBalance -= healthPotionCost;
        }
        currentBalance.text = playerBalance.ToString();
    }

    public void UpgradeBackpack()
    {
        if (playerBalance >= upgradeBackpackCost)
        {
            inv.GetComponent<Inventory>().Additem(5);
            playerBalance -= upgradeBackpackCost;
        }
        currentBalance.text = playerBalance.ToString();
    }
}