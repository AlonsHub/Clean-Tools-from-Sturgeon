using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_TIME : MonoBehaviour
{
    [SerializeField, Tooltip("Base duration for one Tick of game time.")]
    float _timeStep = 1f;

    [SerializeField, Tooltip("Similar to TimeScale. Defualt value 1f. This is used to effect game time. The duration of one Tick is [_timeStep] divided by [_timeRate]. So a higher value, means time goes by 'quicker'.")]
    float _timeRate = 1f;

    float Tick => _timeStep / _timeRate;
    public static float Time;

    public static Action OnGameTimeTick; //tbd static or private and static un/sub methods? - no added funtionality is really required to un/subbing that I can think of... 

    void Start()
    {
        StartCoroutine(nameof(RunTime));
    }

    IEnumerator RunTime()
    {
        Time = 0f;
        while(true)
        {
            yield return new WaitForSecondsRealtime(Tick);
            Debug.Log("tick.");
            Time += Tick;
            OnGameTimeTick?.Invoke();
        }
    }
}
