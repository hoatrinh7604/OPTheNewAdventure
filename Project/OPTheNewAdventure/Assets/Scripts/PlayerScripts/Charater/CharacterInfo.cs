using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour {

	public int iDPlayer;
	public string nameCharacter;
	public float maxHeal;
	public float maxMana;

	public int levelCharacter;
	public float currentEX, exToLevelUp;

	public float strongIndex;
	public float critialIndex;

	public float[] attackDamage = {0, 0, 0, 0};
	public float[] knockAttack = {0, 0, 0, 0};

	public float[] skillDamage = {0, 0 };
	public float[] timeReserveSkill = { 0, 0 };
	public float[,] knockSkill = {{0, 0}, {0, 0}};

	public float jumpAttackDamage = 0;
	public float[] knockJA = {0, 0};

	// function to save info of character when need save in game
	public void saveInfo(){

	}

	// This function to get all info of a character follow its ID (Database)
	// Du lieu luu trong database su kien la mot mang 2 chieu cac thuoc tinh cua nhan vat
	public string[,] getInfo(int iDCharacter){
		return null;
	}

	// set all attribute of thi subject follow a data of character selected
	public void setAllInfo(int idCharacter){
		string[,] info = this.getInfo (idCharacter);
		/*
		this.iDPlayer = info.iDPlayer;
		this.nameCharacter = info.nameCharacter;
		this.maxHeal = info.maxHeal;
		this.maxMana = info.maxMana;

		this.levelCharacter = info.levelCharacter;
		this.currentEX = info.currentEX;
		this.exToLevelUp = info.exToLevelUp;

		this.strongIndex = info.strongIndex;
		this.critialIndex = info.critialIndex;

		this.attackDamage = info.attackDamage;
		this.knockAttack = info.knockAttack;
		this.skillDamage = info.skillDamage;
		this.knockSkill = info.knockSkill;
		*/

	}

	// Change info when chacracter levelUp
	public void setAttack(){

	}
}
