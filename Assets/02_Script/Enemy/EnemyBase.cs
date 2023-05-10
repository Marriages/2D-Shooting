using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    float heart = 3;
    public float maxHeart = 3;
    public float moveSpeed = 3f;
    public float getDamage = 1;     //�׽�Ʈ�� ���� �� private�� �����ϱ�.
    public GameObject enemyExplosionEffect;
    public GameObject coin;
    protected Rigidbody2D rigid;
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        EnemyInitialize();
    }
    protected virtual void EnemyInitialize()
    {
        heart = maxHeart;
    }

    void Atacked()
    {
        //Debug.Log("Hit");
        heart -= getDamage;
        
        if(heart < 0.1f)
        {
            EnemyDie();
        }
        else
        {
            AudioManager.instance.AudioEnemyHit();
        }
    }
    void EnemyDie()
    {
        GameObject obj = Instantiate(enemyExplosionEffect);
        obj.transform.position = transform.position;
        GameManager.instance.ScoreUp(10);
        GameManager.instance.PrograssUp();

        AudioManager.instance.AudioEnemyDie();
        obj = Instantiate(coin);
        obj.transform.position = transform.position;
        EnemyDequeue();
    }
    protected virtual void EnemyDequeue()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        transform.Translate( moveSpeed*Time.deltaTime * -transform.right );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Atacked();
        }
        else if(collision.gameObject.CompareTag("KillZone"))
        {
            EnemyDequeue();
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            EnemyDie();
        }
    }
    public void AbilityDamage1dot5Up()
    {
        //Debug.Log("������ 2��� �ޱ� �����");
        getDamage *= 1.5f;
    }


}
