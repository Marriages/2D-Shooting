using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.instance.CurrentStageStart();
            this.gameObject.SetActive(false);
        }
    }
}
