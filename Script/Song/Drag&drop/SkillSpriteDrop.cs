using UnityEngine;
using System.Collections;

public class SkillSpriteDrop : MonoBehaviour {
	// 스크립트 변수 참조를 우ㅣ한 선언.
	private S_MouseCursorSprite skillObjectScript;
	private bool Clicked = false;

	// 어떤 스킬 슬롯을 사용할 것인가.
	public GameObject mouseObject;


	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnClick()
	{
		if (skillObjectScript.GetComponent<UISprite> ().enabled) {
			
		}
	}
}
