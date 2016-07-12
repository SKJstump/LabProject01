using UnityEngine;
using System.Collections;

public class J_UnityChan_Move : MonoBehaviour {

    public GameObject LookatTarget;

    public float ForwardSpeed;
    public float BackwardSpeed;
    public float JumpPower;
    private Vector3 velocity;
    private Rigidbody rb;

    private bool right = false;
    private bool left = false;
    private bool jump = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Target_Position(); // 주인공이 바라보는 방향을 저장한다.
        transform.LookAt(LookatTarget.transform.position); // 표적을 바라본다.


        float h = Input.GetAxis("Horizontal");

        velocity = Vector3.forward;
        velocity = transform.TransformDirection(velocity);

        if (right)
        {
            if (h > 0.1)
                velocity *= ForwardSpeed;
            if (h < -0.1)
                velocity *= -BackwardSpeed;
        }
        if(left)
        {
            if (h > 0.1)
                velocity *= -BackwardSpeed;
            if (h < -0.1)
                velocity *= ForwardSpeed;
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0, JumpPower, 0, ForceMode.VelocityChange);
        }
            

        transform.localPosition += velocity * Time.deltaTime * h * h;
    }

    void Target_Position()
    {
        if (transform.position.x > LookatTarget.transform.position.x)
        {
            left = true;
            right = false;
            Debug.Log("왼쪽");
        }
        if (transform.position.x < LookatTarget.transform.position.x)
        {
            right = true;
            left = false;
            Debug.Log("오른쪽");
        }
    }

    bool GetLeft()
    {
        return left;
    }
    bool GetRight()
    {
        return right;
    }
}
