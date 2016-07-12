using UnityEngine;
using System.Collections;

public class _ShowMouse : MonoBehaviour
{
    public GameObject target;
    public bool left;
    public bool right;
    private float rotationY = 0;
    void Update()
    {

        //Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
        //if (target.transform.position.x > transform.position.x)
        //{
        //    transform.localEulerAngles = new Vector3(0, 90, 0);
        //    left = false;
        //    right = true;
        //}
        //else if (target.transform.position.x < transform.position.x)
        //{
        //    transform.localEulerAngles = new Vector3(0, 270, 0);
        //    right = false;
        //    left = true;
        //}

        //Vector3 Mouse = Input.mousePosition;
        //Vector3 pos = Camera.main.ScreenToWorldPoint(Mouse);

        // transform.LookAt(pos);

        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X");

        rotationY += Input.GetAxis("Mouse Y");
        //rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
        if (target.transform.position.x > transform.position.x)
        {
            transform.localEulerAngles = new Vector3(-rotationY, 90, 0);
            left = false;
            right = true;
        }
        else if (target.transform.position.x < transform.position.x)
        {
            transform.localEulerAngles = new Vector3(-rotationY, 270, 0);
            right = false;
            left = true;
        }

    }
}
