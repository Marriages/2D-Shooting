using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpening : MonoBehaviour
{
    public float frequency = 5f;
    public float height = 0.05f;
    float timeAcc = 0f;

    void Update()
    {
        timeAcc += Time.deltaTime * frequency;
        transform.Translate(Mathf.Sin(timeAcc) * height * transform.up);
    }
}
