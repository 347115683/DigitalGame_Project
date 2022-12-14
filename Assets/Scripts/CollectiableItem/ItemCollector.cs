using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    public int cherries;
    [SerializeField] private Text cherriesText;

    [SerializeField] private AudioSource CollectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the tag has a tag of Cherry
        if (collision.gameObject.CompareTag("Cherry"))
        {
            //Destroy the object of Cherry
            Destroy(collision.gameObject);
            // play sound effects
            CollectSoundEffect.Play();
            // count the number of collected cherries 
            cherries++;   
            //display in the console
            //Debug.Log("Cherry: " + cherries );
                cherriesText.text = "x " + cherries ;

        }
    }
}
