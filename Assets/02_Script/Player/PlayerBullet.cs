using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float moveSpeed = 6f;
    public GameObject bulletEffect;
    bool isDouble = false;      //데미지 두배가 체크되었는지
    private void OnEnable()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.BulletDecrease();
            AudioManager.instance.AudioPlayerAtack();
        }
    }
    private void OnDisable()
    {
        if(GameManager.instance != null)
            GameManager.instance.BulletIncrease();
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
        if(isDouble==false)
        {
            isDouble = true;
            moveSpeed *= 2;
        }
    }
}
