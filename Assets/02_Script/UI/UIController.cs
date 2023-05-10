using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    TextMeshProUGUI heartValue;
    TextMeshProUGUI StageValue;
    TextMeshProUGUI BulletValue;
    TextMeshProUGUI ScoreValue;

    GameObject gameover;

    string[] heartNum = { "X_X", "♥", "♥♥", "♥♥♥" };
    // 0발 ~ 15발까지
    string[] bulletNum = {"Empty","o","oo","ooo","oooo","ooooo","oooooo","ooooooo",
                          "oooooooo","ooooooooo","oooooooooo","ooooooooooo",
                          "oooooooooooo","ooooooooooooo","oooooooooooooo",
                          "ooooooooooooooo","oooooooooooooooo"};

    private void Awake()
    {
        heartValue = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        StageValue = transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        BulletValue = transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
        ScoreValue = transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();
        gameover = transform.GetChild(6).gameObject;
        gameover.SetActive(false);
    }
    private void OnEnable()
    {
        //bulletNum = []; 
    }
    public void HeartUpdate(int value)
    {
        heartValue.text = heartNum[value];
    }
    public void HeartSetting(int value)
    {
        heartValue.text = heartNum[value];
    }
    public void StageUpdate(int value)
    {

    }
    public void StageSetting(int value)
    {
        StageValue.text = value.ToString();
    }
    public void BulletUpdate(int value)
    {
        BulletValue.text = bulletNum[value];
    }
    public void BulletSetting(int value)
    {
        BulletValue.text = bulletNum[value];
    }
    public void ScoreUpdate(int value)
    {
        ScoreValue.text = value.ToString();
    }
    public void ScoreSetting(int value)
    {
        ScoreValue.text = value.ToString();
    }
    public void PlayerDieSetting()
    {
        gameover.SetActive(true);
        AudioManager.instance.AudioPlayerDie();
        //Debug.Log("플레이어 사망 UI 효과");
        //게임오버 이미지 보여주고 소리까지 출력하고, 랭킹 함 보여주고 이번 플레이에 대한 정보 보여주고, 타이틀 가려면 엔터 누르게 하기.
    }

}
