using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour {

	public GameObject[] characters;
	public Transform characterSpawnPoint;

	void Start () {
		Instantiate (characters[CharacterSelect.characterId], characterSpawnPoint.position, characterSpawnPoint.rotation);
	}

}
