using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key;
    private bool active = false;
    private GameObject note;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && active)
        {
            Destroy(note );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        active = true;

        if (other.gameObject.tag == "Note")
            note = other.gameObject;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        active = false;
    }
}
