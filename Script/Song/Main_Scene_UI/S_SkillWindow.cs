using UnityEngine;
using System.Collections;

public class S_SkillWindow : MonoBehaviour {
	public GameObject viewObject;

	private bool clicked = false;

    void Update()
    {
        // 'E' 키를 입력하면 클릭과 마찬가지로 작동이 되게 한다.
        if(Input.GetKeyDown(KeyCode.E))
        {
            // 버튼이 클릭 되어있는지 확인하고 바꾸어 주는 함수이다.
            CheckIsClick();
            // 클릭 상태에 따라 스킬창 활성 여부를 결정한다.
            viewObject.SetActive(clicked);
        }

    }

	public void OnClick()
	{
        // 버튼이 클릭 되어있는지 확인하고 바꾸어 주는 함수이다.
        CheckIsClick();

        // 클릭 상태에 따라 스킬창 활성 여부를 결정한다.
		viewObject.SetActive (clicked);
	}

    void CheckIsClick()
    {
        if (!clicked)
        {
            clicked = true;
            Debug.Log("눌림");
        }
        else
        {
            clicked = false;
        }
    }
}
