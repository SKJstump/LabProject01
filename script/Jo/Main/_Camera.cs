using UnityEngine;
using System.Collections;

public class _Camera : MonoBehaviour {

    public float cameraYPos;
    public GameObject playerCtrl;
	// Use this for initialization
	void Start ()
    {
    }

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        x = Mathf.Lerp(x, playerCtrl.transform.position.x, Time.deltaTime);
        //y = Mathf.Lerp(y, playerCtrl.transform.position.y + cameraYPos, Time.deltaTime);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
	
}
