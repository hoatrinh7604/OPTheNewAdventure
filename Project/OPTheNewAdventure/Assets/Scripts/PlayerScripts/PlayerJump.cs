using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

	[SerializeField] bool grounded = false;

	[SerializeField] float groundRadius = 0.2f;
	[SerializeField] float jumpForce = 700f;

	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask whatIsGround;

	private bool doubleJump = false;

	private Animator anim;
	private Rigidbody2D r2;

	private static int statePlayer;

	const string animGround = "Ground";
	const string animDoubleJump = "DoubleJump";
	const string animAttacking = "Attacking";

	const string animJump = "Jump";
	const string animDJump = "DJump";

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		statePlayer = PlayerState.statePlayer;
		if (Input.GetKeyDown (KeyCode.Space) && (statePlayer == 0) && (grounded || !doubleJump)) {
			grounded = false;
			anim.SetBool (animGround, grounded);
			r2.AddForce (Vector2.up * jumpForce);
			if (!grounded && !doubleJump) {
				doubleJump = true;
				anim.SetBool (animDoubleJump, doubleJump);
				r2.AddForce (Vector2.up * jumpForce * 0.5f);
				anim.Play (animDJump);
				anim.SetBool ("Attacking", false);
			} else {
				r2.AddForce (Vector2.up * jumpForce);
				anim.Play (animJump);
				anim.SetBool ("Attacking", false);
			}
		} 
			
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool (animGround, grounded);
		setJump ();

	}

	void setJump(){
		if (grounded) {
			doubleJump = false;
			anim.SetBool (animDoubleJump, doubleJump);
		} 
	}
}
