﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BasicStates
{
    //ground check
    public Transform check_Ground;
    public LayerMask the_Ground;
    ////player special states
    //jump
    public float jump_Force = 5;
    public float fall_Multiplier = 2.5f;
    public float low_Jump_Multiplier = 2f;
    //Knockback
    public float the_Knock_Back_Force;
    bool is_Hit;
    //Truck
    TruckManager the_Truck_Manager;
    //Weapons
    public bool[] weapon_Unlock = new bool[4];
    public GameObject[] weapons = new GameObject[3];
    int current_Weapon;

    private void Start()
    {
        weapon_Unlock[0] = true;
    }

    private void Update()
    {
        PlayerMovement();
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E) && the_Truck_Manager !=null)
        {
            the_Truck_Manager.CurrentTruckHealth();
        }
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NewWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            NewWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            NewWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            NewWeapon(3);
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
    internal float TakingDamage(float damage)
    {
        print(entity_Health);
        return entity_Health -= damage;
    }

    void PlayerMovement()
    {
        //movement
        float H = Input.GetAxisRaw("Horizontal") * entity_Speed;

        entity_RB.velocity = new Vector2(H, entity_RB.velocity.y);
        if (is_Hit)
        {
            print("being hit");
            entity_RB.velocity = new Vector2(-the_Knock_Back_Force, the_Knock_Back_Force);//knockback
        }
        if (!is_Hit)
        {
            if (Input.GetAxisRaw("Horizontal") >= 0.1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetAxisRaw("Horizontal") <= -0.1)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
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
        print("hit1");
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
    }
}
