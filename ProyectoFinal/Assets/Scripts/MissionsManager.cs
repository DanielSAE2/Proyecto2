using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsManager : MonoBehaviour
{
    public List<GameObject> Fishes = new List<GameObject>();
    private int  Iterations, LookedFish;
    public int Zone, ObjectiveAmount;
    private Vector3 PosFish;
    public string Objective;
    // Start is called before the first frame update
    void Start()
    {
        Zone = Random.Range(0, 3);
        if (Zone == 0)
            Iterations = 0;
        if (Zone == 1)
            Iterations = 7;
        if (Zone == 2)
            Iterations = 14;
        LookedFish = Random.Range(0, 6);
        if (LookedFish < 3)
            ObjectiveAmount = 5;
        if (LookedFish > 2 && LookedFish < 6)
            ObjectiveAmount = 3;
        if (LookedFish == 7)
            ObjectiveAmount = 1;
    }
    // Update is called once per frame

    public void MissionButton()
    {

        for (int i = 0; i < 8; i++)
        {
            if (i == LookedFish)
            {
                Objective = Fishes[i + Iterations].gameObject.tag;
            }
            if (i <= 1)
            {
                for (int z = 0; z < 12; z++)
                {
                    float x = Random.Range(-600, 150);
                    float y = Random.Range(16, 90);
                    Instantiate(Fishes[i + Iterations].gameObject, new Vector3(x, y, 1), Quaternion.identity);
                }
            }
            else if (i == 2)
            {
                for (int z = 0; z < 25; z++)
                {
                    float x = Random.Range(-600, 150);
                    float y = Random.Range(-70, 20);
                    Instantiate(Fishes[i + Iterations].gameObject, new Vector3(x, y, 1), Quaternion.identity);
                }
            }
            else if (i <= 4)
            {
                for (int z = 0; z < 8; z++)
                {
                    float x = Random.Range(-600, 150);
                    float y = Random.Range(-150, -80);
                    Instantiate(Fishes[i + Iterations].gameObject, new Vector3(x, y, 1), Quaternion.identity);
                }
            }
            if (i == 5)
            {
                for (int z = 0; z < 6; z++)
                {
                    float x = Random.Range(-600, 150);
                    float y = Random.Range(-160, -223);
                    Instantiate(Fishes[i + Iterations].gameObject, new Vector3(x, y, 1), Quaternion.identity);
                }
            }
            if (i == 6)
            {
                for (int z = 0; z < 3; z++)
                {
                    float x = Random.Range(-600, 150);
                    float y = Random.Range(-230, -303);
                    Instantiate(Fishes[i + Iterations].gameObject, new Vector3(x, y, 1), Quaternion.identity);
                }
            }

        }
    }
}
