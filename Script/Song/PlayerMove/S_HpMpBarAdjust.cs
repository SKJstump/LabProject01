using UnityEngine;
using System.Collections;

public class S_HpMpBarAdjust : MonoBehaviour {
    // fill값을 조절하여 피깍이는 UI 만듦
    public UISprite mpBar;
    public UISprite hpBar;
    public UISprite monsterCostBar;

    // player의 hp mp 등등을 받아온다.
    private J_UnityChan_Move playerState;
    private float preHp;
    private float preMp;
    private float preMonsterCost;

	void Start () {
        playerState = GetComponent<J_UnityChan_Move>();

        preHp = playerState.Hp;
        preMp = playerState.Mp;
        preMonsterCost = playerState.monsterCost;
	}

    //int A = Mathf.Lerp(A, max, Time.deltaTime);

	void Update () {
        // 부드럽게 하기 위한 러프
        preHp = Mathf.Lerp(preHp, playerState.Hp, Time.deltaTime);
        preMp = Mathf.Lerp(preMp, playerState.Mp, Time.deltaTime);
        preMonsterCost = Mathf.Lerp(preMonsterCost, playerState.monsterCost, Time.deltaTime);

        mpBar.fillAmount = preHp / playerState.GetMaxHp();
        hpBar.fillAmount = preMp / playerState.GetMaxMp();
        monsterCostBar.fillAmount = preMonsterCost / playerState.GetMaxMonsterCost();

	}
}
