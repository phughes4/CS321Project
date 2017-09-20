using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <remarks>
/// Since the controller may have been loaded in another scene this 
/// script will link this image component to the sumMusicController 
/// object and ensure the the proper image sprite is set.
/// </remarks>
[RequireComponent(typeof(Image))]
public class SumMusicButtonImage : MonoBehaviour {

    SumMusic controller;

    public void OnEnable() {
        // Link controller if we don't have it already
        if (controller == null) {
            GameObject go = GameObject.Find("sumMusicController");
            // Log error and exit if the controller is missing
            if (go == null) {
                Debug.LogError("Required game object 'sumMusicController' is missing");
                return;
            }
            // Link controller
            controller = go.GetComponent<SumMusic>();
        }
        controller.image = GetComponent<Image>(); // Link this game object's image to the controller
        // Set appropriate sprite
        controller.image.sprite = controller.MusicOn ? controller.musicOnSprite : controller.musicOffSprite;
    }

}
