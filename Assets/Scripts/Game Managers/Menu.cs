using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static void Play()
    {   
        print("This is a test to make sure clicks work");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public static void Quit()
    {
        print("This is a test to make sure clicks work");
        Application.Quit();
    }
    public static void Score()
    {
        print("This is a test to make sure clicks work");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Score");
    }
}
