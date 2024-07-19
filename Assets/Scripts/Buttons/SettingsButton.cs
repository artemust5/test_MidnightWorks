using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private GameObject muteButton;
    [SerializeField] private GameObject disableButton;

    private bool isClicked = false;

    void Start()
    {
        Button btn = settingsButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (isClicked)
        {
            muteButton.SetActive(false);
            disableButton.SetActive(false);
        }
        else
        {
            muteButton.SetActive(true);
            disableButton.SetActive(true);
        }

        isClicked = !isClicked;
    }
}