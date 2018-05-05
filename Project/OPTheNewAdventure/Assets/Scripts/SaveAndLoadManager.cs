using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveAndLoadManager {

	public static void createCharacter(int idCharacter){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/character" + idCharacter + ".opc", FileMode.Create);
		//Debug.Log(Application.persistentDataPath + "/character" + idCharacter + ".opc");

		PlayerData data = new PlayerData(getStartedCharacter(idCharacter));

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static void saveCharacter(BaseClass player, int idCharacter){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/character" + idCharacter + ".opc", FileMode.Create);

		PlayerData data = new PlayerData(player);

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static PlayerData loadCharacter(int idCharacter){
		if (File.Exists (Application.persistentDataPath + "/character" + idCharacter + ".opc")) {
			
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/character" + idCharacter + ".opc", FileMode.Open);

			PlayerData data = bf.Deserialize (stream) as PlayerData;

			stream.Close ();
			return data;
		} else {
			Debug.LogError ("The file isn't exist!");
			return new PlayerData(new BaseClass());
		}
	}

	public static void resetCharacter(int idCharacter){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream stream = new FileStream (Application.persistentDataPath + "/character" + idCharacter + ".opc", FileMode.Create);

		PlayerData data = new PlayerData(getStartedCharacter(idCharacter));

		bf.Serialize (stream, data);
		stream.Close ();
	}

	public static void deleteAllFile(){
		for (int i = 1; i < 4; i++) {
			File.Delete (Application.persistentDataPath + "/character" + i + ".opc");
		}
	}

	// Function for reset
	public static BaseClass getStartedCharacter(int idCharacter){
		if (idCharacter == 1) {// if is Luffy
			return new BaseHealthClass();
		} else if (idCharacter == 2) {// if is Sanji
			return new BaseSpeedClass();
		} else if (idCharacter == 3) {// if is Zoro
			return new BaseStrengthClass();
		} else {
			return new BaseClass ();
		}
	}// end of getStartCharacter
}// end of class

[Serializable]
public class PlayerData {
	public int[] stats;
	public string name;
	//public string story;

	public PlayerData(BaseClass player){
		stats = new int[9];
		stats [0] = player.Level;
		stats [1] = player.CurrentEx;
		stats [2] = player.Health;
		stats [3] = player.Energy;
		stats [4] = player.Strength;
		stats [5] = player.Armor;
		stats [6] = player.Speed;
		stats [7] = player.Critical;
		stats [8] = player.Points;

		name = player.Name;
		//story = player.Story;
	}

}





































