using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool activeRP = false;
    [SerializeField] private ItemCollector numberOfItems;
    [SerializeField] private AudioSource DeathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        // run ainimation of respawn
        if (activeRP == true)
        {
            anim.SetTrigger("respawn"); 
            activeRP = false;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the tag is trap then runs following code
        if (collision.gameObject.CompareTag("Trap"))
        {
            DeathSoundEffect.Play();
            Die();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the tag is trap then runs following code
        if (collision.gameObject.CompareTag("FireTrap"))
        {
            DeathSoundEffect.Play();
            Die();
        }
        else 
        {
            if (collision.gameObject.CompareTag("Enemy") && numberOfItems.cherries<10)
            {
                DeathSoundEffect.Play();
                Die();
            }

        }
    }
 


// to play ainimation of death
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
// restart the game
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        activeRP = true;
    }
}
