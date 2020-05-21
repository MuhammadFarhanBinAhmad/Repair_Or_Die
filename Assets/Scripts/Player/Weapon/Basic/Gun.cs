using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bullet;
    public Transform spawn_Point;
    //fire rate
    public float fire_Rate;
    internal float next_Time_To_Fire = 0;
    //ammo
    public int bullet_Left;
    public float reload_Time;
    internal bool reloading;
    //upgradables
    public int[] gun_Ammo_Capacity = new int[4];
    public int[] damage_Multiplier = new int[3];
    //current level
    internal int current_Damage_Level;
    internal int current_Ammo_Level;

    private void Start()
    {
        bullet_Left = gun_Ammo_Capacity[0];
    }

    public void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(FindObjectOfType<PlayerManager>().transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.position = FindObjectOfType<PlayerManager>().transform.position;
    }
}
