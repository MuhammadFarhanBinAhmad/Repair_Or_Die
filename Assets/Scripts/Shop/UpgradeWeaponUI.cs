using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpgradeWeaponUI : MonoBehaviour
{
    public TextMeshProUGUI buy_Cost, ammo_Cost, damage_Cost;
    UpgradeWeapon the_Upgrade_Weapon;

    private void Start()
    {
        the_Upgrade_Weapon = GetComponent<UpgradeWeapon>();
        BuyingCostUI();
        UpdateAmmoCostUI();
        UpdateDamageCostUI();
    }

    void BuyingCostUI()
    {
        buy_Cost.text = "$"+the_Upgrade_Weapon.the_Stats.buying_Price.ToString();
    }

    public void UpdateAmmoCostUI()
    {
        ammo_Cost.text = "$" + the_Upgrade_Weapon.the_Stats.ammo_Upgrade_Cost[the_Upgrade_Weapon.upgrable_Weapon.current_Ammo_Level].ToString();
    }
    public void UpdateDamageCostUI()
    {
        damage_Cost.text = "$" + the_Upgrade_Weapon.the_Stats.damage_Upgrade_Cost[the_Upgrade_Weapon.upgrable_Weapon.current_Damage_Level].ToString();
    }
}
