using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectEnemy : EnemyBase
{
    protected override void EnemyDequeue()
    {
        base.EnemyDequeue();
        DirectEnemyPool.instance.ReturnObject(this);
    }
}
