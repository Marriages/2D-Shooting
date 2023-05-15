using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    //저장할 데이터 타입만 있어야함. 반드시 Public  /  참조타입은 안돼! 실제 저장할 데이터 값만!
    public int[] score;
    public int[] clearTime;


}
