using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    private int score, playerHealth;

    [SerializeField] private TMP_Text scoreText, healthText;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        score = 0;
        UpdateScore(score);
        playerHealth = 100;
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
        Debug.Log(value);
        playerHealth -= value;
        healthText.text = playerHealth.ToString();
    }
}
