using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class BasicStates : MonoBehaviour
{
    //Basic States
    public SO_BasicStates entity_BasicStates;

    protected float entity_Health;
    protected float entity_Speed;
    protected float entity_Damage;

    public Rigidbody2D entity_RB;

    private void Awake()
    {
        entity_Health = entity_BasicStates.health;
        entity_Speed = entity_BasicStates.speed;
        entity_Damage = entity_BasicStates.damage;

        entity_RB = GetComponent<Rigidbody2D>();
    }
    internal void DestroyEntity()
    {
        Destroy(gameObject);
    }
}
