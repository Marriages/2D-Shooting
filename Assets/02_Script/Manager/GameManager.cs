using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    PlayerMove playerMove;
    PlayerAtack playerAtack;
    CameraShake shakeCamera;

    int playerHeart = 3;
    public int playerHeartMax = 3;
    int score = 0;
    int stage = 1;
    int stageMax = 3;
    Slider slider;
    UIController ui;
    int currentBulletNum = 8;
    int bulletMaxNum = 8;
    float prograssValue = 0.1f;
    public int BulletMaxNum { get => bulletMaxNum; }
    UIChoice uiChoice;
    SpawnerDirectEnemy spawnerDirect;
    SpawnerSignEnemy spawnerSign;

    public int stage1Quantity = 10;
    public int stage2Quantity = 15;




    GameObject gameStartButton;

    bool isGaming = false;

    private void Awake()
    {
        instance = this;
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
        playerMove = FindObjectOfType<PlayerMove>();
        playerAtack = FindObjectOfType<PlayerAtack>();
        slider = FindObjectOfType<PrograssSlider>().GetComponent<Slider>();
        ui = FindObjectOfType<UIController>();
        spawnerDirect = FindObjectOfType<SpawnerDirectEnemy>();
        spawnerSign = FindObjectOfType<SpawnerSignEnemy>();
        gameStartButton = transform.GetChild(0).gameObject;
        uiChoice = FindObjectOfType<UIChoice>();
        shakeCamera = FindObjectOfType<CameraShake>();
    }
    void ConnectDelegate()
    {
        playerMove.PlayerHit += PlayerHeartMinus;
        playerMove.PlayerDie += UIPlayerDieSetting;
    }
    void UIPlayerDieSetting()
    {
        ui.PlayerDieSetting();
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
        switch(stage)
        {
            case 1:
                Debug.Log("Case 1");
                prograssValue = (1.0f / stage1Quantity);
                break;
            case 2:
                Debug.Log("Case 2");
                prograssValue = (1.0f / stage2Quantity);
                break;
            case 3:
                Debug.Log("Case 3");
                prograssValue = 1;
                break;
            default:
                Debug.Log("Case Default");
                prograssValue = 0.1f;
                break;
        }
        spawnerDirect.StartSpawn();
        spawnerSign.StartSpawn();
        UISetting();
    }
    public void NextStageReady()
    {
        playerAtack.PlayerAtackInputConnect();
        playerMove.PlayerMoveInputConnect();
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
        playerAtack.PlayerAtackInputUnConnect();
        playerMove.PlayerMoveInputUnConnect();
        playerMove.PlayerMoveReset();
        playerMove.transform.position = Vector3.zero;
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
            shakeCamera.ShakeCamera();
            if (playerHeart < 1)
            {
                AudioManager.instance.AudioBackOff();
                playerMove.PlayerDieEffect();
            }
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
        //Stage3 보스스테이지의 경우,,, 진행도가 보스의 체력이 되도록...조절해야함!!
        if(slider.value<1 && isGaming)
        {
            slider.value += prograssValue;

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

        ui.BulletSetting(bulletMaxNum);
        //Debug.Log(signEnemy.Length);
    }
    public void AbilityBulletDouble()
    {
        PlayerAtack playerAtack = FindObjectOfType<PlayerAtack>();
        playerAtack.AbilityBulletDouble();
    }
    public void AbilityBulletCapacityDouble()
    {
        int x = bulletMaxNum;
        
        BulletPool bulletPool = FindObjectOfType<BulletPool>();
        bulletPool.ExtendPool(x);

        currentBulletNum += bulletMaxNum;
        bulletMaxNum *= 2;
        
        // 와나이거때문에 이상한친구들도 속도가 두배가되버리는 마 법

        PlayerBullet[] playerBullet = bulletPool.GetComponentsInChildren<PlayerBullet>(true);
        foreach (PlayerBullet e in playerBullet)
        {
            e.AbilityBulletSpeedDouble();
        }

        //\UI에도 반영
    }
    public void AbilityMoveSpeed1dot5up()
    {
        playerMove.AbilityMoveSpeed1dot5up();
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
