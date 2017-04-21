using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

	public void LoadbyIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}

	public void ExitGame(){
		Application.Quit();
	}

}
	