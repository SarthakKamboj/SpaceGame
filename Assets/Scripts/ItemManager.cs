using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private int spawnPoints = 6;
    public GameObject imagePrefab;
    public RectTransform rectTransform;
    SelectedVisuals[] selectedVisuals;
    public float minWaitTimeBeforeSpawning = 5f, maxWaitTimeBeforeSpawning = 10f;
    float waitTimeBeforeSpawning;
    float timeSinceLastSpawn = 0f;

    void Start() {
        for (int i = 0; i < spawnPoints; i++) {
            AddItem();
        }
        SetWaitTime();
        GatherSelectedVisuals();
    }

    void GatherSelectedVisuals() {
        selectedVisuals = GetComponentsInChildren<SelectedVisuals>();
    }

    void SetWaitTime() {
        waitTimeBeforeSpawning = Random.Range(minWaitTimeBeforeSpawning, maxWaitTimeBeforeSpawning);
    }

    public void AddItem() {
        GameObject item = Instantiate(imagePrefab);
        item.transform.SetParent(rectTransform, false);
    }

    void Update() {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > waitTimeBeforeSpawning) {
            timeSinceLastSpawn = 0f;
            if (selectedVisuals.Length < spawnPoints) {
                AddItem();
                GatherSelectedVisuals();
            }
            SetWaitTime();
        }
    }

    public void DeselectAllItems() {
        selectedVisuals = GetComponentsInChildren<SelectedVisuals>();
        foreach(SelectedVisuals selectedVisual in selectedVisuals) {
            if (selectedVisual) {
                selectedVisual.Deselected();
            }
        }
    }

}
