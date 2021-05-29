using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;

    private GameSession gameSession;

    void Start()
    {
        gameSession = GameObject.Find("GameSession").gameObject.GetComponent<GameSession>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetButton("Fire2") && other.gameObject.tag == "Enemy Projectile")
        {
           var rb = other.gameObject.GetComponent<Rigidbody2D>();
           float v = rb.velocity.magnitude;
           Debug.Log(v);
           rb.AddRelativeForce(Vector2.up * (v * 100));
           other.gameObject.tag = "Player Projectile";
        }
        else if(other.gameObject.tag == "Enemy Projectile" || other.gameObject.tag == "Enemy")
        {
            ReduceHealth(other.gameObject.GetComponent<DamageDealer>().GetDamage());
            Destroy(other.gameObject);
        }

    }

    private void ReduceHealth(int damageDealt)
    {
        playerHealth -= damageDealt;
        gameSession.UpdateHealth(damageDealt);
    }

    void Update()
    {
             //   Debug.Log(playerHealth);
    }
}
