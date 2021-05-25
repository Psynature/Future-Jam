using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingSimple : EnemyPathing
{
    private int waypointIndex;

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        EnemyTurning();
        SimpleMovement();
    }

    private void SimpleMovement()
    {
        if(!reverse)
        {
            if (waypointIndex < waypoints.Count)
            {
                var targetPosition = waypoints[waypointIndex].transform.position;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
                if (transform.position == targetPosition)
                {
                    waypointIndex++;
                }
            }
            else
            {
                reverse = true;
            }
        }
        else
        {
            if(waypointIndex > 0 )
            {
                var targetPosition = waypoints[waypointIndex - 1].transform.position;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
                if (transform.position == targetPosition)
                {
                    waypointIndex--;
                }
            }
            else
            {
                reverse = false;
            }
            }
        }
}
