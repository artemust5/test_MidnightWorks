using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private int totalCoins;

    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }

    public bool BuyItem(int itemPrice)
    {
        if (totalCoins >= itemPrice)
        {
            totalCoins -= itemPrice;

            PlayerPrefs.SetInt("TotalCoins", totalCoins);

            return true;
        }
        else
        {
            return false; 
        }
    }
}
