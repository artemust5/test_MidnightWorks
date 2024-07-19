using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float totalTime = 120.0f; 
    private float currentTime;
    [SerializeField] private GameObject pinup;
    [SerializeField] private GameObject joystick;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private CarController _ñarController;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (currentTime >= 1)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            _ñarController.speed = 0;
            pinup.SetActive(true);
            joystick.SetActive(false);
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }
}
