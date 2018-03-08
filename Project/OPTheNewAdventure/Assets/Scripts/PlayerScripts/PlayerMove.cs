using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float moveSpeed;
	public bool facingRight = true;

	private Animator anim;

	public bool moving = false;

	public float test;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxisRaw ("Horizontal") != 0f) {
			test = Input.GetAxisRaw ("Horizontal");
			bool temp = (Input.GetAxisRaw ("Horizontal") > 0f) ? true : false;
			if (facingRight != temp) {
				facingRight = temp;
				split ();
			}
			moving = true;
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
		} else {
			moving = false;
		}
		test = Input.GetAxisRaw ("Horizontal");
		anim.SetBool ("Moving", moving);

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
		transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
	}
}
