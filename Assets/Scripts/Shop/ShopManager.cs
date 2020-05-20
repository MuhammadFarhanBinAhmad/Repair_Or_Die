using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{

    LevelManager the_Level_Manager;

    public Image shop_UI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (the_Level_Manager.wave_Ended)
        {
            Time.timeScale = 0;
        }
    }
}
