using UnityEngine;
using System.Collections;

public class S_DropSkillToSkillSet : MonoBehaviour {
    public GameObject MouseObject;
    // 마우스 오브젝트에서 넘어오는 스킬 오브젝트
    public GameObject skillObject;

	void Start () {
	
	}
	
	void OnClick()
    {
        // 마우스에 스킬 드래그 중이어야 작동한다.
        if (MouseObject.GetComponent<UISprite>().enabled)
        {
            this.GetComponent<UISprite>().spriteName = MouseObject.GetComponent<UISprite>().spriteName;
            MouseObject.GetComponent<UISprite>().enabled = false;

            // 마우스에게서 오브젝트를 받아온다.
            skillObject = MouseObject.GetComponent<S_MouseCursorSprite>().skillObject;
        }
    }
}
