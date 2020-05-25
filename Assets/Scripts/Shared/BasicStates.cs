using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BasicStates : MonoBehaviour
{
    //Basic States
    public SO_BasicStates entity_BasicStates;

    internal float entity_Health;
    internal float entity_Speed;
    internal float entity_Damage;

    public int entity_Min_Money, entity_Max_Money;

    //public Rigidbody2D entity_RB;

    private void Awake()
    {
        entity_Health = entity_BasicStates.health;
        entity_Speed = entity_BasicStates.speed;
        entity_Damage = entity_BasicStates.damage;
        entity_Min_Money = entity_BasicStates.min_Money;
        entity_Max_Money = entity_BasicStates.max_Money;
    }
    internal void DestroyEntity()
    {
        Destroy(gameObject);
    }
}
