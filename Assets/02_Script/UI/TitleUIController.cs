using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleUIController : MonoBehaviour
{
    TextMeshProUGUI gameNameText;
    Button gameStartButton;
    Button optionButton;
    Button rankingButton;

    private void Awake()
    {
        gameNameText=transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        gameStartButton = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        optionButton = transform.GetChild(0).GetChild(2).GetComponent<Button>();
        rankingButton = transform.GetChild(0).GetChild(3).GetComponent<Button>();
    }
    // 마우스를 활성화시킬까 말까...
    

    private void OnEnable()
    {
        
    }


}

