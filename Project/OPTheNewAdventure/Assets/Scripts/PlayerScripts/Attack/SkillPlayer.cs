using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class will determine all skill of your character like: force, damage and more other states 
public class SkillPlayer : MonoBehaviour {

	public int idSkill;
	public float damage; // damage of skill
	public Transform positionSubject; // position of subject made damage to know direction
	public float[] knocked = {0, 0}; // knocked{x,y}
	public float[] forceSkill = {0, 0};
	public float timeReserve = 4f;

	[SerializeField] Rigidbody2D r2;

	void Start(){
		r2 = GetComponent<Rigidbody2D> ();
	}

	public void setSkillIndex(int idSkill, float damage, Transform pos, float[] knock){
		this.idSkill = idSkill;
		this.damage = damage;
		this.positionSubject = pos;
		this.knocked = knock;
	}


	// get info of skill
	public SkillPlayer getSkill(int idSkill){
		SkillPlayer skillP = new SkillPlayer ();
		PlayerAttribute playerAtt = new PlayerAttribute ().getPlayerAtt();

		skillP.idSkill = 1;
		skillP.damage = playerAtt.skillDamage [idSkill - 1];
		skillP.timeReserve = playerAtt.timeReserveSkill [idSkill - 1];
		skillP.positionSubject = GetComponent<Transform> ();
		skillP.knocked [0] = playerAtt.knockSkill[0, 0];
		skillP.knocked [1] = playerAtt.knockSkill[0, 1];

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

		skillP.damage = playerAtt.jumpAttackDamage;
		skillP.positionSubject = GetComponent<Transform> ();
		skillP.knocked [0] = playerAtt.knockJA[0];
		skillP.knocked [1] = playerAtt.knockJA[1];

		return skillP;
	}

}
