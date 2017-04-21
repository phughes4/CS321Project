﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour {

    //Boardmanager acts like a repository, it keeps track of information while other programs are workhorses.
    public int sceneName = 0;//This should let us change it in the Unity Browser.
    public bool goalRed = false;//public only to mess with it in scene editor.
    public bool goalBlue = false;//Can be changed to private later if need be.
    public bool goalGreen = false;
    public AudioClip win;

    //Setters for the stats. Other scripts should be able to access these to change values at any time.
    public void setGoalRed(bool x)
    { goalRed = x; }
   // public void setGoalBlue(bool x)
    //{ goalBlue = x; }
    public void setGoalGreen(bool x)
    { goalGreen = x; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))//Reset Button.
	        Application.LoadLevel(sceneName);

	    //Basically, since our scenes are premade, we can simply and easily tell unity to load the level again.
	    //This stuff works as long as the scenes are registered as levels in the build. We will need to do this anyway in order to switch levels.
	    //https://docs.unity3d.com/ScriptReference/Application.LoadLevel.html
	
	
        if(Input.GetKeyDown("p"))//Pause menu?
        {
	        //Display the pause menu, or the controls, or something. Optional.
        }
        Debug.Log("green is "+goalGreen+". red is "+goalRed);
        if(goalRed == true && goalGreen == true)
        {
            //Do the win menu. (GUI) Get from Chase.
            AudioManager.instance.PlaySingle(win, 1f);
            Application.LoadLevel(sceneName+1);
	        //For now, we'll just flatly load the next level.
        }
    }
}
