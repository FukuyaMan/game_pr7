using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManage : MonoBehaviour
{
    public static float clearTime=0f;

    void Start()
    {
        clearTime=0f;
    }
    // Update is called once per frame
    void Update()
    {
        clearTime += Time.deltaTime;
    }
}