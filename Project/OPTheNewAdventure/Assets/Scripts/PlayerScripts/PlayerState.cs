using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	[SerializeField] float forcePow = 100f;
	[SerializeField] float forcePow2 = 200f;
	[SerializeField] float forceHurt = 100f;

	// set time be hurt
	[SerializeField] float timehurt = 2f;
	[SerializeField] float timeKnocked = 1f;
	[SerializeField] float timeStand = 1f;

	[SerializeField] bool isDead = false;

	[SerializeField] int test;
	[SerializeField] float testTime;

	// player can't control if this value > 0
	public static float frozenPlayer;

	private Animator anim;
	private Rigidbody2D r2;

	//state of player: 0 = idel; 1 = hurt; 2 = knockdown; 3 = stand up; 4 = Skilling 
	// State: 0 = standUp; 1 = JA; 2 = Hurt; 3 = Knock; 4 = Skill; 5 = Attack; 6 = Jump; 7 = Move; 8 = Idel 
	// 10 = Dead
	public static int statePlayer = 8;

	const string animHurt = "Hurt";
	const string animKnocked = "Knocked";
	const string animGround = "Ground";
	const string animFrozenPlayer = "FrozenPlayer";
	const string animDead = "Dead";

	void Awake(){
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Update () {
		if (Input.GetKeyDown (KeyCode.O)) {
			beHurt (forceHurt);
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			beKnockedDown (forcePow, forcePow2);
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (frozenPlayer < 0){
			if (statePlayer == 2) {
				statePlayer = 8;
			} else if (statePlayer == 3) {
				if (anim.GetBool (animGround)) {
					frozenPlayer = getTimeOfAnimation("StandUp");
					Debug.Log ("StandUp = "+frozenPlayer);
					anim.Play ("StandUp");
					statePlayer = 0;
				}
			} else if (statePlayer == 0) {
				statePlayer = 8;
			} 

			anim.SetBool (animHurt, false);
			anim.SetBool (animKnocked, false);
		}

		testTime = frozenPlayer;
		test = statePlayer;

		anim.SetFloat (animFrozenPlayer, frozenPlayer);
		frozenPlayer -= Time.deltaTime;



		if (isDead) {
			beDead ();
			frozenPlayer = 10f;
		} else {
			anim.SetBool (animDead, false);
		}
			
	}

	// if player is attacked => call this function
	void beHurt(float x){
		if (anim.GetBool (animGround)) {
			anim.SetBool (animHurt, true);
			frozenPlayer = getTimeOfAnimation("Hurt");
			Debug.Log ("Hurt =" +frozenPlayer);
			statePlayer = 2;
			r2.AddForce (new Vector2 (-x, 0));
		} else {
			beKnockedDown (x, 0f);
		}
	}

	// if player is knocked down => call function
	void beKnockedDown(float x, float y){
		anim.SetBool (animKnocked, true);
		frozenPlayer = getTimeOfAnimation("KnockedDown");
		Debug.Log ("KnockedDown =" + frozenPlayer);
		statePlayer = 3;
		r2.AddForce (new Vector2 (-x, y));
	}
		
	// if player dead => call function
	void beDead(){
		statePlayer = 10;
		anim.SetBool (animDead, true);
	}


	// set state
	public void setState(int state){
		statePlayer = state;
	}

	// set frozenPlayer
	public void setFrozenPlayer(float frozen){
		frozenPlayer = frozen;
	}

	// get time of a animation by name
	float getTimeOfAnimation(string nameOfAnim){
		float time = 0;
		RuntimeAnimatorController ac = anim.runtimeAnimatorController;   

		for (int i = 0; i < ac.animationClips.Length; i++)
			if (ac.animationClips[i].name == nameOfAnim)
				time = ac.animationClips[i].length;

		return time;
	}

}
