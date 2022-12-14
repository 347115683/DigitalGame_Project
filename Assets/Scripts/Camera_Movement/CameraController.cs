using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header ("Player Parameters")]
    [SerializeField]private Transform player;
    private void Update()
    {
        //update the position of the player per frame 
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
    }
}
