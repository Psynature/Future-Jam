using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingQuadratic : EnemyPathing
{
    private float count = 0;

    void Update()
    {
        EnemyMovement();
        QuadraticMove();
        EnemyTurning();
    }
    private void QuadraticMove()
    {
        if (!reverse)
        {
            if (count < 1.0f)
            {
                // Some complicated maths... you work it out if you want to that bad
                count += movementThisFrame / 100.0f;
                Vector3 p0 = Vector3.Lerp(waypoints[0].position, waypoints[1].position, count);
                Vector3 p1 = Vector3.Lerp(waypoints[1].position, waypoints[2].position, count);
                transform.position = Vector3.Lerp(p0, p1, count);
                Vector3 v = p0 - p1;
                dirOfTravel = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            }
            else
            {
                count = 0;
                reverse = true;
            }
        }
        if (reverse)
        {
            if (count < 1.0f)
            {
                count += movementThisFrame / 100.0f;
                Vector3 p0 = Vector3.Lerp(waypoints[2].position, waypoints[1].position, count);
                Vector3 p1 = Vector3.Lerp(waypoints[1].position, waypoints[0].position, count);
                transform.position = Vector3.Lerp(p0, p1, count);
                Vector3 v = p0 - p1;
                dirOfTravel = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            }
            else
            {
                count = 0;
                reverse = false;
            }
        }
    }
}
