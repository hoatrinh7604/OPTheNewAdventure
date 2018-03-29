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
	private float frozenPlayer;

	private Animator anim;
	private Rigidbody2D r2;

	//state of player: 0 = idel; 1 = hurt; 2 = knockdown; 3 = stand up
	public static int statePlayer = 0;

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
		
		if (frozenPlayer < 0){
			//frozenPlayer = -1;
			if (statePlayer == 1) {
				statePlayer = 0;
			} else if (statePlayer == 2) {
				if (anim.GetBool (animGround)) {
					frozenPlayer = timeStand;
					anim.Play ("StandUp");
					statePlayer = 3;
				}
			} else if (statePlayer == 3) {
				statePlayer = 0;
			}

			anim.SetBool (animHurt, false);
			anim.SetBool (animKnocked, false);
		}

		testTime = frozenPlayer;
		test = statePlayer;

		anim.SetFloat (animFrozenPlayer, frozenPlayer);
		frozenPlayer -= Time.deltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.O) && statePlayer < 2) {
			beHurt (forceHurt);
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			beKnockedDown (forcePow, forcePow2);
		}

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
			frozenPlayer = timehurt;
			statePlayer = 1;
			r2.AddForce (new Vector2 (-x, 0));
		} else {
			beKnockedDown (x, 0f);
		}
	}

	// if player is knocked down => call function
	void beKnockedDown(float x, float y){
		anim.SetBool (animKnocked, true);
		frozenPlayer = timeKnocked;
		statePlayer = 2;
		r2.AddForce (new Vector2 (-x, y));
		//r2.velocity = new Vector2(r2.velocity.x * forcePow, r2.velocity.y * forcePow2);
	}
		
	// if player dead => call function
	void beDead(){
		statePlayer = 10;
		anim.SetBool (animDead, true);
	}

}
