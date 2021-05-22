using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // This is our base class for enemy movement,
    // all our other movement subclasses will derive from this
    protected WaveConfigurator waveConfigurator;
    protected List<Transform> waypoints;
    protected float movementThisFrame;
    [SerializeField] protected float aimingSpeed;
    protected float dirOfTravel;
    private Quaternion desiredRotation;

    // When the enemy is spawned, pull all the settings from the WaveConfigurator for the current wave
    public void SetWaveConfig(WaveConfigurator waveConfig)
    {
        this.waveConfigurator = waveConfig;
        waypoints = waveConfigurator.GetWaypoints();
        transform.position = waypoints[0].transform.position;
    }

    // Pretty self explanatory, our base movement 
    public void EnemyMovement()
    {
        movementThisFrame = waveConfigurator.GetMoveSpeed() * Time.deltaTime;
    }
    
    public void EnemyTurning()
    {
        // Will probably have to move this stuff out of here as each enemy type will likely have completley different requierements
        desiredRotation = Quaternion.Euler(0, 0, dirOfTravel);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, (aimingSpeed * Time.deltaTime) / 2);
    }

    public void EnemyCompletedWave()
    {
        // What we do when the enemy reaches the final  waypoint in its path
        Destroy(gameObject);
    }
}
