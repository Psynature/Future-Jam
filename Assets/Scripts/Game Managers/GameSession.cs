using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    private int score, playerHealth;
    private float maxHealth;

    [SerializeField] private TMP_Text scoreText, healthText;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        score = 0;
        UpdateScore(score);
        playerHealth = 1000;
        maxHealth = 1000;
        UpdateHealth(0);
   //     Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {

    }
    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
    
    public void UpdateHealth(int value)
    {
        playerHealth -= value;
        float doColor = playerHealth / maxHealth; 
        SetTextColourGradient(doColor, healthText.GetComponent<TMP_Text>());
        var calculatePercentage = (playerHealth / maxHealth) * 100;
        healthText.text = "Health: " + calculatePercentage.ToString() + "%";
    }

    private void SetTextColourGradient(float value, TMP_Text text)
    {
        // If health is above 50% calculate the gradient change from greed to yellow
        if (value >= 0.5f)
        {
            var invertedValue = 1.0f - value;
            text.color = new Color( Mathf.Min(1, invertedValue * 3.0f), 1, 0, 1);
        }
        else if (value < 0.5f && value >= 0.1f) // now calculate from yellow through to red
        {
            text.color = new Color(1, Mathf.Max(0, value * 2.0f), 0, 1);
        }
        else //at 10% health be pure red
        {
             text.color = new Color(1, 0, 0, 1);
        }
    }
}
