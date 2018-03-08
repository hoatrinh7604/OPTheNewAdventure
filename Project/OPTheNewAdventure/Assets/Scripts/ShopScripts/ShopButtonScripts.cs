using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButtonScripts : MonoBehaviour {

	public void backFunction()
	{
		SceneManager.LoadScene ("CharacterMenu");
	}
}
