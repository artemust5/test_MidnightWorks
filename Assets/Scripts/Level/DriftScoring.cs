using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DriftScoring : MonoBehaviour
{
    [SerializeField] private float driftScoreMultiplier = 100.0f;
    [SerializeField] private CarController _ñarController;
    private float currentDriftAngle = 0.0f;
    [HideInInspector] public float totalDriftScore = 0.0f;

    public TextMeshProUGUI driftScoreText;
    void Update()
    {
        currentDriftAngle += _ñarController.steerInput * Time.deltaTime;
        foreach (var wheel in _ñarController.wheels)
        {
            if (wheel.wheelCollider.isGrounded == true && _ñarController.carRb.velocity.magnitude >= 15.0f)
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
