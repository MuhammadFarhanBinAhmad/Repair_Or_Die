using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            other.GetComponent<PlayerManager>().TakingDamage(damage);
        }
    }
}
