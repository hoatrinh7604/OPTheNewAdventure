using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {


		public Ingredient potionResult;
		public Ingredient[] potionIngredients;

}

public enum IngredientUnit { Spoon, Cup, Bowl, Piece }

// Custom serializable class
[System.Serializable]
public class Ingredient
{
	public string name;
	public int amount = 1;
	public int oneVal;
	public IngredientUnit unit;
}
