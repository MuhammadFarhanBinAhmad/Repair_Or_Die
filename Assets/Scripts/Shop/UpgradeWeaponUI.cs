using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeWeaponUI : MonoBehaviour
{
    public TextMeshProUGUI buy_Cost, ammo_Cost, damage_Cost;
    UpgradeWeapon the_Upgrade_Weapon;
    public GameObject buy_Button;

    private void Start()
    {
        the_Upgrade_Weapon = GetComponent<UpgradeWeapon>();
        BuyingCostUI();
        UpdateAmmoCostUI();
        UpdateDamageCostUI();
    }

    void BuyingCostUI()
    {
        if (buy_Cost !=null)
        {
            buy_Cost.text = "$" + the_Upgrade_Weapon.the_Stats.buying_Price.ToString();
        }
    }

    public void UpdateAmmoCostUI()
    {
        if (the_Upgrade_Weapon.upgrable_Weapon.current_Ammo_Level == the_Upgrade_Weapon.upgrable_Weapon.gun_Ammo_Capacity.Length - 1)
        {
            ammo_Cost.text = "Sold Out";
        }
        else
        ammo_Cost.text = "$" + the_Upgrade_Weapon.the_Stats.ammo_Upgrade_Cost[the_Upgrade_Weapon.upgrable_Weapon.current_Ammo_Level].ToString();
    }
    public void UpdateDamageCostUI()
    {
        if (the_Upgrade_Weapon.upgrable_Weapon.current_Damage_Level == the_Upgrade_Weapon.upgrable_Weapon.damage_Multiplier.Length - 1)
        {
            damage_Cost.text = "Sold Out";
        }
        else
            damage_Cost.text = "$" + the_Upgrade_Weapon.the_Stats.damage_Upgrade_Cost[the_Upgrade_Weapon.upgrable_Weapon.current_Damage_Level].ToString();
    }
    public void BoughtWeapon()
    {
        buy_Button.GetComponent<Button>().interactable = false;
        ColorBlock colour = buy_Button.GetComponent<Button>().colors;
        colour.normalColor = Color.grey;
        buy_Button.GetComponent<Button>().colors = colour;
        buy_Cost.text = "Sold";
    }

}
