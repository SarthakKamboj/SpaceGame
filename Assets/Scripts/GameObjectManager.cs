using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    [HideInInspector]
    public static SelectedItem itemSelected;

    class PosAvailable {
        public Vector3 pos;
        public bool available;

        public PosAvailable() {
            available = false;
        }

        public PosAvailable(Vector3 pos) {
            available = true;
            this.pos = pos;
        }
    }

    static PosAvailable GetPos() {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit)) {
            if (hit.collider.tag == "Ground") {
                return new PosAvailable(hit.point);
            }
        }
        return new PosAvailable();
    }

    static void CreateObject() {
        PosAvailable posAvailable = GetPos();

        if (posAvailable.available) {
            GameObject newObj = Instantiate(itemSelected.item.prefab, posAvailable.pos, Quaternion.Euler(Vector3.up));
            MoveObjY(ref newObj);
        }
    }

    static void MoveObjY(ref GameObject obj) {
        Vector3 objPos = obj.transform.position;
        objPos.y += obj.GetComponent<Renderer>().bounds.extents.y;
        obj.transform.position = objPos;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && itemSelected && !SelectedItem.itemClicked) {
            CreateObject();
            itemSelected.ItemPlaced();
            itemSelected = null;
        }
    }
}
