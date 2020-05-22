using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    PlayerManager the_Player_Manager;
    public GameObject shop_UI;
    internal bool shop_Open;

    private void Start()
    {
        the_Player_Manager = FindObjectOfType<PlayerManager>();
    }
    public void OpenStoreMenu()
    {
        shop_UI.SetActive(true);
        shop_Open = true;
        Time.timeScale = 0.001f;
    }
    public void CloseStoreMenu()
    {
        shop_UI.SetActive(false);
        shop_Open = false;
        Time.timeScale = 1;
    }
    public void UnlockWeapon(int weapon)
    {
        the_Player_Manager.weapon_Unlock[weapon] = true;
    }
}
