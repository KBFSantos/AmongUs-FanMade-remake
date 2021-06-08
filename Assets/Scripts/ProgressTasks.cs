using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProgressTasks : MonoBehaviour
{
    private static float MaxProgress = 0;
    private static float Progress = 0f;
    private static int TaskCount = 0;

    public void Start()
    {
        MaxProgress = GameObject.FindWithTag("PlayerUI").GetComponentInChildren<Slider>().maxValue;
    }

    public static void SetProgress(float value)
    {
        Progress = value;

    }
    public static float GetProgress()
     {
        return Progress;
     }

    public static float GetDistributedValue()
    {
        return MaxProgress / TaskCount;
    }

    public static void TaskSetup()
    {
        ++TaskCount;
    }



}
