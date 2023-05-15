using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TitleUIController : MonoBehaviour
{
    TextMeshProUGUI gameNameText;
    Button gameStartButton;
    Button optionButton;
    Button rankingButton;
    Image clickDefender;
    Button backMenu;

    GameObject optionMenu;
    //GameObject rankingMenu;

    public Action PlayerGameStart;

    private void Awake()
    {
        clickDefender = transform.GetChild(0).GetComponent<Image>();
        gameNameText=transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        gameStartButton = transform.GetChild(1).GetChild(1).GetComponent<Button>();
        optionButton = transform.GetChild(1).GetChild(2).GetComponent<Button>();
        //rankingButton = transform.GetChild(1).GetChild(3).GetComponent<Button>();
        backMenu = clickDefender.transform.GetChild(0).GetComponent<Button>();

        optionMenu = transform.GetChild(2).gameObject;
        optionMenu.SetActive(false);
        //rankingMenu = transform.GetChild(3).gameObject;
        //rankingMenu.SetActive(false);
    }
    // 마우스를 활성화시킬까 말까...

    private void OnEnable()
    {
        gameStartButton.onClick.AddListener(GameStart);
        optionButton.onClick.AddListener(Option);
        clickDefender.gameObject.SetActive(false);
        backMenu.onClick.AddListener(BackMenu);
        backMenu.gameObject.SetActive(false);
    }







    
    
    void GameStart()
    {
        PlayerGameStart?.Invoke();

        gameNameText.gameObject.SetActive(false);
        gameStartButton.gameObject.SetActive(false);
        optionButton.gameObject.SetActive(false);
        //rankingButton.gameObject.SetActive(false);
    }
    void Option()
    {
        StartCoroutine(OptionStart());
    }
    void Ranking()
    {
    }
    //UI들이 사라지게 하는? 클릭을 막아야해
    IEnumerator OptionStart()
    {
        clickDefender.gameObject.SetActive(true);
        Color c = Color.black;
        c.a = 0;
        while (c.a < 0.5f)
        {
            clickDefender.color = c;
            c.a += Time.deltaTime;
            yield return null;
        }
        gameNameText.gameObject.SetActive(false);
        backMenu.gameObject.SetActive(true);
        gameStartButton.gameObject.SetActive(false);
        optionButton.gameObject.SetActive(false);
        //rankingButton.gameObject.SetActive(false);

        optionMenu.SetActive(true);
    }

    void BackMenu()
    {
        StartCoroutine(BackMenuStart());
    }
    IEnumerator BackMenuStart()
    {
        backMenu.gameObject.SetActive(false);

        Color c = Color.black;
        c.a = 0.5f;
        while (c.a > 0f)
        {
            clickDefender.color = c;
            c.a -= Time.deltaTime;
            yield return null;
        }
        gameNameText.gameObject.SetActive(true);
        gameStartButton.gameObject.SetActive(true);
        optionButton.gameObject.SetActive(true);
        //rankingButton.gameObject.SetActive(true);
        clickDefender.gameObject.SetActive(false);

        optionMenu.SetActive(false);
        //rankingMenu.SetActive(false);
    }


}

