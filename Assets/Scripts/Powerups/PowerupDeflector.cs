using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupDeflector : Powerup
{
    [SerializeField] float addedTime;
    protected override void ActivatePowerup()
    {
        base.ActivatePowerup();
        playerHealth.SetDeflectionTime(addedTime);
        Destroy(gameObject);
    }
}
