using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    [Header ("Damage Parameters")]
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // if collider is taged player then lose health 
        if (collision.tag == "Player")
            collision.GetComponent<Health>().TakeDamage(damage);
    }
}