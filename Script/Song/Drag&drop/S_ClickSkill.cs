using UnityEngine;
using System.Collections;

public class S_ClickSkill : MonoBehaviour {
    // 마우스 객체에 그림이 전달되기 위한 변수
    public GameObject MouseObject;
    // 스킬 그림이 가지고 있는 스킬 오브젝트 마우스와 스킬셋으로 옮겨진다.
    public GameObject skillObject;

	void Start () {
        // 그림.. 안 그려지게 시작한다.
        MouseObject.GetComponent<UISprite>().enabled = false;
    }

    void OnClick()
    {
        // 그림 첵잇아웃한 다음 마우스에 드래그 시킨다.
        if(MouseObject.GetComponent<UISprite>().enabled == false)
        {
            MouseObject.GetComponent<UISprite>().spriteName = this.GetComponent<UISprite>().spriteName;
            MouseObject.GetComponent<UISprite>().enabled = true;

            // 마우스에게 어떤 스킬이 넘어 갔는지 알려준다.
            MouseObject.GetComponent<S_MouseCursorSprite>().skillObject = skillObject;
        }
        else
        {
            MouseObject.GetComponent<UISprite>().enabled = false;
        }
    }


	

}
