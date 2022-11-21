using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectiable : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioSource CollectSoundEffect;

   private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.tag == "Player")
        {
            CollectSoundEffect.Play();
            collision.GetComponent<Health>().addHealth(healthValue);
            gameObject.SetActive(false);
        }
   }
}
