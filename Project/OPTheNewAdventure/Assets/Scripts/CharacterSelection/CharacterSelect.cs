using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

	public static int characterId;

	public void charaterSelected(int characterIdSelected)
	{
		characterId = characterIdSelected;
		Debug.Log (characterId);
	}
}
