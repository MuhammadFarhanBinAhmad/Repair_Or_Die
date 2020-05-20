using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    Rigidbody2D the_RB;
    public float speed;
    public int damage;

    private void Awake()
    {
        the_RB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        the_RB.velocity = transform.right * speed * Time.deltaTime;
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
