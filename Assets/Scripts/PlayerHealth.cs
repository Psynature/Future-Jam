using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private float maxPlayerDeflectionTime;

    private float deflectionTimeRemaining;
    private bool usingDeflector = false;

    private GameSession gameSession;

    void Start()
    {
        deflectionTimeRemaining = maxPlayerDeflectionTime;
        gameSession = GameObject.Find("GameSession").gameObject.GetComponent<GameSession>();
        gameSession.SetMaxDeflectionTime(maxPlayerDeflectionTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (usingDeflector && other.gameObject.tag == "Enemy Projectile")
        {
           var rb = other.gameObject.GetComponent<Rigidbody2D>();
           float v = rb.velocity.magnitude;
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
        CheckUsingDeflector();
    }

    private void CheckUsingDeflector()
    {
        if (Input.GetButton("Fire2") && deflectionTimeRemaining >= 0)
        {
            deflectionTimeRemaining -= Time.deltaTime;
            gameSession.UpdateDeflector(deflectionTimeRemaining);
            usingDeflector = true;
            if (deflectionTimeRemaining <= 0)
            {
                deflectionTimeRemaining = 0;
                usingDeflector = false;
            }
        }
        if (!Input.GetButton("Fire2"))
        {
            usingDeflector = false;
        }
    }

    public void SetDeflectionTime(float addedTime)
    {
        deflectionTimeRemaining += addedTime;
        if (deflectionTimeRemaining <= 0)
        {
            deflectionTimeRemaining = 0;
        }
        gameSession.UpdateDeflector(deflectionTimeRemaining);
    }
}
