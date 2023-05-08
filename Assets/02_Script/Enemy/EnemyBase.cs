using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    int heart = 3;
    public int maxHeart = 3;
    public float moveSpeed = 3f;
    public GameObject enemyExplosionEffect;
    

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
        Debug.Log("Hit");
        heart--;
        if(heart < 1)
        {
            GameObject obj = Instantiate(enemyExplosionEffect);
            obj.transform.position = transform.position;
            GameManager.Instance.ScoreUp(10);
            GameManager.Instance.PrograssUp();
            EnemyDequeue();
        }
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
    }


}
