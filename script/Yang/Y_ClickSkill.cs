using UnityEngine;
using System.Collections;

public class Y_ClickSkill : MonoBehaviour {

    private J_UnityChan_Move playerMove;
    private GameObject playerObject;

    private Vector3 mouseWorld;
    public float nextDemage;

    public int damage;
    public float demageRate;
    // Use this for initialization
    void Start () {
        playerObject = GameObject.FindWithTag("Player");
        playerMove = playerObject.GetComponent<J_UnityChan_Move>();

        mouseWorld = playerMove.GetworldPos();

        transform.position = mouseWorld;
        Debug.Log(mouseWorld);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Magic" || other.tag =="Meteo")
        {

        }
        else if (other.tag == "Monster")
        {
            Y_MonsterCtrl monster = other.gameObject.GetComponent<Y_MonsterCtrl>();

            if (Time.time > nextDemage)
            {
                nextDemage = Time.time + demageRate;
                monster.hp -= damage;
            }
        }
        //else if(other.tag == "Terrain")
        //{
        //   Destroy(gameObject);
        //}

    }

}
