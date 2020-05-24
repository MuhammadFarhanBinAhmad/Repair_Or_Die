﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class stats
{
    public int buying_Price;
    public List<int> damage_Upgrade_Cost = new List<int>();
    public List<int> ammo_Upgrade_Cost = new List<int>();
}
public class UpgradeWeapon : MonoBehaviour
{
    public int weapon_Number;

    public BaseGun upgrable_Weapon;
    public PlayerManager the_Player_Manager;

    public stats the_Stats;

    private void Start()
    {
        the_Player_Manager = FindObjectOfType<PlayerManager>();
    }

    public void UnlockWeapon()
    {
        if (the_Player_Manager.total_Money >= the_Stats.buying_Price)
        {
            if (!the_Player_Manager.weapon_Unlock[weapon_Number])
            {
                print(weapon_Number);
                the_Player_Manager.weapon_Unlock[weapon_Number] = true;
                the_Player_Manager.total_Money -= the_Stats.buying_Price;
            }
        }  
    }
    public void UpgradeDamage()
    {
        if (the_Player_Manager.weapon_Unlock[weapon_Number])
        {
            if (the_Player_Manager.total_Money >= the_Stats.damage_Upgrade_Cost[upgrable_Weapon.current_Damage_Level])
            {
                if (upgrable_Weapon.current_Damage_Level <= upgrable_Weapon.damage_Multiplier.Length)
                {
                    upgrable_Weapon.current_Damage_Level++;
                    the_Player_Manager.total_Money -= the_Stats.damage_Upgrade_Cost[upgrable_Weapon.current_Damage_Level];
                }
            }
        }
    }
    public void UpgradeAmmoSize()
    {
        if (the_Player_Manager.weapon_Unlock[weapon_Number])
        {
            if (the_Player_Manager.total_Money >= the_Stats.ammo_Upgrade_Cost[upgrable_Weapon.current_Ammo_Level])
            {
                if (upgrable_Weapon.current_Ammo_Level <= upgrable_Weapon.gun_Ammo_Capacity.Length)
                {
                    upgrable_Weapon.current_Ammo_Level++;
                    the_Player_Manager.total_Money -= the_Stats.ammo_Upgrade_Cost[upgrable_Weapon.current_Ammo_Level];
                }
            }
        }
    }

}
