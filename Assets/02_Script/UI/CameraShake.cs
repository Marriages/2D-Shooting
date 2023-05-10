using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float shakeTime = 0.2f;
    float currentShakeTime = 0f;
    float shakePower=0.1f;
    Vector3 initializePosition;


    private void Awake()
    {
        initializePosition = transform.position;
    }

    public void ShakeCamera()
    {
        currentShakeTime = Time.time;
        StartCoroutine(StartShakeCamera());
    }

    IEnumerator StartShakeCamera()
    {
        while(Time.time-currentShakeTime < shakeTime)
        {
            transform.position += Random.insideUnitSphere * shakePower;
            yield return null;
        }
        transform.position = initializePosition;
    }
}
