using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CreatePlayer : MonoBehaviour {

	private BaseClass newPlayer;
	//private string playerName = "Player1";

	//UI
	public Text nameText;
	public Text levelText;
	public Text currentExText;

	public Text healthText;
	public Text energyText;
	public Text strengthText;
	public Text armorText;
	public Text speedText;
	public Text criticalText;
	//public Text hitpointsText;
	//public Text regenText;

	private int pointToSpend = 0;
	public Text pointText;


	// Use this for initialization
	void Start () {
		newPlayer = new BaseClass ();
		loadDataById (1);// load Luffy
		//UpdateUI ();
	}

	public void saveData(){
		SaveAndLoadManager.saveCharacter (newPlayer, newPlayer.Id);
	}

	public void loadData(){
		PlayerData data = new PlayerData (new BaseClass());
		data = SaveAndLoadManager.loadCharacter (newPlayer.Id);
		newPlayer.Id = GameInfo.Id;

		newPlayer.Name = data.name;
		newPlayer.Level = data.stats [0];
		newPlayer.CurrentEx = data.stats [1];
		newPlayer.Health = data.stats [2];
		newPlayer.Energy = data.stats [3];
		newPlayer.Strength = data.stats [4];
		newPlayer.Armor = data.stats [5];
		newPlayer.Speed = data.stats [6];
		newPlayer.Critical = data.stats [7];
		newPlayer.Points = data.stats [8];

		UpdateUI ();
	}

	public void loadDataById(int idCharacter){
		PlayerData data = new PlayerData (new BaseClass());
		data = SaveAndLoadManager.loadCharacter (idCharacter);
		newPlayer.Id = idCharacter;

		newPlayer.Name = data.name;
		newPlayer.Level = data.stats [0];
		newPlayer.CurrentEx = data.stats [1];
		newPlayer.Health = data.stats [2];
		newPlayer.Energy = data.stats [3];
		newPlayer.Strength = data.stats [4];
		newPlayer.Armor = data.stats [5];
		newPlayer.Speed = data.stats [6];
		newPlayer.Critical = data.stats [7];
		newPlayer.Points = data.stats [8];

		UpdateUI ();
		updatGameInfo ();
		Debug.Log (GameInfo.Id +" and " + GameInfo.Name);
	}

	public void resetData(){
		SaveAndLoadManager.resetCharacter (newPlayer.Id);
	}

	// Del all file data of character
	public void deleteFile(){
		SaveAndLoadManager.deleteAllFile ();
		Debug.Log ("Delete!");
	}


	/*
	public void SetHealthClass(){
		newPlayer.PlayerClass = new BaseHealthClass ();
		newPlayer.Level = 1;
		newPlayer.CurrentEx = 0;
		newPlayer.Health = newPlayer.PlayerClass.Health;
		newPlayer.Energy = newPlayer.PlayerClass.Energy;
		newPlayer.Strength = newPlayer.PlayerClass.Strength;
		newPlayer.Armor = newPlayer.PlayerClass.Armor;
		newPlayer.Speed = newPlayer.PlayerClass.Speed;
		newPlayer.Critical = newPlayer.PlayerClass.Critical;

		// Update UI
		UpdateUI();
	}

	public void SetStrengthClass(){
		newPlayer.PlayerClass = new BaseStrengthClass ();
		newPlayer.Level = 1;
		newPlayer.CurrentEx = 0;
		newPlayer.Health = newPlayer.PlayerClass.Health;
		newPlayer.Energy = newPlayer.PlayerClass.Energy;
		newPlayer.Strength = newPlayer.PlayerClass.Strength;
		newPlayer.Armor = newPlayer.PlayerClass.Armor;
		newPlayer.Speed = newPlayer.PlayerClass.Speed;
		newPlayer.Critical = newPlayer.PlayerClass.Critical;

		// Update UI
		UpdateUI();
	}

	public void SetSpeedClass(){
		newPlayer.PlayerClass = new BaseSpeedClass ();
		newPlayer.Level = 1;
		newPlayer.CurrentEx = 0;
		newPlayer.Health = newPlayer.PlayerClass.Health;
		newPlayer.Energy = newPlayer.PlayerClass.Energy;
		newPlayer.Strength = newPlayer.PlayerClass.Strength;
		newPlayer.Armor = newPlayer.PlayerClass.Armor;
		newPlayer.Speed = newPlayer.PlayerClass.Speed;
		newPlayer.Critical = newPlayer.PlayerClass.Critical;

		// Update UI
		UpdateUI();
	}
	*/
	
	void UpdateUI(){

		nameText.text = newPlayer.Name;
		levelText.text = newPlayer.Level.ToString();
		currentExText.text = newPlayer.CurrentEx.ToString ();

		healthText.text = newPlayer.Health.ToString ();
		energyText.text = newPlayer.Energy.ToString ();
		strengthText.text = newPlayer.Strength.ToString ();
		armorText.text = newPlayer.Armor.ToString ();
		speedText.text = newPlayer.Speed.ToString ();
		criticalText.text = newPlayer.Critical.ToString ();
		strengthText.text = newPlayer.Strength.ToString ();

		pointText.text = newPlayer.Points.ToString ();
	}

	// Update GameInfo
	public void updatGameInfo(){
		GameInfo.Id = newPlayer.Id;
		GameInfo.Level = newPlayer.Level;
		GameInfo.Name = newPlayer.Name;
		GameInfo.CurrentEx = newPlayer.CurrentEx;

		GameInfo.Strength = newPlayer.Strength;
		GameInfo.Health = newPlayer.Health;
		GameInfo.Energy = newPlayer.Energy;
		GameInfo.Armor = newPlayer.Armor;
		GameInfo.Speed = newPlayer.Speed;
		GameInfo.Critical = newPlayer.Critical;
		GameInfo.Points = newPlayer.Points;
	}

	// Set when incre or decre
	public void setHealth(int amount){
		if (newPlayer.Id > 0) {
			if (amount > 0 && newPlayer.Points > 0) {
				// if click inButton
				newPlayer.Health += amount;
				newPlayer.Points -= 1;
				UpdateUI ();
				Debug.Log (GameInfo.Health + " and " + newPlayer.Health);
			} else if (amount < 0 && newPlayer.Health > GameInfo.Health) {
				// if click button deButton
				newPlayer.Health += amount; // amount < 0
				newPlayer.Points += 1;
				UpdateUI ();
			}
		} else {
			Debug.Log ("No class choosen!");
		}
	}

	public void setEnergy(int amount){
		if (newPlayer.Id > 0) {
			if (amount > 0 && newPlayer.Points > 0) {
				// if click inButton
				newPlayer.Energy += amount;
				newPlayer.Points -= 1;
				UpdateUI ();
			} else if (amount < 0 && newPlayer.Energy > GameInfo.Energy) {
				// if click button deButton
				newPlayer.Energy += amount; // amount < 0
				newPlayer.Points += 1;
				UpdateUI ();
			}
		} else {
			Debug.Log ("No class choosen!");
		}
	}

	public void setStrength(int amount){
		if (newPlayer.Id > 0) {
			if (amount > 0 && newPlayer.Points > 0) {
				// if click inButton
				newPlayer.Strength += amount;
				newPlayer.Points -= 1;
				UpdateUI ();
			} else if (amount < 0 && newPlayer.Strength > GameInfo.Strength) {
				// if click button deButton
				newPlayer.Strength += amount; // amount < 0
				newPlayer.Points += 1;
				UpdateUI ();
			}
		} else {
			Debug.Log ("No class choosen!");
		}
	}

	public void setArmor(int amount){
		if (newPlayer.Id > 0) {
			if (amount > 0 && newPlayer.Points > 0) {
				// if click inButton
				newPlayer.Armor += amount;
				newPlayer.Points -= 1;
				UpdateUI ();
			} else if (amount < 0 && newPlayer.Armor > GameInfo.Armor) {
				// if click button deButton
				newPlayer.Armor += amount; // amount < 0
				newPlayer.Points += 1;
				UpdateUI ();
			}
		} else {
			Debug.Log ("No class choosen!");
		}
	}
		
}
	
