using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls UI Button and Audio Source for music player
/// (Requires AudioSource attached to game object)
/// </summary>
[HelpURL("https://jerrydenton.github.io/sumMusic/")]
[RequireComponent(typeof(AudioSource))]
public class SumMusic : MonoBehaviour {

    // Determine default state and whether to save
    public bool startOn = true, saveSettings = true, keepAlive = false;
    // Links to components
    public Sprite musicOnSprite, musicOffSprite;
    public Image image;

    // Current music status
    bool musicOn;

    /// <summary>Public accessor for current music status</summary>
    public bool MusicOn {
        get { return musicOn; }
    }

    void Start () {
        if (keepAlive)
            // Ensure object stays alive between scenes
            DontDestroyOnLoad(gameObject);

        // Set default state based on startOn or PlayerPrefs.
        if (saveSettings && PlayerPrefs.HasKey("sumMusicOn")) 
            musicOn = !(PlayerPrefs.GetInt("sumMusicOn") > 0);    // Convert from int to (flipped) bool
        else
            musicOn = !startOn; // Flip default before toggle

        ToggleMusic(true); // Use toggle to set initial state (w/o save)
    }

    /// <summary>
    /// Public accessor for toggling music from button of script
    /// </summary>
    public void ToggleMusic() {
        ToggleMusic(false);
    }

    /// <summary>
    /// Toggles music status, switches sprite, and saves if needed
    /// </summary>
    /// <param name="skipSave">
    /// Allows you to Toggle without saving regardless of saveSettings value
    /// </param>
    void ToggleMusic (bool skipSave) {

        // Check that sprites are linked properly
        if (!checkReqs()) {
            Debug.LogError("Link references missing on <b>sumMusic</b> object. Please check assignments in editor.");
            return;
        }

        // Flip value of musicOn
        musicOn = !musicOn;
        Debug.Log("Music status changed to " + musicOn);
        AudioSource src = GetComponent<AudioSource>();

        // Play or stop music
        if (musicOn)
            src.Play();
        else
            src.Stop();

        // Switch sprite to appropriate value
        if(image != null)
            image.sprite = musicOn ? musicOnSprite : musicOffSprite;

        // Save status to PlayerPrefs as int if needed (1=on,0=off)
        if (saveSettings && !skipSave) {
            Debug.Log("Saving sound settings");
            PlayerPrefs.SetInt("sumMusicOn", musicOn ? 1 : 0);
        }
    }
	
    /// <summary>Checks to make sure necessary objects are assigned</summary>
    /// <returns>True or False</returns>
    bool checkReqs () {
        return (musicOnSprite != null && musicOffSprite != null && image != null);
    }
}
