using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	[SerializeField] float moveSpeed;

	[SerializeField] bool facingRight = true;
	[SerializeField] bool moving = false;

	[SerializeField] float timeReserveCross;
	[SerializeField] float forceCross;

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
		timeReserveCross -= Time.deltaTime;

		float moveValue = (idPlayer == 1) ? Input.GetAxisRaw (moveValueHorizontal) : Input.GetAxisRaw(movePlayer2);
		if (moveValue != 0f && (PlayerState.frozenPlayer < 0)) {
			bool temp = (moveValue > 0f) ? true : false;
			if (facingRight != temp) {
				facingRight = temp;
				split ();
			}

			if (timeReserveCross < 0.15f) {
				moving = true;
			}
			r2.velocity = new Vector2(test * moveSpeed, r2.velocity.y);
			anim.SetBool ("Attacking", false);
			GetComponent<ComboAttack> ().resetCombo ();// reset combo attack when moving
		} else {
			moving = false;
		}

		//function check to cross
		if (Input.GetKeyDown (KeyCode.H) && timeReserveCross < 0 && PlayerState.frozenPlayer < 0) {
			timeReserveCross = 0.4f;
			int way = facingRight ? 1 : -1;
			//r2.AddForce (new Vector2 (8000*way, 0));
			if (moving) {
				r2.velocity = new Vector2 (r2.velocity.x + 750 * way, r2.velocity.y);
			} else {
				r2.velocity = new Vector2 (r2.velocity.x + forceCross * way, r2.velocity.y);
			}
			anim.Play ("Cross");
		}

		test = moveValue;
		anim.SetBool (animMoving, moving);

		// tao ma sat
		r2.velocity = new Vector2 (r2.velocity.x * 0.7f, r2.velocity.y);

	}

	public void split()
	{
		//facingRight = !facingRight;
		tran.localScale = new Vector3(tran.localScale.x *-1, tran.localScale.y, tran.localScale.z);
	}

	public bool getFacingRight(){
		return facingRight;
	}

	public bool getMoving(){
		return moving;
	}

}
