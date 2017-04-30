using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiTestingi : MonoBehaviour {

	public void MainMenuTest(){

		int test = 2;
		MainMenuScript.Resetter ();

		Assert.AreEqual(test, MainMenuScript.i)

		MainMenuScript.NextLevel ();

		test = 3;

		Assert.AreEqual(test, MainMenuScript.i)

		MainMenuScript.Resetter ();

		Assert.AreEqual(test, MainMenuScript.i)
	}
}
