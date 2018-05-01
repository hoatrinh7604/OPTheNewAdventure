using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {

	public int idAttack;
	public float damage; // damage of skill
	public Transform positionSubject; // position of subject made damage to know direction
	public float knocked; // knocked{x,y}
	public float forceAttack; 

	[SerializeField] Rigidbody2D r2;

	void Start(){
		r2 = GetComponent<Rigidbody2D> ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	// ham tra ve thong tin cua mot attack
	public AttackPlayer getAttack(int idAttack){
		AttackPlayer attackP = new AttackPlayer ();
		PlayerAttribute playerAtt = new PlayerAttribute ().getPlayerAtt();

		attackP.idAttack = idAttack;
		attackP.damage = playerAtt.attackDamage [idAttack - 1];
		attackP.positionSubject = GetComponent<Transform> ();
		attackP.knocked = playerAtt.knockAttack[idAttack - 1];

		return attackP;
	}

}
