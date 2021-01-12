using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PayManager : MonoBehaviour
{
    public Text money;
    public static int currency = 500;
    // Start is called before the first frame update
    void Start()
    {
        money = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        money.text = currency.ToString();
    }
}
