using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDirectEnemy : MonoBehaviour
{
    public float miny = -4f;
    public float maxy = 4f;
    WaitForSeconds spawnTime = new WaitForSeconds(1f);
    IEnumerator generateSign;

    public void StartSpawn()
    {
        generateSign = GenerateSign();
        Debug.Log("Direct Spawner Start");
        StartCoroutine(generateSign);
    }
    public void StopSpawn()
    {
        Debug.Log("Direct Spawner Stop");
        StopCoroutine(generateSign);
        generateSign = null;
    }

    IEnumerator GenerateSign()
    {
        while (true)
        {
            yield return spawnTime;
            DirectEnemy obj = DirectEnemyPool.instance.GetObject();
            if (obj != null)
                obj.transform.position = transform.position + Vector3.up * Random.Range(miny, maxy);

        }
    }
}
