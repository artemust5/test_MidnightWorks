using UnityEngine;

public class CoinDoubler : MonoBehaviour
{
    public void DoubleAndSaveCoins()
    {
        int currentCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        int doubledCoins = currentCoins * 2;
        PlayerPrefs.SetInt("TotalCoins", doubledCoins);
    }
}
