using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : BaseAI
{
    public enum E_Current_State {Chasing,Charging };
    public E_Current_State current_State;

    public override void FixedUpdate()
    {
        CurrentAction();
    }
    void CurrentAction()
    {
        switch (current_State)
        {
            case E_Current_State.Chasing:
                {
                    float dist = transform.position.x - the_Player.transform.position.x;
                    if (dist >= 12.5f || dist <= -12.5f)
                    {
                        Vector2 target = new Vector2(the_Player.transform.position.x + 1.5f, transform.position.y);
                        transform.position = Vector2.MoveTowards(transform.position, target, entity_Speed);
                    }
                    else
                    {
                        current_State = E_Current_State.Charging;
                    }
                    break;
                }

            case E_Current_State.Charging:
                {
                    //transform.position = transform.right - the_Player.transform.position;
                    transform.position = Vector2.MoveTowards(transform.position, the_Player.transform.position, entity_Speed);
                    break;
                }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerManager>() !=null)
        {
            the_Player.TakingDamage(entity_Damage);
            the_Player.StartCoroutine("CurrentlyHit");
            Destroy(gameObject);
        }
    }
}
