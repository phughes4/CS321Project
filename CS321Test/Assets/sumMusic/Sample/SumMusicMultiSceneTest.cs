using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SumMusicMultiSceneTest : MonoBehaviour {

	IEnumerator Start () {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("ss2");
    }
}
