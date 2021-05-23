﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // This is our base class for all enemy types
    protected GameObject playerObject;
    protected WaveConfigurator waveConfigurator;
    protected List<Transform> waypoints;
    protected float enemyHealth;
    protected float aimingSpeed;

    // When the enemy is spawned, pull all the settings from the WaveConfigurator for the current wave
    public void SetWaveConfig(WaveConfigurator waveConfig)
    {
        this.waveConfigurator = waveConfig;
        waypoints = waveConfigurator.GetWaypoints();
        transform.position = waypoints[0].transform.position;
        enemyHealth = waveConfigurator.GetEnemyHealth();
        aimingSpeed = waveConfigurator.GetEnemyAimingSpeed();
        playerObject = GameObject.Find("Player").gameObject;
    }



}
