using System.Collections;
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
    //Ammo
    [Header("Ammo")]
    public TextMeshProUGUI Ammo;
    public GameObject ammo_Image;
    public GameObject player_Canvas;
    internal List<GameObject> ammo_UI = new List<GameObject>();
    public int ammo_Pool_Amount;
    //Money 
    [Header("Money")]
    public TextMeshProUGUI Money;

    private void Start()
    {
        for (int i = 0; i <= ammo_Pool_Amount; i++)
        {
            GameObject O = Instantiate(ammo_Image);
            ammo_UI.Add(O);
            O.SetActive(false);
            GameObject.DontDestroyOnLoad(O);
        }
        the_Player_Manager = FindObjectOfType<PlayerManager>();
        UpdateAmmoUI(0);
    }
    public void UpdateHealthUI()
    {
        player_Health_Bar.fillAmount = the_Player_Manager.entity_Health / the_Player_Manager.entity_BasicStates.health;
    }
    public void UpdateMoneyUI()
    {
        Money.text = "$"+the_Player_Manager.total_Money.ToString();
    }
    public void UpdateAmmoUI(int AM)
    {

        for (int i = 0; i <= the_Player_Manager.weapons[AM].GetComponent<BaseGun>().bullet_Left-1; i++)
        {
            //if (!ammo_UI[i].activeInHierarchy)
            {
                /*
                the_OPB.bullet_List[i].transform.position = spawn_Point.position;
                the_OPB.bullet_List[i].transform.rotation = spawn_Point.rotation;
                the_OPB.bullet_List[i].GetComponent<Bullet>().the_Bullet_Stats = the_Bullet_Data;
                the_OPB.bullet_List[i].SetActive(true);
                DamageLevel(current_i);
                bullet_Left--;
                break;*/
                /*ammo_UI[i].transform.parent = player_Canvas.transform;
                ammo_UI[i].transform.position = player_Canvas.transform.position;
                ammo_UI[i].transform.rotation = player_Canvas.transform.rotation;*/
                ammo_UI[i].SetActive(true);
                ammo_UI[i].transform.parent = player_Canvas.transform;
                ammo_UI[i].transform.position = player_Canvas.transform.position;
                ammo_UI[i].transform.rotation = player_Canvas.transform.rotation;
                //break;
            }
        }
    }
}
