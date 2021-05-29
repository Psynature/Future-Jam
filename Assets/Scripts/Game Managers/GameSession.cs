using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    private int score, playerHealth;
    private float maxHealth;

    private float maxDeflectionTime;

    [SerializeField] private TMP_Text scoreText, healthText, deflectionText;

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
        //re-enable me on submission
   //     Cursor.lockState = CursorLockMode.Confined;
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

    public void SetMaxDeflectionTime(float value)
    {
        maxDeflectionTime = value;
        SetDeflectorColour(1);
        deflectionText.text = maxDeflectionTime.ToString("F2");
    }

    public void UpdateDeflector(float value)
    {
        float doColor = value / maxDeflectionTime;
        deflectionText.text = value.ToString("F2");
        SetDeflectorColour(doColor);
    }

    private void SetDeflectorColour(float doColor)
    {
        SetTextColourGradient(doColor, deflectionText.GetComponent<TMP_Text>());
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
