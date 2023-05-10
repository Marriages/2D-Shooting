using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectEnemy : EnemyBase
{
    public float accelatePower = 0.5f;
    protected override void EnemyDequeue()
    {
        base.EnemyDequeue();
        DirectEnemyPool.instance.ReturnObject(this);
    }
    private void FixedUpdate()
    {
        rigid.AddForce(-transform.right * accelatePower, ForceMode2D.Force);
    }
}
