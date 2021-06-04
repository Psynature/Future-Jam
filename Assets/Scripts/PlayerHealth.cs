using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    [SerializeField] private float maxPlayerDeflectionTime;
    [SerializeField] private List<Sprite> enemyProjectileSprites;

    private float deflectionTimeRemaining;
    private bool usingDeflector = false;

    private GameSession gameSession;

    void Start()
    {
        deflectionTimeRemaining = maxPlayerDeflectionTime;
        gameSession = GameObject.Find("GameSession").gameObject.GetComponent<GameSession>();
        gameSession.SetMaxDeflectionTime(maxPlayerDeflectionTime);
    }
    void Update()
    {
        CheckUsingDeflector();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (usingDeflector && other.gameObject.tag == "Enemy Projectile")
        {
            DeflectShot(other);
        }
        else if(other.gameObject.tag == "Enemy Projectile" || other.gameObject.tag == "Enemy")
        {
            ReduceHealth(other.gameObject.GetComponent<DamageDealer>().GetDamage());
            Destroy(other.gameObject);
        }
    }

    private void DeflectShot(Collider2D other)
    {
        var rb = other.gameObject.GetComponent<Rigidbody2D>();
        float v = rb.velocity.magnitude;
        rb.AddRelativeForce(Vector2.up * (v * 100));
        other.gameObject.tag = "Player Projectile";
        DeflectedShotSpriteSwap(other.gameObject.GetComponent<SpriteRenderer>().sprite.name, other.gameObject);
    }

    private void DeflectedShotSpriteSwap(string name, GameObject other)
    {
        Debug.Log(name);
        for (int i = 0; i < enemyProjectileSprites.Count; i++)
        {
            if(name == enemyProjectileSprites[i].name)
            {
                other.gameObject.GetComponent<SpriteRenderer>().sprite = enemyProjectileSprites[i + 1];
            }
        }
    }

    public void ReduceHealth(int damageDealt)
    {
        playerHealth -= damageDealt;
        gameSession.UpdateHealth(damageDealt);
        if (playerHealth <= 0)
        {
            Time.timeScale = 0;
        }
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
