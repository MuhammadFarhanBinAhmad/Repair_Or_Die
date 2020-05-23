using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BaseAI>() != null)
        {
            other.GetComponent<BaseAI>().TakeDamage(damage);
        }
    }
}
