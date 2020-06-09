using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : BaseGun
{
    /// <summary>
    /// workk the same as bsae gun but with spwn 5 buillets and spawn it at random rotation
    /// </summary>

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
    public override void Shooting()
    {
        //base.Shooting();
        int current_i = 0;
        if (!the_Player_Manager.repairing_Truck)
        {
            for (int CL = 0; CL < 5; CL++)//spawn multiple bullet
            {
                for (int i = 0; i < the_OPB.bullet_List.Count; i++)
                {
                    if (!the_OPB.bullet_List[i].activeInHierarchy)
                    {
                        current_i = i;
                        float r = Random.Range(-10, 10);
                        the_OPB.bullet_List[i].transform.position = spawn_Point.position;
                        Quaternion q = Quaternion.Euler(spawn_Point.rotation.x, spawn_Point.rotation.y, spawn_Point.eulerAngles.z + r);//random spawn direction
                        the_OPB.bullet_List[i].transform.rotation = q;
                        the_OPB.bullet_List[i].GetComponent<Bullet>().the_Bullet_Stats = the_Bullet_Data;
                        the_Gun_Sound.ShootingGun(gun_Sound);
                        the_OPB.bullet_List[i].SetActive(true);
                        the_Player_UI.RemoveAmmoUI();
                        DamageLevel(current_i);
                        bullet_Left--;
                        break;
                    }
                }
            }
        }
        
    }
}
