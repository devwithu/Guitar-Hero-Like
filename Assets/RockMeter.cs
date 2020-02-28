﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMeter : MonoBehaviour
{
    public int rm;

    public GameObject needle;
    
    // Start is called before the first frame update
    void Start()
    {
        needle = transform.Find("needle").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rm = PlayerPrefs.GetInt("RockMeter");
        needle.transform.localPosition = new Vector3((rm-25.0f)/25.0f,0,0);
        print((rm-25.0f)/25.0f );
        print(needle.transform.localPosition);
        
    }
}
