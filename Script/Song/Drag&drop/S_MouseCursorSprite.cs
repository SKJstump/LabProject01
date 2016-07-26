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
        // 마우스 좌표 초기화다
		objectTransf = GetComponent<Transform> ();

        // 카메라 못찾으면 안되서 넣어 준다.
		if (uiCamera == null)
			uiCamera = NGUITools.FindCameraForLayer(gameObject.layer);

        // 그림 안그린다.
        this.GetComponent<UISprite>().enabled = false;
		
		//skillObjectScript = skillObject.GetComponent<S_ClickSkill>();
		
	}

	void Update()
	{
        // 첵잇아웃 해서 그림 그려지면 마우스 따라다닌다.
		if (this.GetComponent<UISprite>().enabled) {
			MouseObjectMove ();
		}

        if (Input.GetMouseButtonDown(1))
        {
            this.GetComponent<UISprite>().enabled = false;
        }


	}

	void MouseObjectMove()
	{
		//Debug.Log ("작동!");
		Vector3 mousePos = Input.mousePosition;

        // DirectX ; 화면 좌표 월드 좌표까지 옮긴다.
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

		//Debug.Log (objectTransf.position);
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
