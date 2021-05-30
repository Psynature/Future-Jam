using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHealth : Powerup
{
    [SerializeField] int addedHealth;
    protected override void ActivatePowerup()
    {
        base.ActivatePowerup();
        playerHealth.ReduceHealth(-addedHealth);
    }
}
