using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignEnemy : EnemyBase
{
    public float frequency=3f;
    public float height=0.05f;
    float timeAcc=0f;

    protected override void Update()
    {
        base.Update();
        timeAcc += Time.deltaTime * frequency;
        transform.Translate( Mathf.Sin(timeAcc) * height * transform.up);
    }
    protected override void EnemyDequeue()
    {
        base.EnemyDequeue();
        SignEnemyPool.instance.ReturnObject(this);
    }
}
