using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOpening : MonoBehaviour
{
    public float frequency = 5f;
    public float height = 0.05f;
    float timeAcc = 0f;
    TitleUIController ui;

    float moveSpeed = 5f;

    bool isStart = false;

    private void Awake()
    {
        ui = FindObjectOfType<TitleUIController>();
    }
    private void OnEnable()
    {
        ui.PlayerGameStart += GameStart;
        StartCoroutine(SignMove());
    }
    private void OnDisable()
    {
        ui.PlayerGameStart -= GameStart;
        StopAllCoroutines();
    }
    IEnumerator SignMove()
    {
        while( !isStart )
        {
            timeAcc += Time.deltaTime * frequency;
            transform.Translate(Mathf.Sin(timeAcc) * height * transform.up);
            yield return null;
        }
    }
    void GameStart()
    {
        isStart = true;
        StopAllCoroutines();
        StartCoroutine(LoadingMove());
    }
    IEnumerator LoadingMove()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        operation.allowSceneActivation = false;
        while (transform.position.x<15f)
        {
            transform.Translate(moveSpeed * Time.deltaTime * transform.right);
            yield return null;
        }
        operation.allowSceneActivation = true;
    }
}
