using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackPlanetMove : MonoBehaviour
{
    //0 ~ -3 Random
    Transform planetPos;
    Transform respawnPos;
    public float moveSpeed=5f;

    private void Awake()
    {
        planetPos = transform.GetChild(0).transform;
        respawnPos = transform.GetChild(1).transform;
    }
    private void Update()
    {
        planetPos.Translate( moveSpeed * Time.deltaTime * -transform.right);
        if (planetPos.localPosition.x < 0f)
        {
            float ranX = Random.Range(0f, 5f);
            float ranY = Random.Range(-3f, 0f);
            Vector3 ranPosition = respawnPos.position + Vector3.up * ranY + Vector3.right * ranX;
            planetPos.position = ranPosition;
            
        }
    }
}
