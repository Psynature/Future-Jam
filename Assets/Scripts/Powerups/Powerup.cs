using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    protected PlayerHealth playerHealth;

    protected void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.Log("Powerup could not find the player");
        }
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            ActivatePowerup();
            Destroy(gameObject);
        }
    }

    protected virtual void ActivatePowerup()
    {

    }
}
