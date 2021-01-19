using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float directionX;
    private float directionY;

    [Header("Positions")]
    public GameObject bait;
    public GameObject posBait;
    public GameObject posBoatStart;
    public GameObject posBaitStart;
    public GameObject cameraStart;
    public float ropeLength = -83f;

    [Header("Speeds")]
    public float speedBoat = 20;
    public float speedBait = 20;

    [Header("Fuel")]
    public int maxFuel = 1500;
    public int currentFuel;
    public FuelBar fuelBar;
    public GameObject noFuelBtn;
    public GameObject acceptUpgrade;
    public GameObject lostPanel;

    [Header("Booleans")]
    public bool switchController = false;

    [Header("IAFish")]
    private Bait fish;

    [Header("Missions")]
    public Text ObjectiveName;
    public int FishAmount, FishCatched;
    public MissionsManager Mission;
    public GameObject MissionObject;
    public GameObject ReturnBtn;
    public PayManager PayMan;

    private AudioSource audioBoat;

    void Start()
    {
        currentFuel = maxFuel;
        fuelBar.SetMaxFuel(maxFuel);

        bait.gameObject.SetActive (false); 

        noFuelBtn.SetActive (false);
        acceptUpgrade.SetActive (true);

        audioBoat = GetComponent<AudioSource>();

        ropeLength = -83f;      
    }

    void Update()
    {
        ObjectiveName.text = Mission.Objective + ": " + FishCatched.ToString();
        FishAmount = Mission.ObjectiveAmount;
        Debug.Log(acceptUpgrade.activeSelf);
        fish = bait.GetComponent<Bait>();
        if(acceptUpgrade.activeSelf == false)
        {
            if (!switchController)
            {
                //Límite del barco en la derecha
                if (transform.position.x <= 156.4f)
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        transform.position = new Vector2(transform.position.x - 1 * speedBoat * Time.deltaTime, transform.position.y);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.position = new Vector2(transform.position.x + 1 * speedBoat / 2 * Time.deltaTime, transform.position.y);
                    }
                }
                else
                {
                    transform.position = new Vector2(156.4f, transform.position.y);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    LoseFuel(4);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    if (transform.position.x >= 156.4f)
                    {
                        LoseFuel(0);
                    }
                    else
                    {
                        LoseFuel(2);
                    }
                }
            }
            else
            {
                //Límite del bait al nivel del mar
                if (bait.transform.localPosition.y <= -4f && bait.transform.localPosition.y >= ropeLength)
                {
                    //Límite del bait en los marcos laterales de la cámara
                    if (bait.transform.localPosition.x >= -33 && bait.transform.localPosition.x <= 33)
                    {
                        directionX = Input.GetAxis("Horizontal");
                        directionY = Input.GetAxis("Vertical");
                        bait.transform.position = new Vector2(bait.transform.position.x + directionX * speedBait / 3 * Time.deltaTime,
                                                               bait.transform.position.y + directionY * speedBait * Time.deltaTime);
                    }
                    else if (bait.transform.localPosition.x < -33)
                    {
                        bait.transform.localPosition = new Vector2(-33, bait.transform.localPosition.y);
                    }
                    else if (bait.transform.localPosition.x > 33)
                    {
                        bait.transform.localPosition = new Vector2(33, bait.transform.localPosition.y);
                    }
                }
                if (bait.transform.localPosition.y >= -4f)
                {
                    bait.transform.localPosition = new Vector2(bait.transform.localPosition.x, -4f);
                }
                if (bait.transform.localPosition.y <= ropeLength)
                {
                    bait.transform.localPosition = new Vector2(bait.transform.localPosition.x, ropeLength + 0.1f);
                }
            }
            MovingBoat();
            SwitchToBait();
            BackMenu();
            WinCondition();
        }
        
    }

    //Al presionar espacio intercambia el bait entre activo e inactivo
    private void SwitchToBait()
    {
        if (!fish.fishCatched)
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

    //Al presionar escape vuelve al menú principal
    private void BackMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void LoseFuel(int fuelLost)
    {
        currentFuel -= fuelLost;

        fuelBar.SetFuel(currentFuel);

        if (currentFuel <= 0)
        {
            speedBoat = 0;
            noFuelBtn.SetActive (true);
        }
    }

    public void PayReturn()
    {
        if (PayMan.currency >= 50)
        {
            PayMan.currency -= 50;

            noFuelBtn.SetActive (false);
            acceptUpgrade.SetActive (true);
            
            currentFuel = 10000000;
            fuelBar.SetFuel(currentFuel);

            transform.position = posBoatStart.transform.position;
            bait.transform.position = posBaitStart.transform.position;

            Vector3 fPlayer = transform.position;
            fPlayer.z = cameraStart.transform.position.z;
            cameraStart.transform.position = fPlayer;
            MissionObject.SetActive(false);
            MissionObject.SetActive(true);
        }
        else
        {
            lostPanel.SetActive (true);
        }
    }

    public void UpgradeAccept()
    {
        acceptUpgrade.SetActive(false);
        
        speedBoat = 20;
        
        currentFuel = maxFuel;
        fuelBar.SetFuel(currentFuel);
    }
    private void WinCondition()
    {
        if(FishCatched == FishAmount)
        {
            ReturnBtn.SetActive(true);
        }
    }
    public void ReturnBtnF()
    {
        transform.position = posBoatStart.transform.position;
        bait.transform.position = posBaitStart.transform.position;

        Vector3 fPlayer = transform.position;
        fPlayer.z = cameraStart.transform.position.z;
        cameraStart.transform.position = fPlayer;

        PayMan.currency += 200 + (1000 / FishAmount);
        Mission.enabled = false;//
        ReturnBtn.SetActive(false);
        acceptUpgrade.SetActive(true);
        ObjectiveName.text = null + " " + FishCatched.ToString();
    }
    private void MovingBoat()
    {
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D))
        {
            audioBoat.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {      
        if (other.tag == Mission.Objective)
        {
            FishCatched += 1;
        }
    }
}
