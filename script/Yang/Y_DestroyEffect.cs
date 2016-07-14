using UnityEngine;
using System.Collections;

public class Y_DestroyEffect : MonoBehaviour {

    // Use this for initialization
    public float effectTime;
	void Start () {
        Destroy(gameObject, effectTime);
    }
	

}
