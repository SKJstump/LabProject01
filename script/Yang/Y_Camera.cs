using UnityEngine;
using System.Collections;

public class Y_Camera : MonoBehaviour
{

    public float cameraYPos;
    public GameObject playerCtrl;
    public float xfallowSpeed , yfallowSpeed;
    // Use this for initialization
    void Start()
    {
        //GameObject playerCtrlObject = GameObject.FindWithTag("Man");
        //playerCtrl = playerCtrlObject.GetComponent<PlayerCtrl>();
    }

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        x = Mathf.Lerp(x, playerCtrl.transform.position.x, Time.deltaTime* xfallowSpeed);
        y = Mathf.Lerp(y, playerCtrl.transform.position.y + cameraYPos, Time.deltaTime* yfallowSpeed);
        transform.position = new Vector3(x, y, transform.position.z);
    }

}
