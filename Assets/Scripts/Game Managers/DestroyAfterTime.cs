using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    private float destroyAfterTime = 1;
    
    void Update()
    {
        if (Time.time > destroyAfterTime)
        Destroy(gameObject);
    }
}
