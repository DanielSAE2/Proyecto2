using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float directionX;
    private float directionY;
    public GameObject bait;
    public float speed = 10;
    public bool switchController = false;

    void Start()
    {
        bait.gameObject.SetActive (false); 
    }

    void Update()
    {
        if(!switchController)
        {
            directionX = Input.GetAxis("Horizontal");
            transform.position = new Vector2(transform.position.x + directionX * speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            if (bait.transform.localPosition.y <= -4f)
            {

                if(bait.transform.localPosition.x >= -35 && bait.transform.localPosition.x <= 35)
                {
                    directionX = Input.GetAxis("Horizontal");
                    directionY = Input.GetAxis("Vertical");
                    bait.transform.position = new Vector2(bait.transform.position.x + directionX * speed/3 * Time.deltaTime,
                                                        bait.transform.position.y + directionY * speed * Time.deltaTime);
                }
                else if(bait.transform.localPosition.x < -35)
                {
                    bait.transform.localPosition = new Vector2(-35, bait.transform.localPosition.y);
                }
                else if(bait.transform.localPosition.x > 35)
                {
                    bait.transform.localPosition = new Vector2(35, bait.transform.localPosition.y);
                }
            }
            else
            {
                bait.transform.localPosition = new Vector2(bait.transform.localPosition.x, -4f);

            }
        }
        SwitchToBait();
    }

    private void SwitchToBait()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switchController = !switchController;
            bait.gameObject.SetActive (true);
        }
    }
}
