using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotation = 90f;

    void Update() {
        GameObject go = SelectedObject.SelectedGO;

        if (go && go == gameObject) {
            if (Input.GetKeyDown(KeyCode.R)) {
                if (Input.GetKey(KeyCode.LeftControl)) {
                    SelectedObject.SelectedGO.transform.rotation = Quaternion.Euler(new Vector3(0f,-rotation,0f)) * transform.rotation;
                } else {
                    SelectedObject.SelectedGO.transform.rotation = Quaternion.Euler(new Vector3(0f,rotation,0f)) * transform.rotation;
                }
            }
        }
    }
}
