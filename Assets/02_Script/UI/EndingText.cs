using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingText : MonoBehaviour
{
    public string[] endingTexts;
    TextMeshProUGUI endingText;
    int endingTextIndex = 0;
    Color textAlpha;
    public float textSpeed = 0.2f;

    private void Awake()
    {
        endingText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    { 
        endingTextIndex=0;
        textAlpha = Color.white;
        textAlpha.a = 0;
        endingText.color = textAlpha;
        endingText.text = endingTexts[endingTextIndex];
        AudioManager.instance.AudioEndingStart();
        StartCoroutine(EndingTextStart());
    }
    IEnumerator EndingTextStart()
    {
        Debug.Log(endingText.text);
        while(textAlpha.a < 1)
        {
            textAlpha.a += textSpeed * Time.deltaTime;
            endingText.color = textAlpha;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (textAlpha.a >0)
        {
            textAlpha.a -= textSpeed * Time.deltaTime;
            endingText.color = textAlpha;
            yield return null;
        }

        if(endingTextIndex < endingTexts.Length-1)
        {
            endingTextIndex++;
            endingText.text = endingTexts[endingTextIndex];
            StartCoroutine(EndingTextStart());
        }
        else
        {
            Debug.Log("³¡");
            yield return new WaitForSeconds(2f);
            AudioManager.instance.AudioRestart();
            SceneManager.LoadScene(0);

        }

    }
    
}
