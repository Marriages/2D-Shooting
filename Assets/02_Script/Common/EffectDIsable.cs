using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDIsable : MonoBehaviour
{
    Animator anim;
    float runTime;
    private void Awake()
    {
        anim= GetComponent<Animator>();
        runTime = anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }

    private void OnEnable()
    {
        Destroy(gameObject, runTime);
    }
}
