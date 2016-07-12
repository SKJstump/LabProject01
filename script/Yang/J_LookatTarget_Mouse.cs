using UnityEngine;
using System.Collections;

public class J_LookatTarget_Mouse : MonoBehaviour
{

    public float speed;
    private Vector2 velocity;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        velocity = new Vector2(x, y);

        velocity *= speed * Time.fixedDeltaTime;

        transform.Translate(velocity);
    }
}
