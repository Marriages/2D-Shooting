using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    TextMeshProUGUI HeartValue;
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
        if(HeartValue == null)
            HeartValue = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        if (StageValue == null)
            StageValue = transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        if (BulletValue == null)
            BulletValue = transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
        if (ScoreValue == null)
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
        HeartValue.text = heartNum[value];
    }
    public void HeartSetting(int value)
    {
        if(HeartValue!=null)
        {
            HeartValue.text = heartNum[value];
        }
        else
        {
            HeartValue = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
            HeartValue.text = heartNum[value];
        }
    }
    public void StageUpdate(int value)
    {

    }
    public void StageSetting(int value)
    {
        if(StageValue!=null)
        {
            StageValue.text = value.ToString();
        }
        else
        {
            StageValue = transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
            StageValue.text = value.ToString();
        }

    }
    public void BulletUpdate(int value)
    {
        BulletValue.text = bulletNum[value];
    }
    public void BulletSetting(int value)
    {
        if(BulletValue!=null)
        {
            BulletValue.text = bulletNum[value];
        }
        else
        {
            BulletValue = transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
            BulletValue.text = bulletNum[value];
        }
    }
    public void ScoreUpdate(int value)
    {
        ScoreValue.text = value.ToString();
    }
    public void ScoreSetting(int value)
    {
        if (ScoreValue != null)
        {
            ScoreValue.text = value.ToString();
        }
        else
        {
            ScoreValue = transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();
            ScoreValue.text = value.ToString();
        }

    }
    public void PlayerDieSetting()
    {
        gameover.SetActive(true);
        AudioManager.instance.AudioPlayerDie();
        //Debug.Log("플레이어 사망 UI 효과");
        //게임오버 이미지 보여주고 소리까지 출력하고, 랭킹 함 보여주고 이번 플레이에 대한 정보 보여주고, 타이틀 가려면 엔터 누르게 하기.
    }

}
