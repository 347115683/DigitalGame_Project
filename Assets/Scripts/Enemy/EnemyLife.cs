using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    
    public bool EnemyAlive = true; 
    [SerializeField] private AudioSource DeathSoundEffect;

    [SerializeField] private ItemCollector numberOfItems;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the tag is trap then runs following code
        if (collision.gameObject.CompareTag("Trap"))
        {
            EnemyAlive = false;
            Die();
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the tag is trap then runs following code
        {
            if (collision.gameObject.CompareTag("Player") && numberOfItems.cherries>=10)
            {
                EnemyAlive = false;
                Die();
            }
        }
    }
    
// to play ainimation of death
    private void Die()
    {
        EnemyAlive = false;
        DeathSoundEffect.Play();
        Destroy(gameObject);
    }

}
