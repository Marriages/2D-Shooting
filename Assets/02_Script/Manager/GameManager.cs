using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    PlayerMove player;

    int playerHeart = 3;
    public int playerHeartMax = 3;
    int score;
    int stage;
    int stageMax;
    float prograss;
    Slider slider;
    UIController ui;
    

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        PreInitialize();
        FindComponent();
        ConnectDelegate();
    }
    void FindComponent()
    {
        player = FindObjectOfType<PlayerMove>();
        slider = FindObjectOfType<PrograssSlider>().GetComponent<Slider>();
        ui = FindObjectOfType<UIController>();
    }
    void ConnectDelegate()
    {
        player.PlayerHit += PlayerHeartMinus;
    }
    //게임이 처음 시작될때 또는 스테이지 재시작 때 초기화를 위해 사용됨.
    void PreInitialize()
    {
        stage = 1;
        score = 0;
        playerHeart = playerHeartMax;
        slider.value = 0;
    }
    //매 스테이지마다 갱신용으로 사용됨.




    void Initialize()
    {
        slider.value = 0;

    }
    void ScoreUp(int value)
    {
        score += value;
    }
    void PlayerHeartMinus()
    {

    }
    //총알사용됨
    void BulletDecrease()
    {

    }
    //총알회수
    void BulletIncrease()
    {

    }
}
