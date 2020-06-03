using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    PlayerManager the_Player_Manager;
    EnemySpawnManager the_Enemy_Spawn_Manager;

    public GameObject shop_UI;
    public GameObject pop_Up_UI;

    public bool shop_Open;
    bool weapon_Bought;

    Animator shop_Anim;

    private void Start()
    {
        the_Player_Manager = FindObjectOfType<PlayerManager>();
        the_Enemy_Spawn_Manager = FindObjectOfType<EnemySpawnManager>();
        shop_Anim = GetComponent<Animator>();
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
    public void OpenPopUpUI()
    {
       pop_Up_UI.SetActive(true);
    }
    public void ClosePopUpUI()
    {
        pop_Up_UI.SetActive(false);
    }
    public void OpeningStore()
    {
        if (the_Enemy_Spawn_Manager.wave_Ended)
        {
            shop_Anim.SetBool("Opening", true);
        }
        else
        {
            shop_Anim.SetBool("Opening", false);
        }
    }
}
