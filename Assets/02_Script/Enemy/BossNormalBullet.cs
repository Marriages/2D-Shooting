using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossNormalBullet : MonoBehaviour
{
    public float moveSpeed = 4f;

    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * -transform.up,Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("KillZone"))
        {
            gameObject.SetActive(false);
        }
    }
}
