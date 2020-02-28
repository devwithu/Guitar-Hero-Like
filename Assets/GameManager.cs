using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int multiplier = 2;

    private int streak = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score",0);
        PlayerPrefs.SetInt("RockMeter",25);
        PlayerPrefs.SetInt("Streak", 0);
        PlayerPrefs.SetInt("HighStreak", 0);
        PlayerPrefs.SetInt("Mult", 1);
        PlayerPrefs.SetInt("NotesHit", 0);
        PlayerPrefs.SetInt("Start", 1);
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
        
        if (PlayerPrefs.GetInt("RockMeter") + 1 < 50)
        {
            PlayerPrefs.SetInt("RockMeter",PlayerPrefs.GetInt("RockMeter") + 1);
        }
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
        
        if (streak > PlayerPrefs.GetInt("HighStreak"))
            PlayerPrefs.SetInt("HighStreak", streak);
        
        updateGUI();
    }

    public void ResetStreak()
    {

        PlayerPrefs.SetInt("RockMeter",PlayerPrefs.GetInt("RockMeter") - 2);
        if (PlayerPrefs.GetInt("RockMeter") < 0)
            Lose();

        streak = 0;
        multiplier = 1;
        updateGUI();
    }

    void Lose()
    {
        print("Lose");
        PlayerPrefs.SetInt("Start", 0);
        SceneManager.LoadScene(2);
    }

    public void Win()
    {
        if(PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        
        
        print("Win");
        SceneManager.LoadScene(1);
    }

    public void updateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("multiplier", multiplier);
        //PlayerPrefs.Save();
    }
}
