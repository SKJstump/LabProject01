using UnityEngine;
using System.Collections;

public class Y_MonsterCtrl : MonoBehaviour {

    public enum MonsterState { idle , trace , attack , die};
    public MonsterState monsterState = MonsterState.idle;

    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;
    public float traceDist = 10.0f; // 추적거리(눈물이추적추적
    public float attackDist = 2.0f; // 공격거리

    public GameObject bloodEffect;
    public GameObject bloodDecal;

    private bool isDie = false;
    
    void Start () {
       
        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckMonsterState());
        StartCoroutine(this.MosterAction());

    }

    IEnumerator CheckMonsterState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTr.position, monsterTr.position);
            if(dist <= attackDist)
            {
                monsterState = MonsterState.attack;
            }
            else if (dist <= traceDist)
            {
                monsterState = MonsterState.trace;
            }
            else
            {
                monsterState = MonsterState.idle;
            }
        }
    }

    IEnumerator MosterAction()
    {
        while (!isDie)
        {
            switch (monsterState)
            {
                case MonsterState.idle:
                    nvAgent.Stop();
                    animator.SetBool("IsTrace", false);
                    break;
                case MonsterState.trace:
                    nvAgent.destination = playerTr.position ;
                    nvAgent.Resume();
                    animator.SetBool("IsAttack", false);
                    animator.SetBool("IsTrace",true);
                    break;
                case MonsterState.attack:
                    animator.SetBool("IsAttack", true);
                    break;
            }
            yield return null;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.tag == "BULLET")
        //{
        //    Destroy(collider.gameObject);       
        //}
        CreateBloodEffect(other.transform.position);
        animator.SetTrigger("IsHit");
    }

    void CreateBloodEffect(Vector3 pos)
    {
        GameObject blood1 = (GameObject)Instantiate(bloodEffect, pos, Quaternion.identity);
        Destroy(blood1, 2.0f);
    }

    void Update()
    {
        //Debug.Log(nvAgent.destination.x);
        
        //nvAgent.SetDestination(playerTr.position);
    }
}
