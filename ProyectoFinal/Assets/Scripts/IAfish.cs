using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAfish : MonoBehaviour
{
    public enum STATES { PATROL, SEEK, FIGHT, FIGHT0, FIGHT1, FIGHT2, FIGHT3, FIGHT4, FIGHT5, FIGHT6, FIGHT7, RUN}
    public STATES currentState;
    public GameObject Initpoint, Lastpoint;
    public GameObject Hook;
    private bool LoockedOn, Hooked, Catched;
    public bool Arrived;
    private float pullcount;
    private Vector3 palPez;
    public float FishForce, Tirones, Mash; 
    // Start is called before the first frame update
    void Start()
    {
        currentState = STATES.PATROL;
        LoockedOn = false;
        Hooked = false;
        Arrived = false;
        FishForce = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Catched)
        {
            switch (currentState)
            {
                case STATES.PATROL:
                    if (!LoockedOn)
                    {
                        if(!Arrived)
                        {
                            if (transform.position == Initpoint.transform.position)
                            {
                                Arrived = true;
                            }
                            transform.position = Vector3.MoveTowards(transform.position, Initpoint.transform.position, 10f * Time.deltaTime);
                        }
                        else
                        {
                            if (transform.position == Lastpoint.transform.position)
                            {
                                Arrived = false;
                            }
                            transform.position = Vector3.MoveTowards(transform.position, Lastpoint.transform.position, 10f * Time.deltaTime);
                        }
                    }
                    else
                    {
                        currentState = STATES.SEEK;
                    }
                    break;
                case STATES.SEEK:
                    if (!Hooked)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, Hook.transform.position, 10f * Time.deltaTime);
                        if (transform.position == Hook.transform.position)
                        {
                            Hooked = true;
                        }
                        if (!LoockedOn)
                        {
                            currentState = STATES.PATROL;
                        }
                    }
                    else
                    {
                        currentState = STATES.FIGHT;
                    }
                    break;
                case STATES.FIGHT:

                    float dir = Random.Range(0, 7);
                    Mash = 0;
                    if (Tirones == 3)
                    {
                        Catched = true;
                    }
                    if (dir == 0)
                    {
                        currentState = STATES.FIGHT0;
                    }
                    if(dir == 1)
                    {
                        currentState = STATES.FIGHT1;
                    }
                    if(dir == 2)
                    {
                        currentState = STATES.FIGHT2;
                    }
                    if(dir == 3)
                    {
                        currentState = STATES.FIGHT3;
                    }
                    if(dir == 4)
                    {
                        currentState = STATES.FIGHT4;
                    }
                    if(dir == 5)
                    {
                        currentState = STATES.FIGHT5;
                    }
                    if(dir == 6)
                    {
                        currentState = STATES.FIGHT6;
                    }
                    if(dir == 7)
                    {
                        currentState = STATES.FIGHT7;
                    }             
                    break;

                case STATES.FIGHT0:
                    pullcount += Time.deltaTime;
                    Hook.transform.position = transform.position;
                    FishForce = 1;
                    if(pullcount < 5)
                    {
                        palPez = new Vector3(transform.position.x, 1000, transform.position.z);
                        if (FishForce == 1)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, palPez, 10f * Time.deltaTime);
                            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
                        }
                        else
                        {
                                transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                        }
                        if (Input.GetKeyDown(KeyCode.S))
                        {
                                FishForce = 0;
                                Mash += 1;
                        }
                        if (Input.GetKeyUp(KeyCode.S))
                        {
                                FishForce = 1;
                        }
                    }
                    else
                    {
                        if (Mash >= 7)
                        {
                            Tirones += 1;
                            pullcount = 0;
                            currentState = STATES.FIGHT;
                        }
                        else
                        {
                            currentState = STATES.RUN;
                        }
                    }
                    break;
                case STATES.FIGHT1:
                    pullcount += Time.deltaTime;
                    Hook.transform.position = transform.position;
                    FishForce = 1;
                    if(pullcount < 5)
                    {
                        palPez = new Vector3(1000, 1000, transform.position.z);
                        if (FishForce == 1)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, palPez, 10f * Time.deltaTime);
                            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 45);
                            pullcount += Time.deltaTime;
                        }
                        else
                        {
                            transform.position = new Vector2(transform.position.x - 1, transform.position.y - 1);
                        }
                        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A))
                        {
                            FishForce = 0;
                            Mash += 1;
                        }
                        if (Input.GetKeyUp(KeyCode.S) && Input.GetKeyDown(KeyCode.A))
                        {
                            FishForce = 1;
                        }
                    }
                    else
                    {
                        if (Mash >= 7)
                        {
                            Tirones += 1;
                            pullcount = 0;
                            currentState = STATES.FIGHT;
                        }
                        else
                        {
                            currentState = STATES.RUN;
                        }
                    }
                    break;
                case STATES.FIGHT2:
                    pullcount += Time.deltaTime;
                    Hook.transform.position = transform.position;
                    FishForce = 1;
                    if(pullcount < 5)
                    {
                        palPez = new Vector3(1000, transform.position.y, transform.position.z);
                        if (FishForce == 1)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, palPez, 10f * Time.deltaTime);
                            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
                            pullcount += Time.deltaTime;
                        }
                        else
                        {
                            transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                        }
                        if (Input.GetKeyDown(KeyCode.A))
                        {
                            FishForce = 0;
                            Mash += 1;
                        }
                        if (Input.GetKeyDown(KeyCode.A))
                        {
                            FishForce = 1;
                        }
                    }
                    else
                    {
                        if (Mash >= 7)
                        {
                            Tirones += 1;
                            pullcount = 0;
                            currentState = STATES.FIGHT;
                        }
                        else
                        {
                            currentState = STATES.RUN;
                        }
                    }
                    break;
                case STATES.FIGHT3:
                    pullcount += Time.deltaTime;
                    Hook.transform.position = transform.position;
                    FishForce = 1;
                    if(pullcount < 5)
                    {
                        palPez = new Vector3(1000, -1000, transform.position.z);
                        if (FishForce == 1)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, palPez, 10f * Time.deltaTime);
                            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -45);
                            pullcount += Time.deltaTime;
                        }
                        else
                        {
                            transform.position = new Vector2(transform.position.x - 1, transform.position.y + 1);
                        }
                        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
                        {
                            FishForce = 0;
                            Mash += 1;
                        }
                        if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
                        {
                            FishForce = 1;
                        }
                    }
                    else
                    {
                        if (Mash >= 7)
                        {
                            Tirones += 1;
                            pullcount = 0;
                            currentState = STATES.FIGHT;
                        }
                        else
                        {
                            currentState = STATES.RUN;
                        }
                    }
                    break;
                case STATES.FIGHT4:
                    pullcount += Time.deltaTime;
                    Hook.transform.position = transform.position;
                    FishForce = 1;
                    if(pullcount < 5)
                    {
                        palPez = new Vector3(transform.position.x, -1000, transform.position.z);
                        if (FishForce == 1)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, palPez, 10f * Time.deltaTime);
                            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90);
                            pullcount += Time.deltaTime;
                        }
                        else
                        {
                            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                        }
                        if (Input.GetKeyDown(KeyCode.W))
                        {
                            FishForce = 0;
                            Mash += 1;
                        }
                        if (Input.GetKeyUp(KeyCode.W))
                        {
                            FishForce = 1;
                        }
                    }
                    else
                    {
                        if (Mash >= 7)
                        {
                            Tirones += 1;
                            pullcount = 0;
                            currentState = STATES.FIGHT;
                        }
                        else
                        {
                            currentState = STATES.RUN;
                        }
                    }
                    break;
                case STATES.FIGHT5:
                    pullcount += Time.deltaTime;
                    Hook.transform.position = transform.position;
                    FishForce = 1;
                    if(pullcount < 5)
                    {
                        palPez = new Vector3(-1000, -1000, transform.position.z);
                        if (FishForce == 1)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, palPez, 10f * Time.deltaTime);
                            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -135);
                            pullcount += Time.deltaTime;
                        }
                        else
                        {
                            transform.position = new Vector2(transform.position.x + 1, transform.position.y + 1);
                        }
                        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
                        {
                            FishForce = 0;
                            Mash += 1;
                        }
                        if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
                        {
                            FishForce = 1;
                        }
                    }
                    else
                    {
                        if(Mash >= 7)
                        {
                            Tirones += 1;
                            pullcount = 0;
                            currentState = STATES.FIGHT;
                        }
                        else
                        {
                            currentState = STATES.RUN;
                        }
                    }
                    break;
                case STATES.FIGHT6:
                    pullcount += Time.deltaTime;
                    Hook.transform.position = transform.position;
                    FishForce = 1;
                    if(pullcount < 5)
                    {
                        palPez = new Vector3(-1000, transform.position.y, transform.position.z);
                        if (FishForce == 1)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, palPez, 10f * Time.deltaTime);
                            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -180);
                            pullcount += Time.deltaTime;
                        }
                        else
                        {
                            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                        }
                        if (Input.GetKeyDown(KeyCode.D))
                        {
                            FishForce = 0;
                            Mash += 1;
                        }
                        if (Input.GetKeyUp(KeyCode.D))
                        {
                            FishForce = 1;
                        }
                    }
                    else
                    {
                        if (Mash >= 7)
                        {
                            Tirones += 1;
                            pullcount = 0;
                            currentState = STATES.FIGHT;
                        }
                        else
                        {
                            currentState = STATES.RUN;
                        }
                    }
                    break;
                case STATES.FIGHT7:
                    pullcount += Time.deltaTime;
                    Hook.transform.position = transform.position;
                    FishForce = 1;
                    if(pullcount < 5)
                    {
                        palPez = new Vector3(-1000, 1000, transform.position.z);
                        if (FishForce == 1)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, palPez, 10f * Time.deltaTime);
                            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -225);
                            pullcount += Time.deltaTime;
                        }
                        else
                        {
                            transform.position = new Vector2(transform.position.x + 1, transform.position.y - 1);
                        }
                        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
                        {
                            FishForce = 0;
                            Mash += 1;
                        }
                        if (Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D))
                        {
                            FishForce = 1;
                        }
                    }
                    else
                    {
                        if (Mash >= 7)
                        {
                            Tirones += 1;
                            pullcount = 0;
                            currentState = STATES.FIGHT;
                        }
                        else
                        {
                            currentState = STATES.RUN;
                        }
                    }
                    break;
                case STATES.RUN:
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(Random.Range(-100, 200), Random.Range(-100, 200), transform.position.z), 20f * Time.deltaTime);
                    Destroy(gameObject, 3f);
                    break;
                default:
                    break;
            }
        }
        else
        {
            transform.position = Hook.transform.position;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bait")
        {
            LoockedOn = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bait")
        {
            LoockedOn = false;
        }
    }
}
