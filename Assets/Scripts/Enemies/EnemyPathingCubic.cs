using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingCubic : EnemyPathing
{
    private float count = 0;

    void Update()
    {
        EnemyMovement();
        EnemyTurning();
        CubicMove();
    }

    private void CubicMove()
    {
        if (count < 1)
        {
            count += movementThisFrame / 100;
            Vector3 p0 = Vector3.Lerp(waypoints[0].position, waypoints[1].position, count);
            Vector3 p1 = Vector3.Lerp(waypoints[1].position, waypoints[2].position, count);
            Vector3 p2 = Vector3.Lerp(waypoints[2].position, waypoints[3].position, count);
            Vector3 p3 = Vector3.Lerp(p0, p1, count);
            Vector3 p4 = Vector3.Lerp(p1, p2, count);
            transform.position = Vector3.Lerp(p3, p4, count);
            Vector3 v = p3 - p4;
            dirOfTravel = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        }
        else
            EnemyCompletedWave();
    }
}
