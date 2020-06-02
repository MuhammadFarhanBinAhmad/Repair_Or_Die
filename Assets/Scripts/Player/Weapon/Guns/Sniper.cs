using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : BaseGun
{
    public override void Update()
    {
        {
            if (bullet_Left > 0 && !reloading)
            {
                if (Input.GetMouseButtonDown(0) && Time.time >= next_Time_To_Fire)
                {
                    Shooting();
                    next_Time_To_Fire = Time.time + 1f / fire_Rate;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && bullet_Left == 0 && !reloading || Input.GetKeyDown(KeyCode.R) && !reloading)
        {
            StartCoroutine("Reloading");
            reloading = true;
        }
    }
}
