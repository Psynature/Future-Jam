using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Vector2 playerSize; 
    protected Camera gameCamera;
    // Start is called before the first frame update
    void Start()
    {
        // we'll use the playersize to ensure we don't go off the screen, no matter how large or small we are.
        CalculatePlayerSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void CalculatePlayerSize()
    {
        playerSize = this.GetComponent<Renderer>().bounds.size;
    }
}
