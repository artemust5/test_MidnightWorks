using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private int totalCoins;
    public int skinNum;
    public Button buyButton;
    public Image iLock; 
    public int price;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;
    public Sprite falseLock;
    public Sprite trueLock;

    public GameObject[] skins;

    private void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        if (PlayerPrefs.GetInt("skin1" + "buy") == 0)
        {
            foreach (GameObject skin in skins)
            {
                if ("skin1" == skin.name)
                {
                    PlayerPrefs.SetInt("skin1" + "buy", 1);
                    PlayerPrefs.SetInt("skin1" + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(skin.name + "buy", 0);
                }
            }
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt(gameObject.name + "buy") == 0) 
        {
            iLock.GetComponent<Image>().sprite = falseLock;
            buyButton.GetComponent<Image>().sprite = buySkin;
        }
        else if (PlayerPrefs.GetInt(gameObject.name + "buy") == 1) 
        {
            iLock.GetComponent<Image>().sprite = trueLock;
            if (PlayerPrefs.GetInt(gameObject.name + "equip") == 1) 
            {
                buyButton.GetComponent<Image>().sprite = equipped;
            }
            else if (PlayerPrefs.GetInt(gameObject.name + "equip") == 0)
            {
                buyButton.GetComponent<Image>().sprite = equip;
            }
        }
    }

    public void Buy()
    {
        if (PlayerPrefs.GetInt(gameObject.name + "buy") == 0)
        {
            if (totalCoins >= price)
            {
                iLock.GetComponent<Image>().sprite = trueLock;
                buyButton.GetComponent<Image>().sprite = equipped;
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
                PlayerPrefs.SetInt(gameObject.name + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);

                foreach (GameObject skin in skins)
                {
                    if (gameObject.name == skin.name) 
                    {
                        PlayerPrefs.SetInt(gameObject.name + "equip", 1); 
                    }
                    else
                    {
                        PlayerPrefs.SetInt(skin.name + "equip", 0);
                    }
                }
            }
        }
        else if (PlayerPrefs.GetInt(gameObject.name + "buy") == 1)
        {
            iLock.GetComponent<Image>().sprite = trueLock;
            buyButton.GetComponent<Image>().sprite = equipped;
            PlayerPrefs.SetInt(gameObject.name + "equip", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);

            foreach (GameObject skin in skins)
            {
                if (gameObject.name == skin.name)
                {
                    PlayerPrefs.SetInt(gameObject.name + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(skin.name + "equip", 0);
                }
            }
        }
    }
}
