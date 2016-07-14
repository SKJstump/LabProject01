using UnityEngine;
using System.Collections;

public class Y_UseSkill : MonoBehaviour {

    public GameObject shotpos;

    public GameObject energyBlast;
    public GameObject erekiball2;
    public GameObject meteorSwarm;

    private int selskill;

    //private GameObject skill1; 

    void Start () {
        //skill1.transform.LookAt(  );
        selskill = 1;
        //skill1.SetActive(false);
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            selskill = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selskill = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            selskill = 3;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            selskill = 4;   
        if(Input.GetMouseButtonDown(0))
        {
            useSkill(selskill);
        }
    }

    void useSkill(int skillnum)
    {
       //1번을 누를 시 ui 1번의 스킬오브젝트 정보를 갖고와서 뿌릴 수 있게
       //지금은 ui 구현이 안됬으므로 수동으로한다
       
       switch (skillnum)
       {
            case 1:
                GameObject skill1 = (GameObject)Instantiate(erekiball2, shotpos.transform.position, Quaternion.identity);
                Destroy(skill1, 10.0f);  
                break;
            case 2:
                GameObject skill2 = (GameObject)Instantiate(energyBlast, shotpos.transform.position, Quaternion.identity);
                Destroy(skill2, 3.0f);
                break;
            case 4:
                
                GameObject skill4 = (GameObject)Instantiate(meteorSwarm, shotpos.transform.position, Quaternion.identity);
                //Destroy(skill4, 3.0f);
                break;
        }
    }

}
