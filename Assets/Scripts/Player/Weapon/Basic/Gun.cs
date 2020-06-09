using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bullet;
    public Transform spawn_Point;
    public Transform gun_Position;
    //fire rate
    public float fire_Rate;
    internal float next_Time_To_Fire = 0;
    //public int bullet_Left;
    public float reload_Time;
    public void FixedUpdate()
    {
        //Following mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5;//ensure z is in constant position

        Vector3 objectPos = Camera.main.WorldToScreenPoint(FindObjectOfType<PlayerManager>().transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        //rotation of object
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.position = gun_Position.position;
    }
}
