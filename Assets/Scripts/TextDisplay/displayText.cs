using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class displayText : MonoBehaviour
{
    [SerializeField] private GameObject ActiveText;
    private float time;

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ActiveText.SetActive(true);
            StartCoroutine(WaitForSeconds());
        }
    }
    private IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(2);
        ActiveText.SetActive(false);
    }
}
