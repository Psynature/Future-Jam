using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private TMP_Text scoreText;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        score = 0;
        UpdateScore(0);
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {

    }
    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
