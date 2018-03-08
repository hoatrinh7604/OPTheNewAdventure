using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterButtons : MonoBehaviour {

	public void continueFunction()
	{
		SceneManager.LoadScene (LevelSelectionLogic.currentLevelIndex);
	}

	public void backFunction()
	{
		SceneManager.LoadScene ("MapMenu");
	}

	public void shopFunction()
	{
		SceneManager.LoadScene ("ShopGame");
	}
}
