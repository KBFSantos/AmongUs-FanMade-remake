using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTasks : MonoBehaviour
{
    const float Progress_Speed = 0.065f;
    private static float progress = 0f;
    static public ProgressTasks instance;

    void Awake()
    { 
        instance = this; 
    }

    public static void SetProgress(float value)
    {
        progress = value;

    }
    public static float GetProgress()
     {
        return progress;
     }





}
