using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBoss : MonoBehaviour
{
    // 패턴1 플레이어에게 유도탄 + 일반탄 발사 ( Boss의 Fireball 스크립트. 생성할때 플레이어의 
    // 일반탄은 플레이어의 현재 위치 향한 직선 빨간 파이어볼 연속 3발 버스트 발사. 이후 파란색 유도탄 발사 총알로 파괴 불가
    // 유도탄은 총알로 파괴 가능하며 보스의 위, 아래에서 한발씩 생성됨.
    // 버스트 시간은 0.3초

    // 대기시간 1초
    // 1초동안 플레이어를 바라보기 시작. 이후 움직임을 멈추고 빠르게 돌진. 화면 밖으로 사라지고 다시 오른쪽에서 등장해서 원래위치 복귀

    // 대기시간 1초
    // 본인기준 랜덤한 위치에서 DirectEnemy 몬스터를 플레이어를 바라보게끔 빠르게 생성(0.5초마다 1마리씩)

    // 대기시간 1초  이후 패턴 1로 넘어감.
    
    Transform player;

    Transform bossBody;
    EnemyBossBody bossBodyDetector;
    Transform normalFirePosition1;
    Transform normalFirePosition2;
    Transform traceFirePosition;
    Transform idlePosition;
    Transform returnPosition;
    Transform restartPosition;

    public float moveSpeed = 5f;
    public float dashSpeed = 15f;
    public float fireBurstTime = 0.3f;
    public float waitTime=1f;

    public float normalBulletSpeed = 4f;
    public float traceBulletSpeed = 2f;
    GameObject[] normalBullet;
    GameObject[] traceBullet;
    int normalBulletIndex=0;

    public float spawnInterval = 0.5f;
    public int spawnCount = 6;

    float currentTime = 0;
    public float dashWaitTime = 0.5f;


    //보스 데미지 받는비율을,,,,,1.5배일경우 고려해봐얗게는걸?
    int bossHP=240;
    public int BossHP
    {
        get => bossHP;
        set
        {
            if(value<0)
            {
                //bossstate= DieState;
            }
        }
    }

    // 작업 큐를 이용해서 1번패턴 - 대기패턴 - 2번패턴 - 대기패턴 - 3번패턴 - 대기패턴
    // 맨앞의 작업이 끝나면 디큐와 동시에 인큐를 해서 상태를 반복 할 수 있도록 진행할 것.
    // 보스가 죽게되면 큐를 비움과 동시에 DIe상태를 인큐. 이후에는 보스가동작하지 않을 것이니.... 와우 시발 이거다
    // 작업 큐를 이용할 것.

    Queue<Action> actionQueue = new Queue<Action>();
    Action currentAction;
    bool isDone = false;


    private void Awake()
    {
        try { player = FindObjectOfType<PlayerMove>().transform; }
        catch (NullReferenceException) { Debug.Log("플레이어 없음"); }

        bossBody = transform.GetChild(0).transform;
        traceFirePosition = bossBody.GetChild(0).transform;
        normalFirePosition1 = bossBody.GetChild(1).transform;
        normalFirePosition2 = bossBody.GetChild(2).transform;

        restartPosition = transform.GetChild(1).GetChild(0).transform;
        idlePosition = transform.GetChild(1).GetChild(1).transform;
        returnPosition = transform.GetChild(1).GetChild(2).transform;

        normalBullet = new GameObject[transform.GetChild(2).childCount];
        Debug.Log(normalBullet.Length);
        for(int i=0; i< normalBullet.Length; i++)
        {
            normalBullet[i] = transform.GetChild(2).GetChild(i).gameObject;
            normalBullet[i].SetActive(false);
            
        }

        traceBullet = new GameObject[transform.GetChild(3).childCount];
        Debug.Log(traceBullet.Length);
        for (int i = 0; i < traceBullet.Length; i++)
        {
            traceBullet[i] = transform.GetChild(3).GetChild(i).gameObject;
            traceBullet[i].SetActive(false);

        }
    }


    private void Start()
    {
        actionQueue.Enqueue(ReturnSetting);
        actionQueue.Enqueue(ReturnState);
        actionQueue.Enqueue(WaitOneSecond);
        actionQueue.Enqueue(FireNormalBullet);
        actionQueue.Enqueue(WaitOneSecond);
    }
    private void Update()
    {
        currentAction = actionQueue.Peek();
        currentAction?.Invoke();

        if( IsCurrentActionComplete() )
        {
            //Debug.Log("Next Action");
            Action q = actionQueue.Dequeue();
            actionQueue.Enqueue(q);
        }
    }
    private bool IsCurrentActionComplete()
    {
        if (isDone)
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
    private void ReturnSetting()
    {
        bossBody.transform.position = restartPosition.position;
        LookTarget(idlePosition);
        //bossBody.LookAt(Vector3.forward, Vector3.up);
        isDone = true;
    }
    private void ReturnState()
    {
        if((idlePosition.position - bossBody.position).sqrMagnitude >0.1f)
        {
            LookTarget(idlePosition);
            bossBody.transform.Translate(moveSpeed*Time.deltaTime* Vector2.left,Space.World);
        }
        else
        {
            isDone = true;
        }
    }
    void WaitOneSecond()
    {
        if (Time.time - currentTime < 1)
        {
        }
        else
        {
            isDone = true;
        }
    }
    void FireNormalBullet()
    {
        if(Time.time-currentTime > fireBurstTime)
        {
            normalBullet[normalBulletIndex].SetActive(true);
            normalBullet[normalBulletIndex].transform.position = normalFirePosition1.position;
            normalBullet[normalBulletIndex].transform.rotation = normalFirePosition1.rotation;

            normalBullet[normalBulletIndex + 1].SetActive(true);
            normalBullet[normalBulletIndex + 1].transform.position = normalFirePosition2.position;
            normalBullet[normalBulletIndex + 1].transform.rotation = normalFirePosition2.rotation;

            currentTime = Time.time;
            normalBulletIndex += 2;
        }
        else if(normalBulletIndex<=normalBullet.Length-2)
        {
            LookTarget(player);
        }
        else
        {
            normalBulletIndex = 0;
            traceBullet[0].SetActive(true);
            traceBullet[0].transform.position = traceFirePosition.position;
            isDone = true;
        }
    }


    void LookTarget(Transform target)
    {
        Vector3 lookDirection = target.position - bossBody.position;
        lookDirection.z = 0f;
        bossBody.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection) * Quaternion.Euler(0,0,-180f);
    }

    /*
    private void OnEnable()
    {
        bossBodyDetector = bossBody.GetComponent<EnemyBossBody>();
        bossBodyDetector.BossHit += () => BossHP--;
        bossBodyDetector.BossKillZone += DashEnd;
    }

    private void FixedUpdate()
    {
        bossstate();
    }
    void ReturnState()
    {
        Debug.Log("Return");
        if((idlePosition.position-bossBody.position).sqrMagnitude < 0.01f)
            bossBody.Translate(dashSpeed * Time.fixedDeltaTime * transform.up);
        bossstate = SettingState;

    }
    void FireState()
    {
        Debug.Log("Fire");
        bossstate = SettingState;

    }
    void SpawnState()
    {
        Debug.Log("Spawn");
        bossstate = SettingState;
    }
    void DashState()
    {
        Debug.Log("Dash");
        // 1초동안 플레이어를 바라보고, 이후에는 그 방향을 향해서 빠른 이동.
        if(Time.time - currentTime < dashWaitTime)
        {
            Vector3 lookDirection = player.position - bossBody.position;
            lookDirection.z = 0f; // 2D에서 z 축은 사용하지 않으므로 0으로 설정

            // 방향 벡터를 회전값으로 변환하여 A 오브젝트의 회전을 설정
            bossBody.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
        }
        else
        {
            bossBody.Translate(dashSpeed * Time.fixedDeltaTime * transform.up);
        }
    }
    void DashEnd()
    {
        currentTime = Time.time;
        bossstate = SettingState;
    }

    void DieState()
    {
        Debug.Log("Die");
    }

    void SettingState()
    {
        Debug.Log("Setting");
        if (Time.time - currentTime > waitTime)
        {
            currentTime = Time.time;

            switch (enumIndex)
            {
                //return -> Fire -> Spawn -> Dash -> 
                case 0:
                    bossstate = FireState;
                    enumIndex++;
                    break;
                case 1:
                    bossstate = SpawnState;
                    enumIndex++;
                    break;
                case 2:
                    bossstate = DashState;
                    enumIndex++;
                    break;
                case 3:
                    bossstate = ReturnState;
                    bossBody.position = returnPosition.position;

                    Vector3 lookDirection = idlePosition.position - bossBody.position;
                    lookDirection.z = 0f;
                    bossBody.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);

                    enumIndex = 0;
                    break;

                default:
                    Debug.LogError("상태가 없어!!");
                    break;
            }
            
        }
    }

    */
}
