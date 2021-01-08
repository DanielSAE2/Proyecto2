using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float directionX;
    private float directionY;
    public GameObject bait, posBait;
    public float speed = 10;
    public bool switchController = false;

    void Start()
    {
        bait.gameObject.SetActive (false); 
    }

    void Update()
    {
        if (!switchController)
        {
            //Límite del barco en la derecha
            if(transform.position.x <= 182)
            {
                directionX = Input.GetAxis("Horizontal");
                transform.position = new Vector2(transform.position.x + directionX * speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(182, transform.position.y);
            }
        }
        else
        {
            //Límite del bait al nivel del mar
            if (bait.transform.localPosition.y <= -4f)
            {
                //Límite del bait en los marcos laterales de la cámara
                if (bait.transform.localPosition.x >= -35 && bait.transform.localPosition.x <= 35)
                {
                    directionX = Input.GetAxis("Horizontal");
                    directionY = Input.GetAxis("Vertical");
                    bait.transform.position = new Vector2 (bait.transform.position.x + directionX * speed/3 * Time.deltaTime,
                                                           bait.transform.position.y + directionY * speed * Time.deltaTime);
                }
                else if (bait.transform.localPosition.x < -35)
                {
                    bait.transform.localPosition = new Vector2(-35, bait.transform.localPosition.y);
                }
                else if (bait.transform.localPosition.x > 35)
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

    //Al presionar espacio intercambia el bait entre activo e inactivo
    private void SwitchToBait()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switchController = !switchController;
            if (bait.gameObject.activeSelf == false)
            {
                bait.gameObject.SetActive(true);
            }
            else
            {
                bait.gameObject.SetActive(false);
                bait.transform.position = posBait.transform.position;
            }
        }
    }
}
