using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfigurator", menuName = "Enemy Wave Config", order = 0)]
public class WaveConfigurator : ScriptableObject
{
    // This is what we'll use to configue waves in the Unity Editor, 
    // We won't have to programatically configure them now we have this
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] int numberOfEnemies;
    [SerializeField] float movementSpeed;
    [SerializeField] bool doubelWave;
    [SerializeField] float staggerTime;

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
    public float GetMoveSpeed() {return movementSpeed;}
    public bool GetDoubleWave() {return doubelWave;}
    public float GetStaggerTime() {return staggerTime;}

}
