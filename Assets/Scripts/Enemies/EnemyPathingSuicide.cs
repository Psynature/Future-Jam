using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingSuicide : EnemyPathing
{
    void Update()
    {
        EnemyMovement();
        SuicideMovement();
    }

    private void SuicideMovement()
    {
        // Get the current position in world space
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        // Set the target position at the player
        var targetDirection = playerObject.transform.position - transform.position;
        // Calculate the angle between us and the target
        var angle = (Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg) + 90;
        // ensure we work each step with deltaTime
        var singleStep = turningSpeed * Time.deltaTime;
        // Calculate our desired rotation (facing the target)
        var desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // Rotate towards the target using aimingSpeed (singleStep)
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, singleStep);
        // Move forward at a constant rate
        transform.Translate(-Vector3.up * movementThisFrame);
    }
}
