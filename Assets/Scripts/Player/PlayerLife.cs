using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool activeRP = false;

[SerializeField] private AudioSource DeathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the tag is trao then runs
        if (collision.gameObject.CompareTag("Trap"))
        {
            DeathSoundEffect.Play();
            Die();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            DeathSoundEffect.Play();
            Die();
        }
    }


// to play ainimation of death

    private void Die()
    {
        activeRP = true;
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // run ainimation of respawn
        if (activeRP == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
            anim.SetTrigger("respawn"); 




    }
}
