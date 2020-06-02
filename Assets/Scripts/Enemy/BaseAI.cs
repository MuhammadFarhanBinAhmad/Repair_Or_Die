using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : BasicStates
{
    internal PlayerManager the_Player;

    EnemySpawnManager the_Enemy_Spawn_Manager;

    EnemyUI entity_UI;

    private void Start()
    {
        the_Player = FindObjectOfType<PlayerManager>();
        the_Enemy_Spawn_Manager = FindObjectOfType<EnemySpawnManager>();
        entity_UI = GetComponent<EnemyUI>();
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
        entity_UI.TakeDamageUI(damage);
        if (entity_Health <= 0)
        {
            int M = Random.Range(entity_Min_Money, entity_Max_Money);
            the_Player.MoneyEarn(M);
            FindObjectOfType<PlayerUI>().UpdateMoneyUI();
            DestroyEntity();
            the_Enemy_Spawn_Manager.total_Enemy_Left--;
            the_Enemy_Spawn_Manager.CurentEnemyLeftUI();
            the_Enemy_Spawn_Manager.StartCoroutine("WaveEnded");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerManager>() != null)
        {
            the_Player.TakingDamage(entity_Damage);
            FindObjectOfType<PlayerUI>().UpdateHealthUI();
            the_Player.StartCoroutine("CurrentlyHit");
        }
    }
}
