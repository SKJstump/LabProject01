using UnityEngine;
using System.Collections;

public class S_ShootCostRecover : MonoBehaviour {

    //public GameObject mouse;
    private J_UnityChan_Move playerMove;
    private GameObject playerObject;
    public float speed;

    public GameObject destroyEffect;

    private Vector3 pos;
    public int damage;
    public float destroyTime;
    public float mpCostRecoverAmount = 5;
    public float monsterCostRecoverAmount = 5;

    private float startTime;
    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerMove = playerObject.GetComponent<J_UnityChan_Move>();
        //Debug.Log("구체생성");

        transform.LookAt(new Vector3(playerMove.GetworldPos().x, playerMove.GetworldPos().y, playerObject.transform.position.z));
        transform.Rotate(new Vector3(0, 180, 0));
        pos = -Vector3.forward;
        pos = transform.TransformDirection(pos);

        startTime = Time.time;
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    void Update()
    {
        transform.localPosition += pos * speed * Time.deltaTime;
        if (destroyTime - 0.1f < Time.time - startTime)
        {
            startTime = Time.time;
            Instantiate(destroyEffect, this.transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Magic")
        {

        }
        else if (other.tag == "Monster")
        {
            Y_HP monster = other.gameObject.GetComponent<Y_HP>();

            playerMove.monsterCost += monsterCostRecoverAmount;
            playerMove.Mp += mpCostRecoverAmount;
            Debug.Log(playerMove.monsterCost);
            monster.hp -= damage;

            Destroy(this.gameObject);
            Instantiate(destroyEffect, this.transform.position, Quaternion.identity);
        }
        else
        {
            Destroy(this.gameObject);
            Instantiate(destroyEffect, this.transform.position, Quaternion.identity);
        }
    }
}
