using UnityEngine;
using System.Collections;

public class _MoveMouse : MonoBehaviour {

    public GameObject player;
    public float speed;
    private Vector3 velocity;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");

        velocity = new Vector3(x*speed, y*speed, 0);

        transform.position += velocity * Time.fixedDeltaTime;


    }
}
