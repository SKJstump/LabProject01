using UnityEngine;
using System.Collections;

public class S_MouseCursorSprite : MonoBehaviour {
	// 마우스의 움직임을 저장할 변수
	private Transform objectTransf;
	// 스크립트 변수 참조를 위한 선언.
	//private S_ClickSkill skillObjectScript;

	// 어떤 스킬 오브젝트가 올 것인가.
	public GameObject skillObject;
	// 카메라 입력.
	public Camera uiCamera;
	// 인스턴싱으로 마우스 스프라이트를 그림
	static public S_MouseCursorSprite instance;


	void Awake() { instance = this; }

	void OnDestroy() { instance = null; }

	void Start()
	{
		objectTransf = GetComponent<Transform> ();

		if (uiCamera == null)
			uiCamera = NGUITools.FindCameraForLayer(gameObject.layer);

        this.GetComponent<UISprite>().enabled = false;
		
		//skillObjectScript = skillObject.GetComponent<S_ClickSkill>();
		
	}

	void Update()
	{
		//CheckMObjectActive ();

		//if (isActive) {
		if (this.GetComponent<UISprite>().enabled) {
			MouseObjectMove ();
		}

	}

	void MouseObjectMove()
	{
		//Debug.Log ("작동!");
		Vector3 mousePos = Input.mousePosition;


		if (uiCamera != null)
		{
			// Since the screen can be of different than expected size, we want to convert
			// mouse coordinates to view space, then convert that to world position.
			mousePos.x = Mathf.Clamp01(mousePos.x / Screen.width);
			mousePos.y = Mathf.Clamp01(mousePos.y / Screen.height);
			objectTransf.position = uiCamera.ViewportToWorldPoint(mousePos);

			// For pixel-perfect results
			if (uiCamera.orthographic)
			{
				Vector3 lp = objectTransf.localPosition;
				lp.x = Mathf.Round(lp.x);
				lp.y = Mathf.Round(lp.y);
				objectTransf.localPosition = lp;
			}
		}
		else
		{
			// Simple calculation that assumes that the camera is of fixed size
			mousePos.x -= Screen.width * 0.5f;
			mousePos.y -= Screen.height * 0.5f;
			mousePos.x = Mathf.Round(mousePos.x);
			mousePos.y = Mathf.Round(mousePos.y);
			objectTransf.localPosition = mousePos;
		}

		Debug.Log (objectTransf.position);
	}

	void CheckMObjectActive()
	{
		//if (skillObjectScript.clicked) {
		//	//isActive = true;
		//	instance.GetComponent<UISprite>().enabled = false;
		//	instance.GetComponent<UISprite>().spriteName = skillObject.GetComponent<UISprite>().spriteName;


		//	//Debug.Log ("작동!");
		//} else {
		//	//isActive = false;
		//	instance.GetComponent<UISprite>().enabled = true;
		//	Debug.Log ("작동!");
		//}
	}

    
}
