using UnityEngine;
using System.Collections;

public class SumMusicButton : MonoBehaviour {

    SumMusic controller; // Link to controller

    /// <summary>Public accessor to toggle music from buttons</summary>
    public void ToggleMusic() {
        // Link object if we don't have it already
        if (controller == null) {
            // Find game object containing controller
            GameObject go = GameObject.Find("sumMusicController");
            // Log error and exit if the controller is missing
            if (go == null) {
                Debug.LogError("Required game object 'sumMusicController' is missing");
                return;
            }
            // Link component
            controller = go.GetComponent<SumMusic>();
        }
        controller.ToggleMusic(); // Call the ToggleMusic method on the controller
    }
}
