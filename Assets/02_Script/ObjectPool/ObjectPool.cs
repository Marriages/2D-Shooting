using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    
    public static ObjectPool<T> instance;
    public int poolSize = 16;
    public T objectPrefab;
    Queue<T> objectQueue = new Queue<T>();

    private void Awake()
    {
        instance = this;
        InitializePool(poolSize);
    }
    void InitializePool(int poolSize)
    {
        //Debug.Log("Hi");
        for (int i=0;i< poolSize;i++)
        {
            objectQueue.Enqueue(GenerateObject());
        }
    }

    T GenerateObject()
    {
        T obj = Instantiate(objectPrefab, transform);
        obj.gameObject.SetActive(false);
        return obj;
    }
    public T GetObject()
    {
        if(objectQueue.Count>0)
        {
            //Debug.Log("한개 빼가요");
            T obj = objectQueue.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            //Debug.Log("더이상 줄게 없어요");
            return null;
        }
        
    }
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        objectQueue.Enqueue(obj);
        //Debug.Log("넣기 완료");

    }

}
