using UnityEngine;
using UnityEngine.UI;

public class TotalCoins : MonoBehaviour
{
    [SerializeField] private Text totalCoins;
    private int currentTotalCoins;
    void Start()
    {
        FindTotalCoins();
    }
    void Update()
    {
        if (currentTotalCoins != PlayerPrefs.GetInt("TotalCoins", 0))
        {
            FindTotalCoins();
        }
    }
    private void FindTotalCoins()
    {
        totalCoins.text = PlayerPrefs.GetInt("TotalCoins", 0).ToString();
        currentTotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }
}
