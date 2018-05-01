using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : CharacterInfo {

	// Use this for initialization
	void Start () {
		// When user choose a character in list to play, game system will load info of that character to this game Object
		this.setAllInfo (CharacterSelect.characterId);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public PlayerAttribute getPlayerAtt(){
		return this;
	}
}
