using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Play()
    {   
        print("This is a test to make sure clicks work");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void GoToTut()
    {
                print("This is a test to make sure clicks work");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu 1");
    }

    public void Quit()
    {
        print("This is a test to make sure clicks work");
        Application.Quit();
    }
    public void Score()
    {
        print("This is a test to make sure clicks work");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Score");
    }
}
