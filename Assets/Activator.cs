using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key;
    private bool active = false;
    private GameObject note;
    private SpriteRenderer sr;
    private Color old ;


    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        old = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) )
            StartCoroutine(Pressed());
            
        if (Input.GetKeyDown(key) && active)
        {
            Destroy(note );
            AddScore();
            active = false;
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

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);
    }
    IEnumerator Pressed()
    {
        
        sr.color = new Color(0,0,0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
