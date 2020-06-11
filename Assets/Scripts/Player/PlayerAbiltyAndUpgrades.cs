using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbiltyAndUpgrades : MonoBehaviour
{
    PlayerManager the_Player_Manager;

    private void Start()
    {
        the_Player_Manager = FindObjectOfType<PlayerManager>();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            the_Player_Manager.entity_Health += 0.5f;
        }
    }

}
