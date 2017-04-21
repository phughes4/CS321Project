using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public int i = 2;

	public void LoadbyIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}

	public void NextLevel(){
		i = i + 1;
		SceneManager.LoadScene (i);
	}

	public void Resetter(){
		SceneManager.LoadScene (i);
	}

	public void ExitGame(){
		Application.Quit();
	}

}
