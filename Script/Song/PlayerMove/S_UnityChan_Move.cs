using UnityEngine;
using System.Collections;

public class S_UnityChan_Move : MonoBehaviour
{
    public float ForwardSpeed;
    public float BackwardSpeed;
    public float JumpPower;
    // 두번 클릭 사이의 시간 값을 정한다. 값이 클수록 천천히 두번 눌러도 대쉬가 된다.
    public float clickTime;

    private bool right = false;
    private bool left = false;
    private bool jump = false;
    // 대쉬 입력 시간을 위한 변수
    private float dashTime = 0.0f;
    private float backdashTime = 0.0f;
    // 대쉬를 위한 카운트 
    private int dashCount = 0;
    private int backdashCount = 0;
    // 두번 입력 제한 시간
    private Vector3 velocity;
    private Vector3 m_Lookat;
    private Vector3 worldPos;
    private Rigidbody rb;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // a키와 d키를 받는다.

        velocity = Vector3.forward;
        velocity = transform.TransformDirection(velocity);

        if (right) // 플레이어가 오른쪽을 보고있는다
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                //Debug.Log("D 눌림");
                backdashCount = 0;
                ForwardDash();
            }
            if(Input.GetKeyUp(KeyCode.D))
            {
                //Debug.Log("D 때짐");
                if (Time.time - dashTime > clickTime && dashCount != 0)
                {
                    dashCount = 0;
                }
            }
           

            if (Input.GetKeyDown(KeyCode.A))
            {
                dashCount = 0;
                BackDash();
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                if (Time.time - backdashTime > clickTime && backdashCount != 0)
                {
                    backdashCount = 0;
                }
            }
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                backdashCount = 0;
                ForwardDash();
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                //Debug.Log("D 때짐");
                if (Time.time - dashTime > 1.0f && dashCount != 0)
                {
                    dashCount = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                dashCount = 0;
                BackDash();
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                if (Time.time - backdashTime > 1.0f && backdashCount != 0)
                {
                    backdashCount = 0;
                }
            }

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

        if (Input.GetButtonDown("Jump") && jump == false) // 점프 키를 눌렀을 때
        {
            jump = true;
            rb.AddForce(0, JumpPower, 0, ForceMode.VelocityChange);
        }

        transform.localPosition += velocity * Time.deltaTime * h * h; // 플레이어를 이동시킨다.
    }

    void FixedUpdate()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z));
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
    public Vector3 GetLookAt()
    {
        return m_Lookat;
    }
    public Vector3 GetworldPos()
    {
        return worldPos;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            jump = false;
            //Debug.Log("충돌했쪄염 뿌잉");
        }
    }

    void ForwardDash()
    {
        if (dashCount == 0)
        {
            // 대쉬 처음 시간 입력
            dashTime = Time.time;
            // 대쉬 카운터 증가
            dashCount++;
        }
        else if (Time.time - dashTime < clickTime)   // 0.7초 이내에 한번 더 입력하면 대쉬 작동.
        {
            Debug.Log(dashCount);
            transform.localPosition += velocity * Time.deltaTime * 50; // 플레이어를 이동시킨다.
            //rb.AddRelativeForce(0, 5, 0, ForceMode.VelocityChange);
            dashCount = 0;
        }
        else
        {
            Debug.Log(" 시간 초과!");
            dashCount = 0;
        }
    }

    void BackDash()
    {
        if (backdashCount == 0)
        {
            // 대쉬 처음 시간 입력
            backdashTime = Time.time;
            // 대쉬 카운터 증가
            backdashCount++;
        }
        else if (Time.time - backdashTime < clickTime)   // 0.7초 이내에 한번 더 입력하면 대쉬 작동.
        {
            Debug.Log("백 대쉬!");
            transform.localPosition -= velocity * Time.deltaTime * 25; // 플레이어를 이동시킨다.
            //rb.AddRelativeForce(velocity * 5, ForceMode.VelocityChange);
            backdashCount = 0;
        }
        else
        {
            Debug.Log("백 시간 초과!");
            backdashCount = 0;
        }
    }
}
