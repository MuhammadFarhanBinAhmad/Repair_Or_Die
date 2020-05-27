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
        destroy_Time = the_Bullet_Stats.destroy_Time;
    }
    private void FixedUpdate()
    {
        the_RB.velocity = transform.right * speed * Time.deltaTime;
    }
    void OnEnable()
    {
        Invoke("Destroy", 2.5f);
    }

    void OnDisable()
    {
        damage = the_Bullet_Stats.damage;
        CancelInvoke();
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BaseAI>() != null)
        {
            other.GetComponent<BaseAI>().TakeDamage(damage);
            Destroy();
        }
        if (other.gameObject.layer == 8)
        {
            Destroy();
        }
    }
}
