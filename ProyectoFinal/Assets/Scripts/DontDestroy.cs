﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DontDestroy : MonoBehaviour
{
    private void Start()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("MenuMusic");
        DontDestroyOnLoad(this.gameObject);
    }
}
