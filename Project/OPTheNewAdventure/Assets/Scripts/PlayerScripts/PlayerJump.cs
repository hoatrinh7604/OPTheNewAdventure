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

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		statePlayer = PlayerState.statePlayer;
		anim.SetBool (animGround, grounded);
		anim.SetBool (animDoubleJump, doubleJump);
		setJump ();
	}

	void FixedUpdate(){

		if (Input.GetKeyDown (KeyCode.Space) && (statePlayer == 0) && (grounded || !doubleJump) ) {
			grounded = false;
			r2.AddForce (Vector2.up * jumpForce);
			if (!grounded && !doubleJump) {
				doubleJump = true;
				r2.AddForce (Vector2.up * jumpForce * 0.5f);
			} else {
				r2.AddForce (Vector2.up * jumpForce);
			}
		} 

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
	}

	void setJump(){
		if (grounded) {
			doubleJump = false;
		} 
	}
}
