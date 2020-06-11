﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BasicStates
{
    //ground check
    public Transform check_Ground;
    public LayerMask the_Ground;
    ////player special states
    public Rigidbody2D entity_RB;
    //jump
    public float jump_Force = 5;
    public float fall_Multiplier = 2.5f;
    public float low_Jump_Multiplier = 2f;
    //Knockback
    public float the_Knock_Back_Force;
    bool is_Hit;
    //Weapons
    /// <summary>
    /// 0 = Pistol
    /// 1 = MachineGun
    /// 2 = Sniper
    /// 3 = Shotgun
    /// </summary>
    public bool[] weapon_Unlock = new bool[4];
    public GameObject[] weapons = new GameObject[3];
    internal int current_Weapon;
    //Interaction
    internal bool repairing_Truck;
    TruckManager the_Truck_Manager;
    public ShopManager the_Shop_Manager;
    //Money
    public int total_Money;
    public static int total_Money_Collected;
    //UI
    PlayerUI the_Player_UI;
    public GameObject pause_Menu;
    bool pause_Menu_Open;
    //testing
    public float player_Health_Regen;
    bool currently_Moving;

    private void Start()
    {
        entity_RB = GetComponent<Rigidbody2D>();
        the_Player_UI = FindObjectOfType<PlayerUI>();
        the_Player_UI.UpdateMoneyUI();
        weapon_Unlock[0] = true;
    }

    private void Update()
    {
        PlayerMovement();
        if (entity_Health > 0)
        { 
            {
                if (Input.GetKeyDown(KeyCode.Escape) && !the_Shop_Manager.shop_Open)
                {
                    if (!pause_Menu_Open)
                    {
                        OpenPauseMenu();
                    }
                    else
                    {
                        ClosePauseMenu();
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && the_Shop_Manager != null )
        {
            if (the_Shop_Manager.shop_Open)
            {
                the_Shop_Manager.CloseStoreMenu();
                if (Time.timeScale != 1)
                {
                    Time.timeScale = 1;
                }
            }
            else
            {
                the_Shop_Manager.OpenStoreMenu();
                if (Time.timeScale != 0)
                {
                    Time.timeScale = 0;
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.P) && entity_RB.velocity.x ==0 && !repairing_Truck)
        {
            if (entity_Health < 100)
            {
                entity_Health += player_Health_Regen;
                the_Player_UI.UpdateHealthUI();
            }
        }
        if (Input.GetKey(KeyCode.E) && the_Truck_Manager != null)
        {
            repairing_Truck = true;
            the_Truck_Manager.CurrentTruckHealth();
        }
        else
        {
            repairing_Truck = false;
        }
    }
    public void OpenPauseMenu()
    {
        pause_Menu.SetActive(true);
        pause_Menu_Open = true;
        Cursor.visible = true;
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }
    public void ClosePauseMenu()
    {
        pause_Menu.SetActive(false);
        pause_Menu_Open = false;
        Cursor.visible = false;
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeWeapon(3);
        }
    }
    void ChangeWeapon(int i)
    {
        if (weapon_Unlock[i])
        {
            weapons[current_Weapon].GetComponent<BaseGun>().reloading = false;
            NewWeapon(i);
            the_Player_UI.UpdateAmmoUI(i);
        }
    }
    internal bool isGrounded()
    {
        if (Physics2D.OverlapArea(new Vector2(check_Ground.position.x, check_Ground.position.y), new Vector2(check_Ground.position.x + 1, check_Ground.position.y + 1), the_Ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    internal void TakingDamage(float damage)
    {
        entity_Health -= damage;
        if (entity_Health <= 0)
        {
            the_Player_UI.StartCoroutine("GameOverScreen");
        }
    }

    internal void MoneyEarn(int M)
    {
        total_Money += M;
        total_Money_Collected += M;
    }
    void PlayerMovement()
    {
        if (is_Hit)
        {
            entity_RB.velocity = new Vector2(-the_Knock_Back_Force, the_Knock_Back_Force);//knockback
        }
        if (!repairing_Truck)
        {
            if (!is_Hit)
            {
                /*if (Input.GetAxisRaw("Horizontal") >= 0.1)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if (Input.GetAxisRaw("Horizontal") <= -0.1)
                {
                    transform.rotation = Quaternion.Euler(0, -180, 0);
                }*/
                //movement
                float H = Input.GetAxisRaw("Horizontal") * entity_Speed;

                entity_RB.velocity = new Vector2(H, entity_RB.velocity.y);
                //jumping
                if (Input.GetButtonDown("Jump") && isGrounded())
                {
                    float JF = jump_Force;
                    entity_RB.AddForce(Vector2.up * JF);
                }
                //falling speed
                //holding jumping button
                if (entity_RB.velocity.y < 0)
                {
                    entity_RB.velocity += Vector2.up * Physics2D.gravity.y * (fall_Multiplier - 1) * Time.deltaTime;
                }
                //not holding jump button
                else if (entity_RB.velocity.y > 0 && !Input.GetButton("Jump"))
                {
                    entity_RB.velocity += Vector2.up * Physics2D.gravity.y * (low_Jump_Multiplier - 1) * Time.deltaTime;
                }
            }
        }
    }
    public void NewWeapon(int NW)
    {
        if (weapon_Unlock[NW])
        {
            weapons[current_Weapon].SetActive(false);
            switch (NW)
            {
                case 0:
                    {
                        weapons[0].SetActive(true);
                        break;
                    }
                case 1:
                    {
                        weapons[1].SetActive(true);
                        break;
                    }
                case 2:
                    {
                        weapons[2].SetActive(true);
                        break;
                    }
                case 3:
                    {
                        weapons[3].SetActive(true);
                        break;
                    }
            }
            current_Weapon = NW;
        }
    }
    public IEnumerator CurrentlyHit()
    {
        is_Hit = true;
        yield return new WaitForSeconds(1);
        is_Hit = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<TruckManager>()!=null)
        {
            the_Truck_Manager = other.GetComponent<TruckManager>();
        }
        if (other.GetComponent<ShopManager>() != null)
        {
            the_Shop_Manager = other.GetComponent<ShopManager>();
            the_Shop_Manager.OpenPopUpUI();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<TruckManager>() != null)
        {
            the_Truck_Manager = null;
        }
        if (other.GetComponent<ShopManager>() != null)
        {
            the_Shop_Manager.ClosePopUpUI();

            the_Shop_Manager = null;
        }
    }
}