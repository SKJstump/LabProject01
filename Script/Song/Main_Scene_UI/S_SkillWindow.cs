using UnityEngine;
using System.Collections;

public class S_SkillWindow : MonoBehaviour {
	public GameObject viewObject;

	private bool clicked = false;
	public void OnClick()
	{
		if (!clicked) {
			clicked = true;
			Debug.Log ("눌림");
		}
		else {
			clicked = false;
		}

		viewObject.SetActive (clicked);
	}
}
