using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    //구현해야할 것
    // InitializePool , GenerateObject, GetObject, ReturnObject, ExtendPool

    public static BulletObjectPool instance;
    public int poolSize = 16;
    public PlayerBullet playerBulletPrefab;
    Queue<PlayerBullet> bulletQueue = new Queue<PlayerBullet>();

    private void Awake()
    {
        instance = this;
        InitializePool(poolSize);
    }
    void InitializePool(int poolSize)
    {
        for(int i=0;i< poolSize;i++)
        {
            bulletQueue.Enqueue(GenerateObject());
        }
    }

    PlayerBullet GenerateObject()
    {
        PlayerBullet obj = Instantiate(playerBulletPrefab,transform);
        obj.gameObject.SetActive(false);
        return obj;
    }
    public PlayerBullet GetObject()
    {
        if(bulletQueue.Count>0)
        {
            Debug.Log("한개 빼가요");
            PlayerBullet obj = bulletQueue.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            Debug.Log("더이상 줄게 없어요");
            return null;
        }
        
    }
    public void ReturnObject(PlayerBullet obj)
    {
        obj.gameObject.SetActive(false);
        bulletQueue.Enqueue(obj);
        Debug.Log("넣기 완료");

    }

}
