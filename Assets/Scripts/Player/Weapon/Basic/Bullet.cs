using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    Rigidbody2D the_RB;
    public float speed;
    public float damage;

    float destroy_Time;

    public SO_BulletStates the_Bullet_Stats;

    private void Awake()
    {
        the_RB = GetComponent<Rigidbody2D>();
        speed = the_Bullet_Stats.speed;
        damage = the_Bullet_Stats.damage;
    }
    private void FixedUpdate()
    {
        the_RB.velocity = transform.right * speed * Time.deltaTime;

        destroy_Time -= Time.deltaTime;

        if (destroy_Time <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BaseAI>() != null)
        {
            other.GetComponent<BaseAI>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
