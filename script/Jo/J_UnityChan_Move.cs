using UnityEngine;
using System.Collections;

public class J_UnityChan_Move : MonoBehaviour {

    public float ForwardSpeed;
    public float BackwardSpeed;
    public float JumpPower;

    private Vector3 velocity;
    private Vector3 m_Lookat;
    private Rigidbody rb;
    private Animator anim;

    private bool right = false;
    private bool left = false;
    private bool jump = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal"); // a키와 d키를 받는다.

        velocity = Vector3.forward;
        velocity = transform.TransformDirection(velocity);

        if (right) // 플레이어가 오른쪽을 보고있는다
        {
            if (h > 0.1)
            {
                anim.SetFloat("Speed", h);
                velocity *= ForwardSpeed;
            }
            else if (h < -0.1)
            {
                anim.SetFloat("Speed", h);
                velocity *= -BackwardSpeed;
            }
            else
            {
                anim.SetFloat("Speed", h);
            }
        }
        else if (left) // 플레이어가 왼쪽을 보고있는다.
        {
            if (h > 0.1)
            {
                anim.SetFloat("Speed", -h);
                velocity *= -BackwardSpeed;
            }
            else if (h < -0.1)
            {
                anim.SetFloat("Speed", -h);
                velocity *= ForwardSpeed;
            }
            else
            {
                anim.SetFloat("Speed", h);
            }
        }

        if (Input.GetButtonDown("Jump") ) // 점프 키를 눌렀을 때
        {
            jump = true;
            rb.AddForce(0, JumpPower, 0, ForceMode.VelocityChange);
        }

        transform.localPosition += velocity * Time.deltaTime * h * h; // 플레이어를 이동시킨다.
    }

    void FixedUpdate()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z-Camera.main.transform.position.z));
       // Vector3 Screen_playerPos = Camera.main.WorldToScreenPoint(transform.position);
        m_Lookat = new Vector3(worldPos.x, transform.position.y, transform.position.z);
      

        transform.LookAt(m_Lookat);

        Mouse_Position(m_Lookat); // 주인공이 바라보는 방향을 저장한다.
    }

    void Mouse_Position(Vector3 other) // 마우스가 플레이어의 왼쪽에 있는지 오른쪽에 있는지 판별한다.
    {
        if (transform.position.x > m_Lookat.x)
        {
            left = true;
            right = false;
        }
        if (transform.position.x < m_Lookat.x)
        {
            right = true;
            left = false;
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
