using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSignEnemy : MonoBehaviour
{
    float miny = -4f;
    float maxy = 4f;
    WaitForSeconds spawnTime= new WaitForSeconds(1f);

    private void OnEnable()
    {
        StartCoroutine(GenerateNormal());
    }

    IEnumerator GenerateNormal()
    {
        while(true)
        {
            yield return spawnTime;
            SignEnemy obj = SignEnemyPool.instance.GetObject();
            if(obj != null)
                obj.transform.position = transform.position + Vector3.up * Random.Range(miny, maxy);
            
        }
    }
}
