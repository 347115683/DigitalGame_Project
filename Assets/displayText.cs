using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class displayText : MonoBehaviour
{
    [SerializeField] private Text PlayerText;
    [SerializeField] private GameObject ActiveText;
    private bool collisionDetect;

    private float time;
     private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            PlayerText.text = "MOVE LEFT TO THE SAFE HOUSE";
            ActiveText.SetActive(true);
        }
    }

    private void nonText()
    {
        PlayerText.text = "";
    }

}
