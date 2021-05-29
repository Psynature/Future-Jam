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
    protected int collisionDamage;
    protected float turningSpeed;
    protected float firingSpeed;
    protected bool enemyIsAimer;
    protected int projectileDamage;
    protected float aimingSpeed;
    protected float projectileSpeed;
    protected GameObject projectilePrefab;
    private int scoreValue;

    // When the enemy is spawned, pull all the settings from the WaveConfigurator for the current wave
    public void SetWaveConfig(WaveConfigurator waveConfig)
    {
        this.waveConfigurator = waveConfig;
        waypoints = waveConfigurator.GetWaypoints();
        transform.position = waypoints[0].transform.position;
        enemyHealth = waveConfigurator.GetEnemyHealth();
        collisionDamage = waveConfigurator.GetEnemyCollisionDamage();
        turningSpeed = waveConfigurator.GetEnemyTurningSpeed();
        firingSpeed = waveConfigurator.GetEnemyFiringSpeed();
        enemyIsAimer = waveConfigurator.GetEnemyAimer();
        aimingSpeed = waveConfigurator.GetEnemyAimingSpeed();
        projectileSpeed = waveConfigurator.GetEnemyProjectileSpeed();
        projectileDamage = waveConfigurator.GetEnemyProjectileDamage();
        projectilePrefab = waveConfigurator.GetEnemyProjectilePrefab();
        scoreValue = waveConfigurator.GetEnemyScoreValue();
        playerObject = GameObject.Find("Player").gameObject;
        gameSession = GameObject.Find("GameSession").gameObject.GetComponent<GameSession>();
        GetComponentInChildren<EnemyWeapon>().SetEnemyWeapon(waveConfig);
        GetComponent<DamageDealer>().SetDamage(collisionDamage);
    }

    //This is called when the enemy collides with another object
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player Projectile")
        {
            enemyHealth -= other.gameObject.GetComponent<DamageDealer>().GetDamage();
            if (enemyHealth <= 0)
            {
                DestroyObject(scoreValue);
            }
            Destroy(other.gameObject);
        }
    }
    protected void DestroyObject(int scoreValue)
    {
        gameSession.UpdateScore(scoreValue);
        Destroy(gameObject);
    }
}
