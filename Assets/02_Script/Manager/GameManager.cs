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

    int score=0;
    public int Score { get => score; }

    int stage=1;
    public int Stage { get => stage; }

    int stageMax=3;
    float prograss=0;
    Slider slider;
    UIController ui;
    int currentBulletNum=8;
    int bulletMaxNum = 8;
    public int BulletMaxNum { get => bulletMaxNum; }

    SpawnerDirectEnemy spawnerDirect;
    SpawnerSignEnemy spawnerSign;


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

        //이친구는 나중에 버튼을 누르던 어떤걸 누르던했을떄 실행할 수 있도록...
        CurrentStageStart();
    }
    void FindComponent()
    {
        player = FindObjectOfType<PlayerMove>();
        slider = FindObjectOfType<PrograssSlider>().GetComponent<Slider>();
        ui = FindObjectOfType<UIController>();
        spawnerDirect = FindObjectOfType<SpawnerDirectEnemy>();
        spawnerSign = FindObjectOfType<SpawnerSignEnemy>();
    }
    void ConnectDelegate()
    {
        player.PlayerHit += PlayerHeartMinus;
    }
    void PreInitialize()
    {
        stage = 1;
        score = 0;
        playerHeart = playerHeartMax;
        slider.value = 0;
        bulletMaxNum = 8;

        isGaming = false;
    }
    void UISetting()
    {
        ui.HeartSetting(playerHeart);
        ui.ScoreSetting(score);
        ui.StageSetting(stage);
        ui.BulletSetting(bulletMaxNum);
    }
    //게임이 처음 시작될때 또는 스테이지 재시작 때 초기화를 위해 사용됨.
    //매 스테이지마다 갱신용으로 사용됨.

    void Initialize()
    {
        slider.value = 0;
        stage += 1;
        playerHeart = playerHeartMax;
        slider.value = 0;
        spawnerDirect.StopSpawn();
        spawnerSign.StopSpawn();
    }
    void CurrentStageStart()
    {
        isGaming = true;
        spawnerDirect.StartSpawn();
        spawnerSign.StartSpawn();
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

}