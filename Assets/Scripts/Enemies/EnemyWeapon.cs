using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Enemy
{
    // Update is called once per frame
    void Update()
    {
        if (enemyIsAimer)
        {
            AimAtPlayer();
        }
    }

    private void AimAtPlayer()
    {
        Debug.Log("I'm Aiming");
        var target = playerObject.transform.position;
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        target -= pos;
        var angle = (Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg + 90);
        var desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, aimingSpeed * Time.deltaTime);
    }
}
