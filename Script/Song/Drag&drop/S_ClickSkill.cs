using UnityEngine;
using System.Collections;

public class S_ClickSkill : MonoBehaviour {
    public GameObject MouseObject;

	void Start () {
        MouseObject.GetComponent<UISprite>().enabled = false;
    }

    void OnClick()
    {
        if(MouseObject.GetComponent<UISprite>().enabled == false)
        {
            MouseObject.GetComponent<UISprite>().spriteName = this.GetComponent<UISprite>().spriteName;
            MouseObject.GetComponent<UISprite>().enabled = true;
        }
        else
        {
            MouseObject.GetComponent<UISprite>().enabled = false;
        }
    }


	

}
