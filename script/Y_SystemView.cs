using UnityEngine;
using System.Collections;

public class Y_SystemView : MonoBehaviour
{

    public GameObject viewObject;
    public UISprite viewTexture;
    public bool clicked = false;

    public void OnClick()
    {
        if (clicked)
        {
            clicked = false;
        }
        else
        {
            viewTexture.alpha = 0.2f;
            clicked = true;
        }
        viewObject.SetActive(clicked);
    }
}