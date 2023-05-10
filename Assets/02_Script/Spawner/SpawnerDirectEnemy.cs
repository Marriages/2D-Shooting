using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDirectEnemy : MonoBehaviour
{
    public float miny = -4f;
    public float maxy = 4f;
    WaitForSeconds spawnTime = new WaitForSeconds(1f);
    IEnumerator generageDirect;

    public void StartSpawn()
    {
        //Debug.Log("Direct Spawner Start");
        generageDirect = GenerateDirect();
        StartCoroutine(generageDirect);
    }
    public void StopSpawn()
    {
        //Debug.Log("Direct Spawner Stop");
        StopCoroutine(generageDirect);
        generageDirect = null;
    }

    IEnumerator GenerateDirect()
    {
        while (generageDirect!=null)
        {
            yield return spawnTime;
            DirectEnemy obj = DirectEnemyPool.instance.GetObject();
            if (obj != null)
                obj.transform.position = transform.position + Vector3.up * Random.Range(miny, maxy);

        }
    }
}
