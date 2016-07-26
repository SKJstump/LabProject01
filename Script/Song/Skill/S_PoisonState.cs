using UnityEngine;
using System.Collections;

public class S_PoisonState : MonoBehaviour {

	void Start () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Monster")
        {
            other.GetComponent<Y_HP>().SetPoison(true);
            other.GetComponent<Y_HP>().SetPoisonTime(Time.time);
            //Debug.Log("으악 독이닼!");
        }
    }


}
