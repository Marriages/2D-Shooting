using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed=180f;
    public float moveSpeed=3f;

    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector2.left,Space.World);
        transform.rotation *= Quaternion.Euler(0, rotateSpeed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.ScoreUp(5);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.CompareTag("KillZone"))
        {
            Destroy(this.gameObject);
        }
    }
}
