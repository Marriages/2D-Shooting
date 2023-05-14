using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIPause : MonoBehaviour
{
    Button resume;
    Button option;
    GameObject optionWindow;
    Button title;

    UIController ui;

    bool isOption=false;




    
    private void Awake()
    {
        resume = transform.GetChild(1).GetChild(0).GetComponent<Button>();
        resume.onClick.AddListener(ResumeClick);
        option = transform.GetChild(1).GetChild(1).GetComponent<Button>();
        option.onClick.AddListener(OptionClick);
        optionWindow = option.transform.GetChild(1).gameObject;
        title = transform.GetChild(1).GetChild(2).GetComponent<Button>();
        title.onClick.AddListener(TitleClick);

        ui = transform.parent.GetComponent<UIController>();
    }
    private void OnEnable()
    {
        isOption = false;
        optionWindow.SetActive(false);
    }
    void ResumeClick()
    {
        ui.PauseSetting();
    }
    void OptionClick()
    {
        isOption = !isOption;
        optionWindow.SetActive(isOption);
    }
    void TitleClick()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        /*int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameObject obj = GameObject.FindWithTag("EventSystem");
        if(obj != null)
        {
            Destroy(obj.gameObject);
        }
        obj = GameObject.FindObjectOfType<CameraShake>().gameObject;
        if (obj != null)
        {
            Destroy(obj.gameObject);
        }
        StartCoroutine(LoadSceneAndSetActive(0, currentSceneIndex));*/
    }
    private IEnumerator LoadSceneAndSetActive(int sceneIndex, int currentSceneIndex)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

        while (!loadOperation.isDone)
        {
            yield return null;
        }

        yield return SceneManager.UnloadSceneAsync(currentSceneIndex);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
    }
}
