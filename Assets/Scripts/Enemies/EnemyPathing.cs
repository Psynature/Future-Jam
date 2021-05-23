using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : Enemy
{
    // This is our base class for enemy movement,
    // all our other movement subclasses will derive from this
    protected float dirOfTravel;
    protected float movementThisFrame;
    private Quaternion desiredRotation;

    // Pretty self explanatory, our base movement 
    protected void EnemyMovement()
    {
        movementThisFrame = waveConfigurator.GetEnemyMoveSpeed() * Time.deltaTime;
    }
    
    protected void EnemyTurning()
    {
        // Will probably have to move this stuff out of here as each enemy type will likely have completley different requierements
        desiredRotation = Quaternion.Euler(0, 0, dirOfTravel);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, (aimingSpeed * Time.deltaTime) / 2);
    }

    protected void EnemyCompletedWave()
    {
        // What we do when the enemy reaches the final  waypoint in its path
        Destroy(gameObject);
    }
}
