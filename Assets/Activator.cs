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
    public bool createMode;
    public GameObject n;

    public GameObject gm;
    


    // Start is called before the first frame update
    void Awake()
    {
        gm = GameObject.Find("GameManager");
        sr = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        old = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode && Input.GetKeyDown(key))
        {
            if (Input.GetKeyDown(key) )
                Instantiate(n, transform.position, Quaternion.identity);
        }
        else
        {
            if (Input.GetKeyDown(key) )
                StartCoroutine(Pressed());
            
            if (Input.GetKeyDown(key) && active)
            {
                Destroy(note );
                gm.GetComponent<GameManager>().AddStreak();
                AddScore();
                active = false;
            } else if (Input.GetKeyDown(key) && !active)
            {
                gm.GetComponent<GameManager>().ResetStreak(); 
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "WinNote")
        {
            gm.GetComponent<GameManager>().Win();
        }

        if (other.gameObject.tag == "Note")
        {
            note = other.gameObject;
            active = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        active = false;
        gm.GetComponent<GameManager>().ResetStreak(); 
        
    }

    void AddScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<GameManager>().GetScore());
    }
    IEnumerator Pressed()
    {
        
        sr.color = new Color(0,0,0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
    }
}
