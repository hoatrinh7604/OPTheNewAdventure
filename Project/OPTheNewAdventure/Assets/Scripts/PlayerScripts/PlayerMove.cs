using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	[SerializeField] float moveSpeed;

	[SerializeField] bool facingRight = true;
	[SerializeField] bool moving = false;

	[SerializeField] float test;
	[SerializeField] int idPlayer = 1;

	private Animator anim;
	private Rigidbody2D r2;
	private Transform tran;

	// this val will get value in statePlayer in PlayerState Class
	private static int statePlayer;

	const string animMoving = "Moving";
	const string animGround = "Ground";

	const string moveValueHorizontal = "Horizontal";
	const string movePlayer2 = "Player2";

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
		tran = transform;
	}

	void Update(){
		statePlayer = PlayerState.statePlayer;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveValue = (idPlayer == 1) ? Input.GetAxisRaw (moveValueHorizontal) : Input.GetAxisRaw(movePlayer2);
		if (moveValue != 0f && (statePlayer == 0)) {
			bool temp = (moveValue > 0f) ? true : false;
			if (facingRight != temp) {
				facingRight = temp;
				split ();
			}
			moving = true;
			//r2.AddForce(new Vector2 (test * moveSpeed, 0));
			r2.velocity = new Vector2(test * moveSpeed, r2.velocity.y);
			anim.SetBool ("Attacking", false);
		} else {
			moving = false;
		}

		test = moveValue;
		anim.SetBool (animMoving, moving);

		if (anim.GetBool (animGround)) {
			r2.velocity = new Vector2 (r2.velocity.x * 0.7f, r2.velocity.y);
		} 
		/*
		float move = Input.GetAxis ("Horizontal");
		test = move;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (move > 0) {
			anim.SetBool ("Moving", moving);
		}

		if (move > 0 && !facingRight) {
			split ();
		}else if(move < 0 && facingRight){
			split ();
		}
		*/

	}

	public void split()
	{
		//facingRight = !facingRight;
		tran.localScale = new Vector3(tran.localScale.x *-1, tran.localScale.y, tran.localScale.z);
	}

}
