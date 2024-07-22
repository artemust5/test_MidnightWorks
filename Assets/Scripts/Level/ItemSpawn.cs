using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] prefabList;

    private void Start()
    {
        if (PlayerPrefs.GetInt("skinNum") == 0)
        {
            Instantiate(prefabList[0], transform.position, Quaternion.identity);
        }
        if (PlayerPrefs.GetInt("skinNum") == 1)
        {
            Instantiate(prefabList[1], transform.position, Quaternion.identity);
        }
    }
}
