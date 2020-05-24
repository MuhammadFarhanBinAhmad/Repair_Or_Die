using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    PlayerManager the_Player_Manager;
    public GameObject shop_UI;

    public bool shop_Open;
    bool weapon_Bought;

    private void Start()
    {
        the_Player_Manager = FindObjectOfType<PlayerManager>();
    }
    public void OpenStoreMenu()
    {
        shop_Open = true;
        shop_UI.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseStoreMenu()
    {
        shop_Open = false;
        shop_UI.SetActive(false);
        Time.timeScale = 1;
    }

}
