using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player, bait;

    private bool followPlayer;
    private bool followBait;
    
    void Start()
    {
        followPlayer = false;
        followBait = false;
    }

    void Update()
    {
        //El bait sigue al player
        Vector3 fPlayer = player.transform.position;
        fPlayer.z = transform.position.z;

        Vector3 fBait = bait.transform.position;
        fBait.z = transform.position.z;
        fBait.x = transform.position.x;
        
        if (player.transform.position.x <= 155f)
        {
            followPlayer = true;
        }
        else
        {
            followPlayer = false;
        }
    
        if (followPlayer)
        {  
            if (!followBait)
            {
                transform.position = Vector3.MoveTowards(transform.position, fPlayer, 10);    
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, fBait, 10);    
            }
        }

        SwitchToBaitCamera();
    }

    //Al presionar espacio se intercambia la cámara al bait
    private void SwitchToBaitCamera()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            followBait = !followBait;
        }
    }
}
