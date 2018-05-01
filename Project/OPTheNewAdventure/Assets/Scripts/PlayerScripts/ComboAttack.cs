using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : MonoBehaviour {

	private Animator anim;
	private Rigidbody2D r2;

	[SerializeField] bool canNextCombo =  true; // anim can change continue when this val is false
	[SerializeField] bool canAttack = true; //numTouch will not incre when this val is false
	[SerializeField] int currentAttack = 0;
	[SerializeField] int numTouch = 0;

	[SerializeField] float[] forceAttack = {10, 10, 10, -10};
	private string[] nameAttack = {"Attack1", "Attack2", "Attack3", "Attack4"};

	const string animIdel = "Idel";
	const string animAttacking = "Attacking";
	const string animGround = "Ground";
	const string animJumpAttack = "JumpAttack";

	//public int state;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.J) && PlayerState.frozenPlayer < 0){
			if (anim.GetBool (animGround) && !GetComponent<PlayerMove>().getMoving()) {
				if (canAttack) {
					numTouch++;
				}
				if (numTouch > 4) {
					numTouch = 4;
					canAttack = false;
				}

			} else if (!anim.GetBool(animAttacking) && !anim.GetBool(animGround)) {
					r2.velocity = new Vector2 (0, -100f);
					anim.Play (animJumpAttack);
				}
		}

		// Kiem tra xem anim hien tai co phai la cua Attack OR la (Idel va combo1 =true (vua an Attack xong) 
		if (numTouch > 0 && anim.GetBool(animGround)) {
			if (canNextCombo) {
				canNextCombo = false;

				anim.SetBool (animAttacking, true);
				//anim.Play (nameAttack [currentAttack]); play function to set anything in Attack
				setAttack(currentAttack);

				float time = getTimeOfAnimation(nameAttack[currentAttack]);
				Debug.Log (nameAttack [currentAttack] + " : " + time);
				StartCoroutine (waitEndAnim (time));
			}
		} 
	}

	// Ham chay khi doi 1 anim chay het
	IEnumerator waitEndAnim(float time){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		canNextCombo = true;
		currentAttack++;
		if (currentAttack > 3) {
			currentAttack = 0;
			numTouch = 0;
		}
		numTouch--;
		if (numTouch <= 0) {
			numTouch = 0;
			canAttack = true;
			currentAttack = 0;
			if(!GetComponent<ComboSkill>().isSkilling()){
				anim.Play (animIdel);
				anim.SetBool ("Attacking", false);
			}
		}
	}

	// Get time of animation by name
	float getTimeOfAnimation(string nameOfAnim){
		float time = 0;
		RuntimeAnimatorController ac = anim.runtimeAnimatorController;   

		for (int i = 0; i < ac.animationClips.Length; i++)
			if (ac.animationClips[i].name == nameOfAnim)
				time = ac.animationClips[i].length;

		return time;
	}

	void setAttack(int idAttack){
		anim.Play (nameAttack [idAttack]);

		// check direction of face player when load facingRight value in PlayerMove class (it and this class in the same Object)
		int way = (gameObject.GetComponent<PlayerMove> ().getFacingRight ())?1:-1;
		r2.AddForce (new Vector2 ((forceAttack[idAttack])* way, 0));
	}

	public void resetCombo(){
		this.currentAttack = 0;
		this.numTouch = 0;
	}
		
}
