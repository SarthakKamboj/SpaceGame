using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private int spawnPoints = 6;
    public GameObject image;
    public RectTransform rectTransform;
    void Start() {
        for (int i = 0; i < spawnPoints; i++) {
            AddItem();
        }
    }

    public void AddItem() {
        GameObject item = Instantiate(image);
        item.transform.SetParent(rectTransform, false);
    }

}
