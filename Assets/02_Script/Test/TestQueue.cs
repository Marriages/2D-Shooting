using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQueue : MonoBehaviour
{
    public GameObject redBox;
    public GameObject greenBox;
    public GameObject blackBox;

    Queue<Action> actionQueue = new Queue<Action>();

    float currentTime=0;
    bool isDone = false;

    private void Start()
    {
        actionQueue.Enqueue(CreateRedBox);
        actionQueue.Enqueue(CreateGreenBox);
        actionQueue.Enqueue(CreateBlackBox);
        currentTime = Time.time;
    }

    private void Update()
    {
        //if (actionQueue.Count == 0)
        //     return;

        // 현재 액션 실행
        Action currentAction = actionQueue.Peek();
        currentAction.Invoke();

        // 액션이 완료되면 큐에서 제거
        if (IsCurrentActionComplete())
        {
            Debug.Log("DeQueue EnQueue");
            Action q = actionQueue.Dequeue();
            actionQueue.Enqueue(q);
        }
    }

    void CreateRedBox()
    {
        if( Time.time-currentTime < 1f )
        {
            redBox.transform.Translate(Vector2.left * Time.deltaTime);
        }
        else
        {
            Debug.Log("Red Done");
            isDone = true;
        }
        
    }
    void CreateGreenBox()
    {
        if (Time.time - currentTime < 1f)
        {
            greenBox.transform.Translate(Vector2.up * Time.deltaTime);
        }
        else
        {
            Debug.Log("Green Done");
            isDone = true;
        }
    }
    void CreateBlackBox()
    {
        if (Time.time - currentTime < 1f)
        {
            blackBox.transform.Translate(Vector2.right * Time.deltaTime);
        }
        else
        {

            Debug.Log("Black Done");
            isDone = true;
        }
    }

    // 현재 액션의 실행 여부를 판단하는 메서드
    private bool IsCurrentActionComplete()
    {
        if(isDone)
        {
            isDone = false;
            currentTime = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }

}
