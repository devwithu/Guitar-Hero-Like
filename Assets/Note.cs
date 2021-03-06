﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed ;
    private bool called = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0,-speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Start") == 1 && !called )
            rb.velocity = new Vector2(0,-speed);
        called = true;
    }
}
