using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : Gun
{
    public int bullet_Left;
    //upgradables
    public int[] gun_Ammo_Capacity = new int[4];
    public float[] damage_Multiplier = new float[3];
    //current level
    public int current_Damage_Level;
    public int current_Ammo_Level;

    private void Start()
    {
        bullet_Left = gun_Ammo_Capacity[0];
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            current_Ammo_Level++;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            current_Damage_Level++;
        }
        if (bullet_Left > 0 && !reloading)
        {
            //if (Input.GetMouseButton(0) && Time.time >= next_Time_To_Fire)
            if (Input.GetMouseButtonDown(0))
            {
                Shooting();
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && bullet_Left == 0 && !reloading || Input.GetKeyDown(KeyCode.R) && !reloading)
        {
            StartCoroutine("Reloading");
            reloading = true;
        }
    }
    internal IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reload_Time);
        RelodGun();
    }
    internal void Shooting()
    {
        bullet_Left--;
        Bullet B = Instantiate(bullet, spawn_Point.position, spawn_Point.rotation);
        switch (current_Damage_Level)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    float new_Damage;
                    new_Damage = B.damage * damage_Multiplier[0];
                    B.damage = new_Damage;
                    break;
                }
            case 2:
                {
                    float new_Damage;
                    new_Damage = B.damage * damage_Multiplier[1];
                    B.damage = new_Damage;
                    break;
                }
            case 3:
                {
                    float new_Damage;
                    new_Damage = B.damage * damage_Multiplier[2];
                    B.damage = new_Damage;
                    break;
                }
        }
    }
    void RelodGun()
    {
        switch (current_Ammo_Level)
        {
            case 0:
                {
                    bullet_Left = gun_Ammo_Capacity[0];
                    break;
                }
            case 1:
                {
                    bullet_Left = gun_Ammo_Capacity[1];
                    break;
                }
            case 2:
                {
                    bullet_Left = gun_Ammo_Capacity[2];
                    break;
                }
            case 3:
                {
                    bullet_Left = gun_Ammo_Capacity[3];
                    break;
                }
        }
        reloading = false;
    }
}
