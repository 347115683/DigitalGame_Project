using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource CollectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            CollectSoundEffect.Play();
            cherries++;
            if (cherries == 1)
            {
                Debug.Log("Cherry: " + cherries);
                cherriesText.text = "Cherry: " + cherries;
            }
            else
            {
            Debug.Log("Cherries: " + cherries);
            cherriesText.text = "Cherries: " + cherries;
            }
        }
    }
}
