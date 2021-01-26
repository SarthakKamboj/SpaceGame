using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public LayerMask groundLayerMask;
    public GameObject prefab;

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

    PosAvailable GetPos() {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(camRay, out hit)) {
            if (hit.collider.tag == "Ground") {
                return new PosAvailable(hit.point);
            }
        }
        return new PosAvailable();
    }

    public void CreateObject() {
        PosAvailable posAvailable = GetPos();

        // GameObject newObj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        if (posAvailable.available) {
            GameObject newObj = Instantiate(prefab, posAvailable.pos, Quaternion.Euler(Vector3.up));
            // newObj.transform.position = pos;
            MoveObjY(ref newObj);
            // newObj.GetComponent<Move>().mouseDown = true;
        }
    }

    void MoveObjY(ref GameObject obj) {
        Vector3 objPos = obj.transform.position;
        objPos.y += obj.GetComponent<Renderer>().bounds.extents.y;
        obj.transform.position = objPos;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CreateObject();
            Debug.Log("clicked");
        }
    }
}
