using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    TextMeshProUGUI HeartValue;
    TextMeshProUGUI StageValue;
    TextMeshProUGUI BulletValue;
    TextMeshProUGUI ScoreValue;

    GameObject gameover;
    GameObject tutorial;
    GameObject pause;
    Image endingPanel;

    InputSystemController inputAction;
    bool isOption=false;

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
        tutorial = transform.GetChild(7).gameObject;
        tutorial.SetActive(false);
        pause = transform.GetChild(8).gameObject;
        pause.SetActive(false);
        endingPanel = transform.GetChild(9).GetComponent<Image>() ;
        endingPanel.gameObject.SetActive(false);

        inputAction = new InputSystemController();
        
    }
    private void OnEnable()
    {
        UIInputConnect();
    }
    private void OnDisable()
    {
        UIInputDisconnect();
    }
    void UIInputConnect()
    {
        inputAction.UIOption.Enable();
        inputAction.UIOption.Pause.performed += PauseOption;
        inputAction.UIOption.Tuto.performed += TutoExit;
    }
    void UIInputDisconnect()
    {
        inputAction.UIOption.Tuto.performed -= TutoExit;
        inputAction.UIOption.Pause.performed -= PauseOption;
        inputAction.UIOption.Disable();
    }
    private void TutoExit(InputAction.CallbackContext _)
    {
        tutorial.SetActive(false);
        GameManager.instance.PlayerBehaviorEnable();
        inputAction.UIOption.Tuto.performed -= TutoExit;
    }
    private void Start()
    {
        //튜토리얼 창 보여주기.
        tutorial.SetActive(true);
        GameManager.instance.PlayerBehaviorDisable();
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
        inputAction.UIOption.Restart.performed += RestartGame;
        AudioManager.instance.AudioPlayerDie();
        //Debug.Log("플레이어 사망 UI 효과");
        //게임오버 이미지 보여주고 소리까지 출력하고, 랭킹 함 보여주고 이번 플레이에 대한 정보 보여주고, 타이틀 가려면 엔터 누르게 하기.
    }

    private void RestartGame(InputAction.CallbackContext _)
    {
        inputAction.UIOption.Restart.performed -= RestartGame;
        AudioManager.instance.AudioRestart(); 
        SceneManager.LoadScene(1);
    }

    private void PauseOption(InputAction.CallbackContext _)
    {
        PauseOptionSetting();
        
    }
    public void PauseOptionSetting()
    {
        isOption = !isOption;
        pause.SetActive(isOption);
        if (isOption)
        {
            Time.timeScale = 0f;
            GameManager.instance.PlayerBehaviorDisable();
            //플레이어의 애니메이션? 입력을 막는 장치가 필요해보임.
            //PlayerMove에 별도로 스크립트 추가할 것.
        }
        else
        {
            Time.timeScale = 1;
            GameManager.instance.PlayerBehaviorEnable();
        }
    }
    public IEnumerator EndingPanelStart()
    {
        endingPanel.gameObject.SetActive(true);

        GameManager.instance.PlayerBehaviorDisable();
        UIInputDisconnect();

        Color c = Color.black;
        float alphaSpeed = 0.2f;
        c.a = 0;
        while(c.a<1)
        {
            c.a += alphaSpeed * Time.deltaTime;
            endingPanel.color = c;
            yield return null;
        }
        GameManager.instance.NextScene();

    }

}
