using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : BaseGun
{
    public override void Shooting()
    {
        int current_i = 0;
        for (int CL = 0; CL < 5; CL++)
        {
            for (int i = 0; i < the_OPB.bullet_List.Count; i++)
            {
                if (!the_OPB.bullet_List[i].activeInHierarchy)
                {
                    current_i = i;
                    float r = Random.Range(-10, 10);
                    the_OPB.bullet_List[i].transform.position = spawn_Point.position;
                    Quaternion q = Quaternion.Euler(spawn_Point.rotation.x, spawn_Point.rotation.y, spawn_Point.eulerAngles.z + r);
                    the_OPB.bullet_List[i].transform.rotation = q;
                    the_OPB.bullet_List[i].GetComponent<Bullet>().the_Bullet_Stats = the_Bullet_Data;
                    the_OPB.bullet_List[i].SetActive(true);
                    DamageLevel(current_i);
                    bullet_Left--;
                    break;
                }
            }
        }
        
    }
}
