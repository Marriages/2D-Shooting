using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTraceBullet : MonoBehaviour
{
    public float moveSpeed = 5f;
    PlayerMove player;
    private void OnEnable()
    {
        player = FindObjectOfType<PlayerMove>();
    }
    private void Update()
    {
        LookTarget(player.transform);
        transform.Translate(moveSpeed * Time.deltaTime * transform.right, Space.Self);
    }

    void LookTarget(Transform target)
    {
        Vector3 lookDirection = target.position - transform.position;
        lookDirection.z = 0f;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") || collision.CompareTag("KillZone") || collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
