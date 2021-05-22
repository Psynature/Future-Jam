using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    protected WaveConfigurator waveConfigurator;
    protected List<Transform> waypoints;
    protected float movementThisFrame;
    [SerializeField] private float aimingSpeed;
    protected float dirOfTravel;
    private Quaternion desiredRotation;

    public void PlayerMovement()
    {
        movementThisFrame = waveConfigurator.GetMoveSpeed() * Time.deltaTime;
    }
    
    public void PlayerTurning()
    {
        desiredRotation = Quaternion.Euler(0, 0, dirOfTravel);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, (aimingSpeed * Time.deltaTime) / 2);
    }
    public void SetWaveConfig(WaveConfigurator waveConfig)
    {
        this.waveConfigurator = waveConfig;
        waypoints = waveConfigurator.GetWaypoints();
        transform.position = waypoints[0].transform.position;
    }
}
