using UnityEngine;
using System.Collections;

public class S_UseSkill : MonoBehaviour {

    public GameObject shotpos;

    // 스킬 슬롯 한다 설정
    public GameObject[] selectSkill = new GameObject[4];

    // 어떤 스킬 선택 하는지 변수다.
    private int selskill;
    private float[] skillCooltime = new float[4];
    private TweenAlpha[] cooltimeAlpha = new TweenAlpha[4];
    void Start()
    {
        // skill 쿨타임을 처음엔 다 0으로 만들어줌.
        for (int i = 0; i < 4; ++i)
        {
            skillCooltime[i] = 0.0f;

            cooltimeAlpha[i] = selectSkill[i].GetComponent<TweenAlpha>();
            cooltimeAlpha[i].from = 0.1f;
            cooltimeAlpha[i].to = 1.0f;
            cooltimeAlpha[i].enabled = false;
        }
        // 데폴트 0 이다.
        selskill = 0;
    }

    void Update()
    {
        // 마우스 왼쪽 버튼 누르면 스킬 구른다.
        if (Input.GetMouseButtonDown(0))
        {
            useSkill(selskill);
        }
        // 수정 시작 부분은  0부터 3까지임
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selskill = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selskill = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            selskill = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            selskill = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }

    void useSkill(int skillnum)
    {
        
        
        // skillnum 역시 0부터 3까지로 바꿈
        switch (skillnum)
        {
            case 0:
                CreateSkill(skillnum);
                break;
            case 1:
                CreateSkill(skillnum);
                break;
            case 2:
                CreateSkill(skillnum);
                break;
            case 3:
                CreateSkill(skillnum);
                break;
        }
    }

    void CreateSkill(int skillnum)
    {
        // 스킬 슬롯에서 불러와 임시로 저장할 게임 오브젝트 만든다.
        GameObject instantSkill = null;
        // 스킬 슬롯에 있는 스킬 넣는다. 작동... 시킨다.
        instantSkill = selectSkill[skillnum].GetComponent<S_DropSkillToSkillSet>().skillObject;
       
        // 스킬슬롯이 비어있으면 작동 안한다.
        if (instantSkill != null)
        {
            float mCost = instantSkill.GetComponent<S_SkillCooldown>().MPCost;
            float mstCost = instantSkill.GetComponent<S_SkillCooldown>().monsterCost;

            if (GetComponent<J_UnityChan_Move>().Mp >= mCost && GetComponent<J_UnityChan_Move>().monsterCost >= mstCost)
            {
                // 스킬 슬롯에 있는 종류에 따라 쿨타임 알파를 정해준다.
                cooltimeAlpha[skillnum].duration = instantSkill.GetComponent<S_SkillCooldown>().coolTime;
                // 스킬이 쿨타임 돌고 있는지 확인한다.
                if (Time.time - skillCooltime[skillnum] > instantSkill.GetComponent<S_SkillCooldown>().coolTime)
                {
                    // 인스턴싱으로 스킬 만든다.
                    GameObject skill1 = (GameObject)Instantiate(instantSkill, shotpos.transform.position, Quaternion.identity);
                    // 코스트를 소비한다.\
                    GetComponent<J_UnityChan_Move>().Mp -= instantSkill.GetComponent<S_SkillCooldown>().MPCost;
                    GetComponent<J_UnityChan_Move>().monsterCost -= instantSkill.GetComponent<S_SkillCooldown>().monsterCost;
                    // 쿨타임이 초기화 된다.
                    skillCooltime[skillnum] = Time.time;
                    // 쿨타임 UI이다.(alpha값)
                    cooltimeAlpha[skillnum].Reset();
                    cooltimeAlpha[skillnum].enabled = true;


                }
            }
        }
    }
}
