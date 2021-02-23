using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject inv;
    [SerializeField] private int daggerCost;
    [SerializeField] private int swordCost;
    [SerializeField] private int healthPotionCost;
    [SerializeField] private int upgradeBackpackCost;
    private int playerBalance;

    private void Start()
    {
        playerBalance = 10; //GameManager.score;
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