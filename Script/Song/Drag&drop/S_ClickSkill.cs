using UnityEngine;
using System.Collections;

public class S_ClickSkill : MonoBehaviour {
	// Skill 그림을 위한 텍스쳐 이다.
	public UITexture[] skillTexture;
	public UISprite[] skillSprite;
	// 클릭이 됐는지 확인하는 변수
	public bool clicked;

	// 그림을 바꾸기 위한 변수 선언 이다.
	private UISprite sprite1;
	private GameObject SkillObject;

	void Start () {
		sprite1 = this.gameObject.GetComponent<UISprite>();
		SkillObject = this.gameObject;
		clicked = true;
	}

	void Update()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		//SkillObject =  other.gameObject;

	}

	public void OnClick()
	{
		//Debug.Log ("충돌 됨");
	

		//sprite1 = skillSprite[3];
		//Debug.Log (sprite1.spriteName);
		if (!clicked) {
			//sprite1.spriteName = skillSprite [0].spriteName;
			clicked = true;
		} else {
			//sprite1.spriteName = skillSprite [1].spriteName;
			clicked = false;
			Debug.Log ("충돌 됨");
		}
		//SkillObject.SetActive (clicked);
		sprite1.enabled = clicked;
		//Debug.Log (sprite1.spriteName);

	}

}
