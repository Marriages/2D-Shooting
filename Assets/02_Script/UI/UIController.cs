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

}
