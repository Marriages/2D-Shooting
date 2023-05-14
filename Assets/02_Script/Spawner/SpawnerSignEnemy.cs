using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSignEnemy : MonoBehaviour
{
    public float miny = -3f;
    public float maxy = 3f;
    WaitForSeconds spawnTime= new WaitForSeconds(1f);
    IEnumerator generateSign;
    public void StartSpawn()
    {
        generateSign = GenerateSign();
        //Debug.Log("Sign Spawner Start");
        StartCoroutine(generateSign);
    }
    public void StopSpawn()
    {
        //Debug.Log("Sign Spawner Stop");
        if(generateSign != null)
            StopCoroutine(generateSign);
        generateSign = null;

        // 1스테이지에서 스탑하려하니...에러가뜸
    }
    
    IEnumerator GenerateSign()
    {
        while(generateSign!=null)
        {
            yield return spawnTime;
            SignEnemy obj = SignEnemyPool.instance.GetObject();
            if(obj != null)
                obj.transform.position = transform.position + Vector3.up * Random.Range(miny, maxy);
            
        }
    }
}
