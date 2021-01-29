using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    bool paused = false;
    public void Pause() {
        Time.timeScale = 0f;
    }

    public void Resume() {
        Time.timeScale = 1f;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (paused) {
                Resume();
            } else {
                Pause();
            }
            paused = !paused;
        }
    }
}
