using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireTrap : MonoBehaviour
{

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private Rigidbody2D rb;

    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool triggered;
    private bool active;

    private void Awake()
    {
    anim = GetComponent<Animator>();
    spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActivateFireTrap());
            }
            if (active)
            {
                collision.gameObject.transform.tag = "trap";
            }
        }
    }


    private IEnumerator ActivateFireTrap()
    {
        triggered = true;
        spriteRend.color = Color.red;


        //wait for delay, activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated",true);

        //wait until X seconds, deactivate trap and reset all variable and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated",false);
    }
}
