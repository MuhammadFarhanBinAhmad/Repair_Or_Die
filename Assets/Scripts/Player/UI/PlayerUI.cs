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
    public GameObject ammo_Image;
    public GameObject player_Canvas;
    public Transform bullet_Starting_Trans;
    internal List<GameObject> ammo_UI = new List<GameObject>();
    public List<GameObject> current_Ammo_UI = new List<GameObject>();
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
            O.transform.parent = player_Canvas.transform;
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
        Money.text = "$"+ FindObjectOfType<PlayerManager>().total_Money.ToString();
    }
    public void UpdateAmmoUI(int AM)
    {
        for (int i = 0; i <= ammo_Pool_Amount; i++)
        {
            ammo_UI[i].SetActive(false);
        }
        current_Ammo_UI.Clear();
        for (int i = 0; i <= the_Player_Manager.weapons[AM].GetComponent<BaseGun>().bullet_Left-1; i++)
        {
            //if (!ammo_UI[i].activeInHierarchy)
            {

                ammo_UI[i].SetActive(true);
                if (i == 0)
                {
                    ammo_UI[i].transform.position = bullet_Starting_Trans.transform.position;
                }
                else
                {
                    ammo_UI[i].transform.position = new Vector2(ammo_UI[i - 1].transform.position.x + 20, ammo_UI[i - 1].transform.position.y);
                }
                ammo_UI[i].transform.rotation = player_Canvas.transform.rotation;
                current_Ammo_UI.Add(ammo_UI[i]);
                //break;
            }
        }
    }
    public void RemoveAmmoUI()
    {
        current_Ammo_UI[current_Ammo_UI.Count - 1].SetActive(false);
        current_Ammo_UI.Remove(current_Ammo_UI[current_Ammo_UI.Count - 1]);
    }
}
