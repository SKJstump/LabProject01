using UnityEngine;
using System.Collections;

public class S_DropSkillToSkillSet : MonoBehaviour {
    public GameObject MouseObject;

	void Start () {
	
	}
	
	void OnClick()
    {
        if (MouseObject.GetComponent<UISprite>().enabled)
        {
            this.GetComponent<UISprite>().spriteName = MouseObject.GetComponent<UISprite>().spriteName;
            MouseObject.GetComponent<UISprite>().enabled = false;
        }
    }
}
