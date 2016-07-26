using UnityEngine;
using System.Collections;

public class S_Y_ClickSkill : MonoBehaviour {
    private J_UnityChan_Move playerMove;
    private GameObject playerObject;
    private Light light;
    private Vector3 mouseWorld;
    private bool isLight = false;
    private float startTime;
    

    //public float nextDemage;

    public int damage;
    public float demageRate;
    public float destroyTime = 3.0f;

    public GameObject bloodEffect;

    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerMove = playerObject.GetComponent<J_UnityChan_Move>();
        light = gameObject.GetComponentInChildren<Light>();

        mouseWorld = playerMove.GetworldPos();
        startTime = Time.time;

        transform.position = mouseWorld;
        Destroy(gameObject, destroyTime);
        //   Debug.Log(mouseWorld);
    }

    // Update is called once per frame
    void Update()
    {
        if (light)
        {
            light.intensity = Mathf.Lerp(light.intensity, 0, 0.01f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Monster")
        {
            Y_HP monster = other.gameObject.GetComponent<Y_HP>();

            if (startTime < Time.time - demageRate)
            {
                startTime = Time.time;

                monster.hp -= damage;
                CreateBloodEffect(other.transform.position);
            }
        }
    }

    void CreateBloodEffect(Vector3 pos)
    {
        GameObject blood1 = (GameObject)Instantiate(bloodEffect, pos, Quaternion.identity);
        Destroy(blood1, 0.35f);
    }
}
