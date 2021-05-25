using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : Enemy
{
    // This is our base class for enemy movement,
    // all our other movement subclasses will derive from this
    protected bool reverse = false;
    protected float dirOfTravel;
    protected float movementThisFrame;
    private Quaternion desiredRotation;

    // Pretty self explanatory, our base movement 
    protected void EnemyMovement()
    {
        movementThisFrame = waveConfigurator.GetEnemyMoveSpeed() * Time.deltaTime;
    }
    
    protected virtual void EnemyTurning()
    {
        // if you need to change this in a derived class use "overide void EnemyTurning()"
        desiredRotation = Quaternion.Euler(0, 0, dirOfTravel);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, (turningSpeed * Time.deltaTime) / 2);
    }

    protected void EnemyCompletedWave()
    {
        // What we do when the enemy reaches the final  waypoint in its path
        Destroy(gameObject);
    }
}
