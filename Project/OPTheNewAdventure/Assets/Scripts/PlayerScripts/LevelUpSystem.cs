using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSystem : MonoBehaviour {
	public int XP;
	public int currentLevel;

	// Use this for initialization
	void Start () {
		Debug.Log((0.1f * Mathf.Sqrt(XP)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Save data when character level up
	public void levelUpAndSave(){
		GameInfo.Level++;
		GameInfo.Points += 5;

		SaveAndLoadManager.saveCharacter (GameInfo.getBaseClass (), GameInfo.Id);
	}

	// update Xp when player play game
	public void UpdateXp(int xp){
		GameInfo.CurrentEx += xp;

		// Get level follow XP
		int ourLevel = (int)(0.1f * Mathf.Sqrt(GameInfo.CurrentEx));

		if (ourLevel != currentLevel) {
			currentLevel = ourLevel;
			levelUpAndSave ();

		}

		// to test and show info
		int xpNextLevel = 100 * (currentLevel + 1) * (currentLevel + 1);
		int diffXp = xpNextLevel - GameInfo.CurrentEx;

		int totalDiffXp = xpNextLevel - (100 * currentLevel * currentLevel);
		int test = GameInfo.CurrentEx - (100 * currentLevel * currentLevel);

		int a = (int)(test*100 / totalDiffXp);
		levelUp ();
		Debug.Log (a + "%");

	}

	// function to test
	public void levelUp(){
		Debug.Log ("Level =" + currentLevel);
		Debug.Log ("Current Xp =" + GameInfo.CurrentEx);
		Debug.Log ("Next Level Up =" + 100 * (currentLevel + 1) * (currentLevel + 1));
	}
}
