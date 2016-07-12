using UnityEngine;
using System.Collections;

public class Y_InventroryActive : MonoBehaviour {

    public GameObject viewObject;
    public bool clicked = false;
	// Use this for initialization
	public void OnClick()
    {
        if (clicked)
            clicked = false;
        else clicked = true;
        viewObject.SetActive(clicked);
    }
}
