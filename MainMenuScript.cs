using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

	int i = 2;

	public void LoadbyIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}

	public void NextLevel(){
		SceneManager.LoadScene (i);
		i = i + 1;
	}

	public void ExitGame(){
		Application.Quit();
	}

}
	