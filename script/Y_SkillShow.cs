using UnityEngine;
using System.Collections;

public class Y_SkillShow : MonoBehaviour {

    public GameObject viewObject;
    //public Camera camera;
    public bool clicked = false;
    // Use this for initialization
    public void OnClick()
    {
        if (clicked)
        {
            // camera.transform.position = new Vector3(camera.transform.position.x-10, camera.transform.position.y, 0);
            //viewObject.transform.position = new Vector3(viewObject.transform.position.x + 750, viewObject.transform.position.y, 0);
            clicked = false;
        }
        else
        {
            // camera.transform.position = new Vector3(camera.transform.position.x + 10, camera.transform.position.y, 0);
            //viewObject.transform.position = new Vector3(viewObject.transform.position.x-750, viewObject.transform.position.y,0);
            clicked = true;
        }
        viewObject.SetActive(clicked);
    }
}
