using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float moveSpeed = 6f;
    public GameObject bulletEffect;
    private void OnEnable()
    {
        if(GameManager.Instance != null)
            GameManager.Instance.BulletDecrease();
    }
    private void OnDisable()
    {
        if(GameManager.Instance != null)
            GameManager.Instance.BulletIncrease();
    }

    private void Update()
    {
        transform.Translate( moveSpeed * Time.deltaTime * transform.right );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            GameObject obj = Instantiate(bulletEffect);
            obj.transform.position = transform.position;
            BulletPool.instance.ReturnObject(this);
        }
        else if(collision.CompareTag("KillZone"))
        {
            BulletPool.instance.ReturnObject(this);
        }
    }
    public void AbilityBulletSpeedDouble()
    {
        moveSpeed *= 2;
    }
}
