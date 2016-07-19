using UnityEngine;
using System.Collections;

public class S_UseSkill : MonoBehaviour {

    public GameObject shotpos;

    public GameObject selectSkill_1;
    public GameObject selectSkill_2;
    public GameObject selectSkill_3;
    public GameObject selectSkill_4;

    private int selskill;

    //private GameObject skill1; 

    void Start()
    {
        //skill1.transform.LookAt(  );
        selskill = 1;
        //skill1.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            useSkill(selskill);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selskill = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selskill = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            selskill = 3;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            selskill = 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }

    void useSkill(int skillnum)
    {
        //1번을 누를 시 ui 1번의 스킬오브젝트 정보를 갖고와서 뿌릴 수 있게
        //지금은 ui 구현이 안됬으므로 수동으로한다

        GameObject instantSkill = null;
        switch (skillnum)
        {
            case 1:
                instantSkill = selectSkill_1.GetComponent<S_DropSkillToSkillSet>().skillObject;
                if (instantSkill != null)
                {
                    GameObject skill1 = (GameObject)Instantiate(instantSkill, shotpos.transform.position, Quaternion.identity);
                }
                //Destroy(skill1, 10.0f);  
                break;
            case 2:
                instantSkill = selectSkill_2.GetComponent<S_DropSkillToSkillSet>().skillObject;
                if (instantSkill != null)
                {
                    GameObject skill2 = (GameObject)Instantiate(instantSkill, shotpos.transform.position, Quaternion.identity);
                }
                //Destroy(skill2, 3.0f);
                break;
            case 3:
                instantSkill = selectSkill_3.GetComponent<S_DropSkillToSkillSet>().skillObject;
                if (instantSkill != null)
                {
                    GameObject skill3 = (GameObject)Instantiate(instantSkill, shotpos.transform.position, Quaternion.identity);
                }
                break;
            case 4:
                instantSkill = selectSkill_4.GetComponent<S_DropSkillToSkillSet>().skillObject;
                if (instantSkill != null)
                {
                    GameObject skill4 = (GameObject)Instantiate(instantSkill, shotpos.transform.position, Quaternion.identity);
                }
                //Destroy(skill4, 3.0f);
                break;
        }
    }

}
