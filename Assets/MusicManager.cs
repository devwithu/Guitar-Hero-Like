﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private bool called = false;
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Start") == 1 && !called)
        {
            GetComponent<AudioSource>().Play();
            called = true;
        }
    }
}
