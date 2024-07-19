using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DriftScoring : MonoBehaviour
{
    [SerializeField] private float driftScoreMultiplier = 100.0f;
    [SerializeField] private CarController _�arController;
    private float currentDriftAngle = 0.0f;
    [HideInInspector] public float totalDriftScore = 0.0f;

    public TextMeshProUGUI driftScoreText;
    void Update()
    {
        currentDriftAngle += _�arController.steerInput * Time.deltaTime;
        foreach (var wheel in _�arController.wheels)
        {
            if (wheel.wheelCollider.isGrounded == true && _�arController.carRb.velocity.magnitude >= 15.0f)
            {
                float driftScore = Mathf.Abs(currentDriftAngle) * driftScoreMultiplier;
                totalDriftScore += driftScore;
                driftScoreText.text = "Score: " + totalDriftScore.ToString("F0");
            }
            else
            {
                currentDriftAngle = 0.0f;
            }
        }
    }
}
