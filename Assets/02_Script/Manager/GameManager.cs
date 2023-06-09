using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [Header("Component & Object")]
    PlayerMove playerMove;
    PlayerAtack playerAtack;
    CameraShake shakeCamera;
    Slider slider;
    UIController ui;
    UIChoice uiChoice;
    SpawnerDirectEnemy spawnerDirect;
    SpawnerSignEnemy spawnerSign;
    GameObject gameStartButton;
    public EnemyBoss boss;




    [Header("Player Information")]
    int playerHeart = 3;
    public int playerHeartMax = 3;
    int score = 0;

    int bulletMaxNum = 4;
    int currentBulletNum = 4;

    public bool damageDoubleCheck = false;
    bool bulletSpeedDouble = false;
    bool isGaming = false;


    [Header("Stage Information")]
    int stage = 1;
    int stageMax = 3;
    float prograssValue = 0.1f;

    public int stage1Quantity = 10;
    public int stage2Quantity = 15;

    float clearTime;



    private void Start()
    {
        clearTime = Time.time;
    }


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
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
        bulletMaxNum = 4;

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


    //--------------------------------    스테이지 진행관련   --------------------------------
    //--------------------------------    스테이지 진행관련   --------------------------------
    public void CurrentStageStart()
    {
        isGaming = true;
        stage += 1;
        slider.value = 0;
        playerHeart = playerHeartMax;

        //Debug.Log($"{stage} start");

        switch (stage)
        {
            case 1:
                //Debug.Log("Case 1");
                prograssValue = (1.0f / stage1Quantity);
                spawnerDirect.StartSpawn();
                break;
            case 2:
                //Debug.Log("Case 2");
                prograssValue = (1.0f / stage2Quantity);
                spawnerDirect.StartSpawn();
                spawnerSign.StartSpawn();
                break;
            case 3:
                //Debug.Log("Case 3");
                slider.value = 1;

                GameObject obj = Instantiate(boss.gameObject);
                obj.GetComponent<EnemyBoss>().BossDied += GameClear;
                prograssValue = 1.0f / boss.BossHP;
                break;
            default:
                //Debug.Log("Case Default");
                prograssValue = 0.1f;
                break;
        }
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
        yield return new WaitForSeconds(1.5f);
        while (slider.value > 0)
        {
            slider.value -= 0.01f;
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        playerAtack.PlayerAtackInputUnConnect();
        playerMove.PlayerMoveInputUnConnect();
        playerMove.PlayerMoveReset();

        uiChoice.transform.parent.gameObject.SetActive(true);
    }

    public void BossDefeat()
    {
        isGaming = false;
    }
    void GameClear()
    {
        isGaming= false;
        ScoreUp(100);
        Debug.Log("Game Clear! Save Start");

        clearTime = Time.time-clearTime;

        StartCoroutine(ui.EndingPanelStart());
        //saveData.score = score;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);

    }
    //--------------------------------    UI           관련   --------------------------------

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
        if(currentBulletNum< bulletMaxNum)
        {
            currentBulletNum++;
            ui.BulletUpdate(currentBulletNum);
        }
    }
    public void PrograssUp()
    {
        //Stage3 보스스테이지의 경우,,, 진행도가 보스의 체력이 되도록...조절해야함!!
        if(stage<3)
        {
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
        //보스스테이지!
        else
        {
            //Debug.Log(boss.BossHP);
            if (slider.value>0 && isGaming)
            {
                slider.value -= prograssValue;
            }
        }
    }
    //--------------------------------    UI           관련   --------------------------------

    //--------------------------------UI로부터 PlayerAbility 선택시, 게임에 반영되게 하고자 할 함수들----------------------------------------
    public void AbilityDamage1dot5Up()
    {
        // 풀의 개체들이 비활상태여서 적용이 안되는 문제가 발생함.  -> 해결

        //Debug.Log("AbilityDamage1dot5Up");
        damageDoubleCheck = true;

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
        
        // 총알스피드 2배가 이미 적용된 상태에서 새로 총알 생성할경우, 마저 총알 스피드가 2배가 되게끔 하는 코드.
        if(bulletSpeedDouble)
        {
            PlayerBullet[] playerBullet = bulletPool.GetComponentsInChildren<PlayerBullet>(true);
            foreach (PlayerBullet e in playerBullet)
            {
                e.AbilityBulletSpeedDouble();
            }

        }

        //\UI에도 반영
    }
    public void AbilityMoveSpeed1dot5up()
    {
        playerMove.AbilityMoveSpeed1dot5up();
    }
    public void AbilityBulletSpeedDouble()
    {
        bulletSpeedDouble=true;
        BulletPool bulletPool = FindObjectOfType<BulletPool>();
        PlayerBullet[] playerBullet = bulletPool.GetComponentsInChildren<PlayerBullet>(true);
        foreach(PlayerBullet e in playerBullet)
        {
            e.AbilityBulletSpeedDouble();
        }
    }


    //------------플레이어 행동 제어
    public void PlayerBehaviorEnable()
    {
        playerMove.PlayerMoveInputConnect();
        playerAtack.PlayerAtackInputConnect();
    }
    public void PlayerBehaviorDisable()
    {
        playerMove.PlayerMoveInputUnConnect();
        playerAtack.PlayerAtackInputUnConnect();
    }
}
