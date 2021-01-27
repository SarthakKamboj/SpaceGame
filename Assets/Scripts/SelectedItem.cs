using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedItem : MonoBehaviour, IPointerDownHandler
{
    public static bool itemClicked = false;
    public Image image;
    public SelectItemSO[] items;
    public SelectedVisuals selectedVisuals;
    [HideInInspector]
    public SelectItemSO item;
    ItemManager itemManager;

    void Start() {
        int randIdx = Random.Range(0, items.Length);
        item = items[randIdx];
        image.sprite = item.sprite;
        itemManager = transform.parent.GetComponent<ItemManager>();
    }

    public void OnPointerDown(PointerEventData data) {
        itemClicked = true;
        StartCoroutine(SetItemAsSelected());
        itemManager.DeselectAllItems();
        selectedVisuals.Selected();
    }

    public void ItemPlaced() {
        Destroy(gameObject);
    }

    IEnumerator SetItemAsSelected() {
        yield return new WaitForSeconds(2 * Time.fixedDeltaTime);
        GameObjectManager.itemSelected = this;
        itemClicked = false;
    }
}
