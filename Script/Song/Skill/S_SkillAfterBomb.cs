using UnityEngine;
using System.Collections;

public class S_SkillAfterBomb : MonoBehaviour
{
    private GameObject playerObject;
    private Light light;
    private bool isLight = false;
    private float startTime;
    

    //public float nextDemage;

    public int damage;
    // 어느정도 시간이 지나야 터질 것인가.
    public float bombTime;
    public GameObject bloodEffect;

    // Use this for initialization
    void Start()
    {
        light = gameObject.GetComponentInChildren<Light>();

        startTime = Time.time;
        Destroy(gameObject, bombTime);
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

            if (Time.time - startTime > bombTime)
            {
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
