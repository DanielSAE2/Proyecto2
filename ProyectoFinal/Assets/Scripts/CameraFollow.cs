using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player, bait;

    private bool followPlayer;
    private bool followBait;
    // Start is called before the first frame update
    void Start()
    {
        followPlayer = true;
        followBait = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fPlayer = player.transform.position;
        fPlayer.z = transform.position.z;

        Vector3 fBait = bait.transform.position;
        fBait.z = transform.position.z;
        fBait.x = transform.position.x;
        /*if (player.transform.position.x >= 321f)
        {
            follow = true;
        }*/ 
    
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

    private void SwitchToBaitCamera()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            followBait = !followBait;
        }
    }
}
