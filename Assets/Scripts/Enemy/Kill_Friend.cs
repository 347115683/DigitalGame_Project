using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Friend : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Friend"))
        {
            Destroy(collision.gameObject);
        }
    }
}
