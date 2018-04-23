using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class will determine all skill of your character like: force, damage and more other states 
public class SkillPlayer : MonoBehaviour {

	public int idAttack;
	public bool isSkill; // maybe the skill need run fast (enemy like slowly or static)
	public float damage; // damage of skill
	public Transform positionSubject; // position of subject made damage to know direction
	public float[] knocked = {0, 0}; // knocked{x,y}

	[SerializeField] Rigidbody2D r2;

	void Start(){
		r2 = GetComponent<Rigidbody2D> ();
	}

	public void setSkillIndex(int idAttack, bool isSkill, float damage, Transform pos, float[] knock){
		this.idAttack = idAttack;
		this.isSkill = isSkill;
		this.damage = damage;
		this.positionSubject = pos;
		this.knocked = knock;
	}

	// Attak1 function
	public SkillPlayer getAttack1(){
		SkillPlayer attackP = new SkillPlayer ();
		PlayerAttribute playerAtt = new PlayerAttribute ().getPlayerAtt();

		attackP.idAttack = 1;
		attackP.isSkill = false;
		attackP.damage = playerAtt.attackDamage [0];
		attackP.positionSubject = GetComponent<Transform> ();
		attackP.knocked [0] = playerAtt.knockAttack[0];
		attackP.knocked [1] = 0f;

		return attackP;
	}

	// Attack2 function
	public SkillPlayer getAttack2(){
		SkillPlayer attackP = new SkillPlayer ();
		PlayerAttribute playerAtt = new PlayerAttribute ().getPlayerAtt();

		attackP.idAttack = 2;
		attackP.isSkill = false;
		attackP.damage = playerAtt.attackDamage [1];
		attackP.positionSubject = GetComponent<Transform> ();
		attackP.knocked [0] = playerAtt.knockAttack[1];
		attackP.knocked [1] = 0f;

		return attackP;
	}

	// Attack3 function
	public SkillPlayer getAttack3(){
		SkillPlayer attackP = new SkillPlayer ();
		PlayerAttribute playerAtt = new PlayerAttribute ().getPlayerAtt();

		attackP.idAttack = 3;
		attackP.isSkill = false;
		attackP.damage = playerAtt.attackDamage [2];
		attackP.positionSubject = GetComponent<Transform> ();
		attackP.knocked [0] = playerAtt.knockAttack[2];
		attackP.knocked [1] = 0f;

		return attackP;
	}

	// Attack4 function
	public SkillPlayer getAttack4(){
		SkillPlayer attackP = new SkillPlayer ();
		PlayerAttribute playerAtt = new PlayerAttribute ().getPlayerAtt();

		attackP.idAttack = 4;
		attackP.isSkill = false;
		attackP.damage = playerAtt.attackDamage [3];
		attackP.positionSubject = GetComponent<Transform> ();
		attackP.knocked [0] = playerAtt.knockAttack[3];
		attackP.knocked [1] = 0f;

		return attackP;
	}



	// Skill1 function
	public SkillPlayer getSkill1(){
		SkillPlayer skillP = new SkillPlayer ();
		PlayerAttribute playerAtt = new PlayerAttribute ().getPlayerAtt();

		skillP.idAttack = 1;
		skillP.isSkill = true;
		skillP.damage = playerAtt.skillDamage [0];
		skillP.positionSubject = GetComponent<Transform> ();
		skillP.knocked [0] = playerAtt.knockSkill[0, 0];
		skillP.knocked [1] = playerAtt.knockSkill[0, 1];

		return skillP;
	}

	// Skill2 function
	public SkillPlayer getSkill2(){
		SkillPlayer skillP = new SkillPlayer ();
		PlayerAttribute playerAtt = new PlayerAttribute ().getPlayerAtt();

		skillP.idAttack = 2;
		skillP.isSkill = true;
		skillP.damage = playerAtt.skillDamage [1];
		skillP.positionSubject = GetComponent<Transform> ();
		skillP.knocked [0] = playerAtt.knockSkill[1, 0];
		skillP.knocked [1] = playerAtt.knockSkill[1, 1];

		return skillP;
	}


	// Jump attack function process
	public void jumpAttack(){
		r2.AddForce (new Vector2 (0f, -500f));
	}

	// Jump attack function get data
	public SkillPlayer getJumpAttack(){
		SkillPlayer skillP = new SkillPlayer ();
		PlayerAttribute playerAtt = new PlayerAttribute ().getPlayerAtt();

		skillP.isSkill = false;
		skillP.damage = playerAtt.jumpAttackDamage;
		skillP.positionSubject = GetComponent<Transform> ();
		skillP.knocked [0] = playerAtt.knockJA[0];
		skillP.knocked [1] = playerAtt.knockJA[1];

		return skillP;
	}

}
