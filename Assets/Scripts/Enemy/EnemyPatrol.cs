using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Position Parameter")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy Parameter")]
    [SerializeField] private Transform enemy;
    [SerializeField] private float enemySpeed;
    [SerializeField] private Animator anim;
    [SerializeField] private float idleDuration;

    private Vector3 initScale;

    private bool movingLeft;

    private float idleTimer;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

// to stops "moving" animation
    private void OnDisable()
    {
        anim.SetBool("moving",false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                //change direction
                 direcctionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                //change direction
                direcctionChange();
            }
        }
    }

    private void direcctionChange()
    {
        anim.SetBool("moving",false);

        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving",true);

        // make enemy face direcction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, 
        initScale.y, 
        initScale.z);
        // move in the direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * enemySpeed, enemy.position.y + enemy.position.z);
    }

}
