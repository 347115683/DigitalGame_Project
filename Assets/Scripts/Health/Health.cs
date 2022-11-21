using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set; }
    private bool death;
    [SerializeField] private AudioSource DeathSoundEffect;
    [SerializeField] private AudioSource HurtSoundEffect;
    [Header("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [SerializeField] private Behaviour[] components;

private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            //Player gets hurt
            HurtSoundEffect.Play();
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!death)
            {
                DeathSoundEffect.Play();
                anim.SetTrigger("death");

                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                
                death = true; 
            }
        }
    }

    public void addHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    private IEnumerator Invunerability()
    {
         Physics2D.IgnoreLayerCollision(8, 9, true);
         //Inbunerable time
         for (int i = 0; i < numberOfFlashes; i++)
         {
            spriteRend.color = new Color(1, 0, 0, .5f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
         }

         Physics2D.IgnoreLayerCollision(9, 10, false);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
