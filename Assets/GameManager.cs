using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int multiplier = 2;

    private int streak = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Destroy(other.gameObject);
    }

    public int GetScore()
    {
        return 100 * multiplier;
    }

    public void AddStreak()
    {
        streak++;
        if (streak >= 24)
        {
            multiplier = 4;
        }
        else if (streak >= 16)
        {
            multiplier = 3;
        }
        else if (streak >= 8)
        {
            multiplier = 2;
        }
        else
        {
            multiplier = 1;
        }
        
        updateGUI();
    }

    public void ResetStreak()
    {
        streak = 0;
        multiplier = 1;
        updateGUI();
    }

    public void updateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("multiplier", multiplier);
        PlayerPrefs.Save();
    }
}
