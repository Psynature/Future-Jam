using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeParallax : MonoBehaviour
{
    private float height, startPosition;
    private float distanceTraveled = 0;
    public float starSpeed;
    
    void Start()
    {
        startPosition = transform.position.y;
        height = transform.GetComponent<RectTransform> ().sizeDelta.y;
    }

    void Update()
    {
         if(distanceTraveled >= height)
         {
             transform.position = new Vector3(transform.position.x, startPosition, transform.position.z);
             distanceTraveled = 0;
         }else
         {
             //transform.position = new Vector3(transform.position.x, startPosition + starSpeed, transform.position.z);
             transform.Translate(Vector3.down * (Time.deltaTime * starSpeed));
             distanceTraveled +=  starSpeed * Time.deltaTime; 
         }
    }
}
