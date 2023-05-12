using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBoss : MonoBehaviour
{
    // ����1 �÷��̾�� ����ź + �Ϲ�ź �߻� ( Boss�� Fireball ��ũ��Ʈ. �����Ҷ� �÷��̾��� 
    // �Ϲ�ź�� �÷��̾��� ���� ��ġ ���� ���� ���� ���̾ ���� 3�� ����Ʈ �߻�. ���� �Ķ��� ����ź �߻� �Ѿ˷� �ı� �Ұ�
    // ����ź�� �Ѿ˷� �ı� �����ϸ� ������ ��, �Ʒ����� �ѹ߾� ������.
    // ����Ʈ �ð��� 0.3��

    // ���ð� 1��
    // 1�ʵ��� �÷��̾ �ٶ󺸱� ����. ���� �������� ���߰� ������ ����. ȭ�� ������ ������� �ٽ� �����ʿ��� �����ؼ� ������ġ ����

    // ���ð� 1��
    // ���α��� ������ ��ġ���� DirectEnemy ���͸� �÷��̾ �ٶ󺸰Բ� ������ ����(0.5�ʸ��� 1������)

    // ���ð� 1��  ���� ���� 1�� �Ѿ.
    
    public delegate void BossState();
    BossState bossstate=null;

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

    public float spawnInterval = 0.5f;
    public int spawnCount = 6;

    float currentTime = 0;
    public float dashWaitTime = 0.5f;

    enum State
    {
        returnState,
        dashState,
        fireState
    }
    int enumIndex=0;

    private void Awake()
    {
        try { player = FindObjectOfType<PlayerMove>().transform; }
        catch (System.NullReferenceException) { Debug.Log("�÷��̾� ����"); }

        bossBody = transform.GetChild(0).transform;
        traceFirePosition = bossBody.GetChild(0).transform;
        normalFirePosition1= bossBody.GetChild(1).transform;
        normalFirePosition2 = bossBody.GetChild(2).transform;

        restartPosition = transform.GetChild(1).GetChild(0).transform;
        idlePosition= transform.GetChild(1).GetChild(1).transform;
        returnPosition = transform.GetChild(1).GetChild(2).transform;

        normalBullet = new GameObject[transform.GetChild(2).childCount];
        //Debug.Log(normalBullet.Length);
        //normalBullet = transform.GetChild(2).GetComponentsInChildren<Transform>();
        traceBullet = new GameObject[transform.GetChild(3).childCount];
        //Debug.Log(traceBullet.Length);
        //traceBullet=  transform.GetChild(3).GetComponentsInChildren<Transform>();
    }

    //���� ������ �޴º�����,,,,,1.5���ϰ�� ����غ���Դ°�?
    int bossHP=240;
    public int BossHP
    {
        get => bossHP;
        set
        {
            if(value<0)
            {
                bossstate= DieState;
            }
        }
    }

    // �۾� ť�� �̿��ؼ� 1������ - ������� - 2������ - ������� - 3������ - �������
    // �Ǿ��� �۾��� ������ ��ť�� ���ÿ� ��ť�� �ؼ� ���¸� �ݺ� �� �� �ֵ��� ������ ��.
    // ������ �װԵǸ� ť�� ���� ���ÿ� DIe���¸� ��ť. ���Ŀ��� �������������� ���� ���̴�.... �Ϳ� �ù� �̰Ŵ�
    // �۾� ť�� �̿��� ��.





    private void OnEnable()
    {
        bossBodyDetector = bossBody.GetComponent<EnemyBossBody>();
        bossBodyDetector.BossHit += () => BossHP--;
        bossBodyDetector.BossKillZone += DashEnd;
    }

    private void Start()
    {
        bossstate = SettingState;
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
        // 1�ʵ��� �÷��̾ �ٶ󺸰�, ���Ŀ��� �� ������ ���ؼ� ���� �̵�.
        if(Time.time - currentTime < dashWaitTime)
        {
            Vector3 lookDirection = player.position - bossBody.position;
            lookDirection.z = 0f; // 2D���� z ���� ������� �����Ƿ� 0���� ����

            // ���� ���͸� ȸ�������� ��ȯ�Ͽ� A ������Ʈ�� ȸ���� ����
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
                    Debug.LogError("���°� ����!!");
                    break;
            }
            
        }
    }
}
