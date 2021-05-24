using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Vector2 playerSize; 
    protected Camera gameCamera;

    void Start()
    {
        CalculatePlayerSize();
    }
    // we'll use the playersize to ensure we don't go off the screen, no matter how large or small we are.
    protected void CalculatePlayerSize()
    {
        playerSize = this.GetComponent<Renderer>().bounds.size;
    }
}
