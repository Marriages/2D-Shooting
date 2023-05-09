using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    PlayerMove player;

    int playerHeart = 3;
    public int PlayerHerat { get => playerHeart; }

    public int playerHeartMax = 3;

    int score = 0;
    public int Score { get => score; }

    int stage = 1;
    public int Stage { get => stage; }

    int stageMax = 3;
    float prograss = 0;
    Slider slider;
    UIController ui;
    int currentBulletNum = 8;
    int bulletMaxNum = 8;
    public int BulletMaxNum { get => bulletMaxNum; }
    UIChoice uiChoice;
    SpawnerDirectEnemy spawnerDirect;
    SpawnerSignEnemy spawnerSign;



    GameObject gameStartButton;

    bool isGaming = false;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        FindComponent();
        ConnectDelegate();
        PreInitialize();
        UISetting();
    }
    void FindComponent()
    {
        player = FindObjectOfType<PlayerMove>();
        slider = FindObjectOfType<PrograssSlider>().GetComponent<Slider>();
        ui = FindObjectOfType<UIController>();
        spawnerDirect = FindObjectOfType<SpawnerDirectEnemy>();
        spawnerSign = FindObjectOfType<SpawnerSignEnemy>();
        gameStartButton = transform.GetChild(0).gameObject;
        uiChoice = FindObjectOfType<UIChoice>();
    }
    void ConnectDelegate()
    {
        player.PlayerHit += PlayerHeartMinus;
    }
    void PreInitialize()
    {
        stage = 0;
        score = 0;
        playerHeart = playerHeartMax;
        slider.value = 0;
        bulletMaxNum = 8;

        isGaming = false;
        gameStartButton.SetActive(true);
    }
    void UISetting()
    {
        uiChoice.transform.parent.gameObject.SetActive(false);
        ui.HeartSetting(playerHeart);
        ui.ScoreSetting(score);
        ui.StageSetting(stage);
        ui.BulletSetting(bulletMaxNum);
    }
    //게임이 처음 시작될때 또는 스테이지 재시작 때 초기화를 위해 사용됨.
    //매 스테이지마다 갱신용으로 사용됨.

    public void CurrentStageStart()
    {
        isGaming = true;
        stage += 1;
        slider.value = 0;
        playerHeart = playerHeartMax;
        spawnerDirect.StartSpawn();
        spawnerSign.StartSpawn();
        UISetting();
    }
    public void NextStageReady()
    {
        uiChoice.transform.parent.gameObject.SetActive(false);
        gameStartButton?.SetActive(true);
    }
    void NextStageChange()
    {
        isGaming = false;
        spawnerDirect.StopSpawn();
        spawnerSign.StopSpawn();
        StartCoroutine(SliderValueDecreaseEffect());
    }
    IEnumerator SliderValueDecreaseEffect()
    {
        yield return new WaitForSeconds(1f);
        while(slider.value>0)
        {
            slider.value -= 0.01f;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        uiChoice.transform.parent.gameObject.SetActive(true);
    }

    public void ScoreUp(int value)
    {
        score += value;
        ui.ScoreUpdate(score);
    }
    void PlayerHeartMinus()
    {
        if(playerHeart>0 && isGaming)
        { 
            playerHeart--;
            ui.HeartUpdate(playerHeart);
            if (playerHeart < 1)
                Debug.Log("Player Die");
                //플레이어가 죽을때 실행될 코드 작성하기.
        }
    }
    //총알사용됨
    public void BulletDecrease()
    {
        if(currentBulletNum>0)
        {
            currentBulletNum--;
            ui.BulletUpdate(currentBulletNum);
        }
    }
    //총알회수
    public void BulletIncrease()
    {
        if(currentBulletNum<BulletMaxNum)
        {
            currentBulletNum++;
            ui.BulletUpdate(currentBulletNum);
        }
    }
    public void PrograssUp()
    {
        if(slider.value<1 && isGaming)
        {
            slider.value += 0.1f;
            if(slider.value>=1)
            {
                Debug.Log("Next Stage~");
                NextStageChange();
            }
        }
        
    }

    //--------------------------------UI로부터 PlayerAbility 선택시, 게임에 반영되게 하고자 할 함수들----------------------------------------
    public void AbilityDamage1dot5Up()
    {
        // 풀의 개체들이 비활상태여서 적용이 안되는 문제가 발생함.

        Debug.Log("AbilityDamage1dot5Up");

        DirectEnemyPool directEnemyPool = FindObjectOfType<DirectEnemyPool>();
        DirectEnemy[] directEnemy = directEnemyPool.transform.GetComponentsInChildren<DirectEnemy>(true);
        foreach (DirectEnemy e in directEnemy)
            e.AbilityDamage1dot5Up();

        //Debug.Log(directEnemy.Length);

        SignEnemyPool signEnemyPool = FindObjectOfType<SignEnemyPool>();
        SignEnemy[] signEnemy = signEnemyPool.transform.GetComponentsInChildren<SignEnemy>(true);
        foreach(SignEnemy e in signEnemy)
            e.AbilityDamage1dot5Up();

        //Debug.Log(signEnemy.Length);
    }
    public void AbilityBulletDouble()
    {
        PlayerAtack playerAtack = FindObjectOfType<PlayerAtack>();
        playerAtack.AbilityBulletDouble();
    }
    public void AbilityBulletCapacityDouble()
    {
        bulletMaxNum *= 2;
        //Pool에서 현재 가진 2배만큼 총알을 늘려야되는데 개 귀 찮 네
    }
    public void AbilityMoveSpeed1dot5up()
    {
        player.AbilityMoveSpeed1dot5up();
    }
    public void AbilityBulletSpeedDouble()
    {
        BulletPool bulletPool = FindObjectOfType<BulletPool>();
        PlayerBullet[] playerBullet = bulletPool.GetComponentsInChildren<PlayerBullet>(true);
        foreach(PlayerBullet e in playerBullet)
        {
            e.AbilityBulletSpeedDouble();
        }
    }

}
