using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackImageMove : MonoBehaviour
{
    public float backSpeed = 3f;
    float backWidth;
    Transform[] backImage;
    int childNum = 0;
    private void Awake()
    {
        childNum = transform.childCount;
        backImage = new Transform[childNum];
        for(int i=0;i < childNum;i++)
            backImage[i]=transform.GetChild(i);
        backWidth = backImage[1].position.x - backImage[0].position.x;

    }
    private void Update()
    {
        foreach(Transform t in backImage)
        {
            t.Translate(backSpeed * Time.deltaTime * -transform.right);
            if (t.localPosition.x < 0f)
                t.Translate( transform.right * backWidth * (childNum) );
        }
    }

}
