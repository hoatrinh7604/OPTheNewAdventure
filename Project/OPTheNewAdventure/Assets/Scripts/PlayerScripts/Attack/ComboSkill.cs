using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSkill : MonoBehaviour {

	[SerializeField] float timeReserverSkill1;
	[SerializeField] float timeReserverSkill2;
	[SerializeField] float[] forceSkillX = {0, 0};
	[SerializeField] float[] forceSkillY = {0, 0};

	//private static int statePlayer;
	private static float frozenPlayer;

	[SerializeField] int test;
	[SerializeField] float testTime;

	private Animator anim; 
	private Rigidbody2D r2;

	private const string animAttacking = "Attacking";
	private const string animSkill1 = "Skill1";
	private const string animSkill2 = "Skill2";
	private const string animGround = "Ground";

	// Use this for initialization
	void Start () {
		frozenPlayer = PlayerState.frozenPlayer;
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timeReserverSkill1 -= Time.deltaTime;
		timeReserverSkill2 -= Time.deltaTime;
		testTime = testTime;

		if (Input.GetKeyDown (KeyCode.K) && timeReserverSkill1 < 0f && (PlayerState.frozenPlayer < 0.05) && anim.GetBool(animGround)) {
			timeReserverSkill1 = 1f;
			float time = getTimeOfAnimation (animSkill1);
			anim.Play (animSkill1);
			setForceSkill (1);
			GetComponent<ComboAttack> ().resetCombo ();
			GetComponent<PlayerState>().setFrozenPlayer(time);
			Debug.Log ("Time Skill1 = " + time);
			Debug.Log ("Frozen Skill 1 = "+ PlayerState.frozenPlayer);
			anim.SetBool (animAttacking, true);

			StartCoroutine (waitEndAnim (time));
		}

		if (Input.GetKeyDown (KeyCode.L) && timeReserverSkill2 < 0f && (PlayerState.frozenPlayer < 0.05) && anim.GetBool(animGround)) {
			timeReserverSkill2 = 1f;
			float time = getTimeOfAnimation (animSkill2);

			anim.Play (animSkill2);
			setForceSkill (2);
			GetComponent<ComboAttack> ().resetCombo ();
			GetComponent<PlayerState>().setFrozenPlayer(time);
			Debug.Log ("Time Skill2 = " + time);
			Debug.Log ("Frozen Skill 2 = "+ PlayerState.frozenPlayer);
			anim.SetBool (animAttacking, true);

			// Tinh thoi gian chay het Skill animation va xu ly bien Attacking
			StartCoroutine (waitEndAnim (time));
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

	//Check player is attacking with skill
	public bool isSkilling(){
		if (timeReserverSkill1 > 0 || timeReserverSkill2 > 0) {
			return true;
		}
		return false;
	}

	void setForceSkill(int idSkill){
		// check direction of face player when load facingRight value in PlayerMove class (it and this class in the same Object)
		int way = (gameObject.GetComponent<PlayerMove> ().getFacingRight ())?1:-1;
		r2.AddForce (new Vector2 ((forceSkillX[idSkill-1])* way, forceSkillY[idSkill-1]));
	}


	// Set lai bien Attacking ve false sau khi chay het animation skill
	IEnumerator waitEndAnim(float time){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		anim.SetBool (animAttacking, false);
	}
}
