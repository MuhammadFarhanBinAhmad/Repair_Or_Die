﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerUI : MonoBehaviour
{
    PlayerManager the_Player_Manager;
    //health
    [Header("Health")]
    public Image player_Health_Bar;
    public TextMeshProUGUI health_Text;
    //Ammo
    [Header("Ammo")]
    public List<GameObject> gun_Images = new List<GameObject>();
    //public GameObject ammo_Image;
    public GameObject player_Canvas;
    public GameObject the_Reloading_Text;
    /*public Transform bullet_Starting_Trans;
    internal List<GameObject> ammo_UI = new List<GameObject>();
    public List<GameObject> current_Ammo_UI = new List<GameObject>();
    public int ammo_Pool_Amount;*/
    public TextMeshProUGUI ammo_Text;
    internal int magazine_Capacity;
    //Money 
    [Header("Money")]
    public TextMeshProUGUI Money;
    public TextMeshProUGUI Money_Shop;
    [Header("GameOverScreen")]
    Animator the_Anim;
    public GameObject game_Over_Screen;

    private void Start()
    {
        the_Anim = GetComponent<Animator>();
        //object pool ammo UI
        /*for (int i = 0; i <= ammo_Pool_Amount; i++)
        {
            GameObject O = Instantiate(ammo_Image);
            ammo_UI.Add(O);
            O.SetActive(false);
            GameObject.DontDestroyOnLoad(O);
            O.transform.parent = player_Canvas.transform;
        }*/
        the_Player_Manager = FindObjectOfType<PlayerManager>();
        UpdateAmmoUI(0);
    }
    private void FixedUpdate()
    {
        if (the_Player_Manager.weapons[the_Player_Manager.current_Weapon].GetComponent<BaseGun>().reloading)
        {
            the_Reloading_Text.SetActive(true);
        }
        else
        {
            the_Reloading_Text.SetActive(false);
        }
    }
    public void UpdateHealthUI()
    {
        player_Health_Bar.fillAmount = the_Player_Manager.entity_Health / the_Player_Manager.entity_BasicStates.health;
        health_Text.text = the_Player_Manager.entity_Health.ToString("0") + "/100";
    }
    public void UpdateMoneyUI()
    {
        Money.text = "$"+ FindObjectOfType<PlayerManager>().total_Money.ToString();
        Money_Shop.text = "$" + FindObjectOfType<PlayerManager>().total_Money.ToString();
    }
    public void UpdateAmmoUI(int AM)
    {
        ammo_Text.text = the_Player_Manager.weapons[AM].GetComponent<BaseGun>().gun_Ammo_Capacity[the_Player_Manager.weapons[AM].GetComponent<BaseGun>().current_Ammo_Level].ToString() + "/" + the_Player_Manager.weapons[AM].GetComponent<BaseGun>().bullet_Left;
    }
    /*public void UpdateAmmoUI(int AM)
    {
        ////Creating ammo UI for current weapon
        //Remove all ammo image from last weapon
        for (int i = 0; i <= gun_Images.Count-1 ;i++)
        {
            gun_Images[i].SetActive(false);
        }
        gun_Images[AM].SetActive(true);//weapon image
        //spawn current weapon total ammo count
        for (int i = 0; i <= ammo_Pool_Amount; i++)
        {
            ammo_UI[i].SetActive(false);
        }
        current_Ammo_UI.Clear();
        //Placement and postion of eacg ammo UI in canvas
        for (int i = 0; i <= the_Player_Manager.weapons[AM].GetComponent<BaseGun>().bullet_Left-1; i++)
        {
            {
                ammo_UI[i].SetActive(true);
                if (i == 0)
                {
                    ammo_UI[i].transform.position = bullet_Starting_Trans.transform.position;
                }
                else
                {
                    ammo_UI[i].transform.position = new Vector2(ammo_UI[i - 1].transform.position.x + 17, ammo_UI[i - 1].transform.position.y);
                    if (ammo_UI[i].transform.position.x >= bullet_Starting_Trans.transform.position.x + 375)
                    {
                        if (ammo_UI[i].transform.position.x != bullet_Starting_Trans.transform.position.x)
                        {
                            ammo_UI[i].transform.position = new Vector2(bullet_Starting_Trans.transform.position.x, ammo_UI[i - 1].transform.position.y - 15);
                        }
                        else
                        ammo_UI[i].transform.position = new Vector2(ammo_UI[i - 1].transform.position.x + 17, ammo_UI[i - 1].transform.position.y - 15);
                    }
                }

                ammo_UI[i].transform.rotation = player_Canvas.transform.rotation;
                current_Ammo_UI.Add(ammo_UI[i]);
                //break;
            }
        }
    }
    //removing ammo image
    public void RemoveAmmoUI()
    {
        current_Ammo_UI[current_Ammo_UI.Count - 1].SetActive(false);
        current_Ammo_UI.Remove(current_Ammo_UI[current_Ammo_UI.Count - 1]);
    }*/
    IEnumerator GameOverScreen()
    {
        game_Over_Screen.SetActive(true);
        the_Anim.SetTrigger("GameOver");
        yield return new WaitForSeconds(the_Anim.GetCurrentAnimatorClipInfo(0).Length);//get length of current animation
        Cursor.visible = true;
        //Time.timeScale = 0;
    }
}
