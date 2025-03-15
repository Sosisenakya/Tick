using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    void Update() {
        if (Input.GetKeyDown(KeyCode.T) && !ClockMv.Instance.isStopCooldown) {
            ToggleTime();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            ButtonManager.Instance.ShowInventoryGUI();
        }
    }
    public void ToggleTime() {
        ClockMv.Instance.ToggleTime();
        ClockMv.Instance.StartCoroutine(ClockMv.Instance.StopEffect());
        ClockMv.Instance.IncrementTotalTimestop();
    }
}