using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : BasicStates
{

    PlayerManager the_Player;

    private void Start()
    {
        the_Player = FindObjectOfType<PlayerManager>();
    }

    private void FixedUpdate()
    {
        if ((Vector3.Distance(the_Player.transform.position,transform.position) > 0.1f))
        {
            transform.position = Vector3.MoveTowards(transform.position, the_Player.transform.position, entity_Speed);
        }
    }

    public void TakeDamage(float damage)
    {
        entity_Health -= damage;
        if (entity_Health <= 0)
        {
            DestroyEntity();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerManager>() != null)
        {
            the_Player.TakingDamage(entity_Damage);
            the_Player.StartCoroutine("CurrentlyHit");
        }
    }
}
