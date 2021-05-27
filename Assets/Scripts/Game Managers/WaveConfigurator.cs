using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfigurator", menuName = "Enemy Wave Config", order = 0)]
public class WaveConfigurator : ScriptableObject
{
    // This is what we'll use to configue waves in the Unity Editor, 
    // We won't have to programatically configure them now we have this
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemyProjectilePrefab;
    [SerializeField] GameObject pathPrefab;

    [Header("Wave Config")]
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] int numberOfEnemies;
    [SerializeField] bool doubleWave;
    [SerializeField] float staggerTime;

    [Header("Enemy Stats")]
    [SerializeField] float enemyHealth;
    [SerializeField] float enemyTurningSpeed;
    [SerializeField] float enemyMovementSpeed;
    [SerializeField] float enemyFiringSpeed;
    [SerializeField] bool enemyIsAimer;
    [SerializeField] float enemyAimingSpeed;
    [SerializeField] float enemyProjectileSpeed;
    [SerializeField] int enemyScoreValue;

    public GameObject GetEnemyPrefab() {return enemyPrefab;}

    public List<Transform> GetWaypoints()
    {
        var wavepoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            wavepoints.Add(child);
        }
        return wavepoints;
    }

    public float GetTimeBetweenSpawns() {return timeBetweenSpawns;}
    public int GetNumberOfEnemies() {return numberOfEnemies;}
    public float GetEnemyMoveSpeed() {return enemyMovementSpeed;}
    public bool GetDoubleWave() {return doubleWave;}
    public float GetStaggerTime() {return staggerTime;}
    public float GetEnemyHealth() {return enemyHealth;}
    public float GetEnemyTurningSpeed() {return enemyTurningSpeed;}
    public GameObject GetEnemyProjectilePrefab() {return enemyProjectilePrefab;}
    public float GetEnemyFiringSpeed() {return enemyFiringSpeed;}
    public bool GetEnemyAimer() {return enemyIsAimer;}
    public float GetEnemyAimingSpeed() {return enemyAimingSpeed;}
    public float GetEnemyProjectileSpeed() {return enemyProjectileSpeed;}
    public int GetEnemyScoreValue() {return enemyScoreValue;}
}
