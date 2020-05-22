using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    internal bool wave_Ended;

    public float rest_Time;
    float time_Before_Next_Wave;

    private void FixedUpdate()
    {
        if(wave_Ended && time_Before_Next_Wave >= 0)
        {
            time_Before_Next_Wave -= Time.deltaTime;
        }
        if (time_Before_Next_Wave <= 0)
        {
            wave_Ended = false;
            time_Before_Next_Wave = rest_Time;
        }
    }
}
