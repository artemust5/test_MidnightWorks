using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private DriftScoring _driftScoring;
    [HideInInspector] public int totalCoins;
    private float lastDriftScore = 0.0f;
    private void Start()
    {
        lastDriftScore = _driftScoring.totalDriftScore;
    }
    void Update()
    {
        float driftScore = _driftScoring.totalDriftScore;
        if (driftScore != lastDriftScore)
        {
            int coinsEarned = Mathf.FloorToInt((driftScore - lastDriftScore) / 5);
            AddCoinsToPlayerPrefs(coinsEarned);
            lastDriftScore = driftScore;
        }
    }
    public void AddCoinsToPlayerPrefs(int amount)
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoins += amount; 
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }
    public int GetTotalCoins()
    {
        return PlayerPrefs.GetInt("TotalCoins", 0);
    }
    public void SpendCoins(int amount)
    {
        int totalCoins = GetTotalCoins();
        if (totalCoins >= amount)
        {
            totalCoins -= amount;
            PlayerPrefs.SetInt("TotalCoins", totalCoins);  
        }
        else
        {
            Debug.LogWarning("Недостатньо монет!");
        }
    }
}
