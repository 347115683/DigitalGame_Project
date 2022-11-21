using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        // change facing direction
        if (aiPath.desiredVelocity.x > .01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x < -.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
