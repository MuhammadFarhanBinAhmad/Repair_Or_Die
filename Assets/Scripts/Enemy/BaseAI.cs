using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : BasicStates
{

    internal PlayerManager the_Player;

    private void Start()
    {
        the_Player = FindObjectOfType<PlayerManager>();
    }

    public virtual void FixedUpdate()
    {
        ChasePlayer();
    }
    internal void ChasePlayer()
    {
        if ((Vector3.Distance(the_Player.transform.position, transform.position) > 0.1f))
        {
            Vector2 target = new Vector2(the_Player.transform.position.x + 1.5f, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, entity_Speed);
        }
    }
    public void TakeDamage(float damage)
    {
        entity_Health -= damage;
        if (entity_Health <= 0)
        {
            the_Player.MoneyEarn(Random.Range(entity_Min_Money, entity_Max_Money));
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
