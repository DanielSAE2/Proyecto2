using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PayManager : MonoBehaviour
{
    public Text money;
    public static int currency = 500;
    public Text upgradeBoat;
    public static int boatUpgrade = 25;
    public Text upgradeBait;
    public static int baitUpgrade = 50;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        money.text = currency.ToString();
        upgradeBoat.text = boatUpgrade.ToString();
        upgradeBait.text = baitUpgrade.ToString();
    }
}
