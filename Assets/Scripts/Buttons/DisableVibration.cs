using UnityEngine;
using UnityEngine.UI;

public class DisableVibration : MonoBehaviour
{
    [SerializeField] private Button disableButton;

    void Start()
    {
        Button btn = disableButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Handheld.Vibrate();
    }
}