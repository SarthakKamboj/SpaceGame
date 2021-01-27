using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedVisuals : MonoBehaviour
{
    [SerializeField]
    float selectedScale = 1.3f;
    public RectTransform rectTransform;
    Vector3 origScale;

    void Start() {
        origScale = rectTransform.localScale;
    }

    public void Selected() {
        rectTransform.localScale = origScale * selectedScale;
    }

    public void Deselected() {
        rectTransform.localScale = origScale;
    }
}
