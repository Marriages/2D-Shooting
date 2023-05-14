using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyBoss;

public class EnemyBossBody : MonoBehaviour
{
    public Action BossHit;
    public Action BossKillZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Boss Col");
        if (collision.CompareTag("Bullet"))
        {
            //Debug.Log("Bullet Collision");
            BossHit?.Invoke();
        }
        else if (collision.CompareTag("KillZone"))
        {
            //Debug.Log("KillZone Collision");
            BossKillZone?.Invoke();
        }
    }
}
