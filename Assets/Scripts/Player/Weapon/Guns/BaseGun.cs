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

    public bool reloading;

    public AudioClip gun_Sound;
    public AudioSource reload_Sound;

    public SO_BulletStates the_Bullet_Data;

    internal ShopManager the_SM;
    internal ObjectPoolBullet the_OPB;
    internal GunSound the_Gun_Sound;
    internal PlayerManager the_Player_Manager;
    internal PlayerUI the_Player_UI;

    private void Awake()
    {
        the_OPB =FindObjectOfType<ObjectPoolBullet>();
        the_SM = FindObjectOfType<ShopManager>();
        the_Gun_Sound = FindObjectOfType<GunSound>();
        the_Player_Manager = FindObjectOfType<PlayerManager>();
        the_Player_UI = FindObjectOfType<PlayerUI>();
        bullet_Left = gun_Ammo_Capacity[current_Ammo_Level];//weapon bullet amount
    }

    public virtual void Update()
    {
        //player cant shoot whilst repairing
        if (Time.timeScale != 0)
        {
            if (!the_Player_Manager.repairing_Truck)
            {
                if (bullet_Left > 0 && !reloading)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (the_SM.shop_Open == false)
                        {
                            Shooting();
                        }
                    }
                    //Special Attack
                    /*if (Input.GetMouseButtonDown(1))//
                    {
                        if (the_SM.shop_Open == false)
                        {
                            SpecialAttack();
                        }
                    }*/
                }
            }
        }
       
        //start reloading
        if (bullet_Left == 0 && !reloading || Input.GetKeyDown(KeyCode.R) && !reloading)
        {
            StartCoroutine("Reloading");
            reloading = true;
        }
    }

    internal IEnumerator Reloading()
    {
        reload_Sound.Play();
        yield return new WaitForSeconds(reload_Time);//reload time
        RelodGun();
    }
    public virtual void Shooting()
    {
        int current_i = 0;
        //spawn of bullet
        if (!the_Player_Manager.repairing_Truck)
        {
            //check list pool
            for (int i = 0; i < the_OPB.bullet_List.Count; i++)
            {
                if (!the_OPB.bullet_List[i].activeInHierarchy)
                {
                    current_i = i;
                    the_OPB.bullet_List[i].transform.position = spawn_Point.position;
                    the_OPB.bullet_List[i].transform.rotation = spawn_Point.rotation;
                    the_OPB.bullet_List[i].GetComponent<Bullet>().the_Bullet_Stats = the_Bullet_Data;//collect data for bullet for current weapon
                    the_Gun_Sound.ShootingGun(gun_Sound);
                    the_OPB.bullet_List[i].SetActive(true);
                    DamageLevel(current_i);//set damage level of bullet
                    the_Player_UI.RemoveAmmoUI();
                    bullet_Left--;
                    break;
                }
            }
        }
    }
    /*public virtual void SpecialAttack()
    {
        int BL = bullet_Left;

    }*/
    internal void DamageLevel(int current_i)
    {
        //damage level
        switch (current_Damage_Level)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    float new_Damage = the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage;//ensure that master float wont get multiple again every function is call
                    new_Damage *= damage_Multiplier[0];
                    the_OPB.bullet_List[current_i].GetComponent<Bullet>().damage = new_Damage;//set bullet damage amount
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
        //set gun ammo capacity   
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
        the_Player_UI.UpdateAmmoUI(the_Player_Manager.current_Weapon);//update ammo UI
    }
}
