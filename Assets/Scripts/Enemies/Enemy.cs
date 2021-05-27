using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // This is our base class for all enemy types
    protected GameObject playerObject;
    private GameSession gameSession;
    protected WaveConfigurator waveConfigurator;
    protected List<Transform> waypoints;
    protected float enemyHealth;
    protected float turningSpeed;
    protected float firingSpeed;
    protected bool enemyIsAimer;
    protected float aimingSpeed;
    protected float projectileSpeed;
    protected GameObject projectile;
    private int scoreValue;

    // When the enemy is spawned, pull all the settings from the WaveConfigurator for the current wave
    public void SetWaveConfig(WaveConfigurator waveConfig)
    {
        this.waveConfigurator = waveConfig;
        waypoints = waveConfigurator.GetWaypoints();
        transform.position = waypoints[0].transform.position;
        enemyHealth = waveConfigurator.GetEnemyHealth();
        turningSpeed = waveConfigurator.GetEnemyTurningSpeed();
        firingSpeed = waveConfigurator.GetEnemyFiringSpeed();
        enemyIsAimer = waveConfigurator.GetEnemyAimer();
        aimingSpeed = waveConfigurator.GetEnemyAimingSpeed();
        projectileSpeed = waveConfigurator.GetEnemyProjectileSpeed();
        projectile = waveConfigurator.GetEnemyProjectilePrefab();
        scoreValue = waveConfigurator.GetEnemyScoreValue();
        playerObject = GameObject.Find("Player").gameObject;
        gameSession = GameObject.Find("GameSession").gameObject.GetComponent<GameSession>();
    }
    //This is called when the enemy collides with another object
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player Projectile")
        {
            Debug.Log("Hit");
            enemyHealth -= other.gameObject.GetComponent<DamageDealer>().GetDamage();
            if (enemyHealth <= 0)
            {
                DestroyObject(scoreValue);
            }
        }
        if (other.gameObject.tag == "Player")
        {       
            scoreValue /= 4;
            DestroyObject(scoreValue);
        }
    }
    protected void DestroyObject(int scoreValue)
    {
        gameSession.UpdateScore(scoreValue);
        Destroy(gameObject);
    }
}
