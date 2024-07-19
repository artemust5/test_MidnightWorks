using UnityEngine;

public class ItemState : MonoBehaviour
{
    private bool isPurchased = false;
    private bool isSelected = false;
    private void SaveItemState()
    {
        PlayerPrefs.SetInt("IsPurchased", isPurchased ? 1 : 0);
        PlayerPrefs.SetInt("IsSelected", isSelected ? 1 : 0);
    }
    private void LoadItemState()
    {
        isPurchased = PlayerPrefs.GetInt("IsPurchased", 0) == 1;
        isSelected = PlayerPrefs.GetInt("IsSelected", 0) == 1;
    }
    public void SetPurchased(bool purchased)
    {
        isPurchased = purchased;
        SaveItemState();
    }
    public void SetSelected(bool selected)
    {
        isSelected = selected;
        SaveItemState();
    }
    public bool IsPurchased()
    {
        return isPurchased;
    }
    public bool IsSelected()
    {
        return isSelected;
    }

    private void Start()
    {
        LoadItemState();
    }
}
