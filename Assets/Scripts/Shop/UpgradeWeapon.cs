using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeWeapon : MonoBehaviour
{
    public BaseGun upgrable_Weapon;

    public Image shop_UI;

    public void UpgradeDamage()
    {
        if (upgrable_Weapon.current_Damage_Level<= upgrable_Weapon.damage_Multiplier.Length-1)
        {
            upgrable_Weapon.current_Damage_Level++;
        }
    }
    public void UpgradeAmmoSize()
    {
        if (upgrable_Weapon.current_Ammo_Level <= upgrable_Weapon.gun_Ammo_Capacity.Length - 1)
        {
            upgrable_Weapon.current_Ammo_Level++;
        }
    }

}
