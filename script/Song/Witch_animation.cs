using UnityEngine;
using System.Collections;

public class Witch_animation : MonoBehaviour {
	public enum WitchState {idle, attack };
	public WitchState witchState = WitchState.idle; 

	private Animator animator;
	private bool isDie = false;

	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();

		// 모델의 상태를 확인하여 상태를 바꾸어줌.
		//StartCoroutine (this.CheckState ());
		// 모델의 상태를 확ㅣㄴ하여 액ㄴ을 바어줌.
		//StartCoroutine (this.CheckAction ());
	}

	void Update()
	{
		CheckState ();
		CheckAction ();
	}

	void CheckState()
	{
		if (!isDie) {
			//yield return new WaitForSeconds (0.2f);
			if (Input.GetKey (KeyCode.A) == true) {
				witchState = WitchState.attack;
				Debug.Log ("어택으로 전환");
			
			}
		}
	}

	void CheckAction()
	{
		if (!isDie) {
			//yield return new WaitForSeconds (0.2f);

			switch (witchState) {
			case WitchState.idle:
				animator.SetBool("Run", false);
				break;
			case WitchState.attack:
				Debug.Log ("어택으로 전환");
				animator.SetBool("Run", true);
				witchState = WitchState.idle;
				break;
			}
		}
	}
}
