using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToSwitch;
    [SerializeField] private SceneTransition _sceneTransition;
    [SerializeField] private Text levelText;
    private int currentIndex = 0;

    private void Start()
    {
        SwitchObject(currentIndex);
    }

    public void NextObject()
    {
        currentIndex = (currentIndex + 1) % objectsToSwitch.Length;
        SwitchObject(currentIndex);
    }

    public void PreviousObject()
    {
        currentIndex = (currentIndex - 1 + objectsToSwitch.Length) % objectsToSwitch.Length;
        SwitchObject(currentIndex);
    }

    private void SwitchObject(int index)
    {
        foreach (var obj in objectsToSwitch)
        {
            obj.SetActive(false);
        }
        objectsToSwitch[index].SetActive(true);

        if (_sceneTransition != null)
        {
            _sceneTransition.sceneNumber = index;
        }
        levelText.text = "LEVEL " + (index+1).ToString("F0");
    }
}