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

    public SO_BulletStates the_Bullet_Data;

    internal ShopManager the_SM;
    internal ObjectPoolBullet the_OPB;
    PlayerManager the_Player_Manager;

    private void Start()
    {
        the_OPB =FindObjectOfType<ObjectPoolBullet>();
        the_SM = FindObjectOfType<ShopManager>();
        the_Player_Manager = FindObjectOfType<PlayerManager>();
        bullet_Left = gun_Ammo_Capacity[0];
    }

    public virtual void Update()
    {
        if (!the_Player_Manager.repairing_Truck)
        {
            if (bullet_Left > 0 && !reloading)
            {
                //if (Input.GetMouseButton(0) && Time.time >= next_Time_To_Fire)
                if (Input.GetMouseButtonDown(0))
                {
                    if (the_SM.shop_Open == false)
                    {
                        Shooting();
                    }
                }
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
    public virtual void Shooting()
    {
        //Bullet B = Instantiate(bullet, spawn_Point.position, spawn_Point.rotation);
        int current_i = 0;
        for (int i = 0; i < the_OPB.bullet_List.Count; i++)
        {
            if (!the_OPB.bullet_List[i].activeInHierarchy)
            {
                current_i = i;
                the_OPB.bullet_List[i].transform.position = spawn_Point.position;
                the_OPB.bullet_List[i].transform.rotation = spawn_Point.rotation;
                the_OPB.bullet_List[i].GetComponent<Bullet>().the_Bullet_Stats = the_Bullet_Data; 
                the_OPB.bullet_List[i].SetActive(true);
                DamageLevel(current_i);
                bullet_Left--;
                break;
            }
        }
        /*switch (current_Damage_Level)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    float new_Damage = the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage;
                    new_Damage *= damage_Multiplier[0];
                    the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage = new_Damage;
                    break;
                }
            case 2:
                {
                    float new_Damage = the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage;
                    new_Damage *= damage_Multiplier[1];
                    the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage = new_Damage;
                    break;
                }
            case 3:
                {
                    float new_Damage = the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage;
                    new_Damage *= damage_Multiplier[2];
                    the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage = new_Damage;
                    break;
                }
        }*/
    }
    internal void DamageLevel(int current_i)
    {
        switch (current_Damage_Level)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    float new_Damage = the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage;
                    new_Damage *= damage_Multiplier[0];
                    the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage = new_Damage;
                    break;
                }
            case 2:
                {
                    float new_Damage = the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage;
                    new_Damage *= damage_Multiplier[1];
                    the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage = new_Damage;
                    break;
                }
            case 3:
                {
                    float new_Damage = the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage;
                    new_Damage *= damage_Multiplier[2];
                    the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage = new_Damage;
                    break;
                }
        }
    }
    internal void RelodGun()
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
