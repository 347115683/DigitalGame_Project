using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    
    [Header ("Sound Parameter")]
    [SerializeField] private AudioSource DeathSoundEffect;
    [Header ("Player Parameter")]
    [SerializeField] private ItemCollector numberOfItems;
    public bool EnemyAlive = true; 

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
        //if collision is tagged as trap then runs following code
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
        // destory the object in the scene
        Destroy(gameObject);
    }

}
