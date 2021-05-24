using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Player
{
    protected float aimingSpeed = 10;
    // Update is called once per frame
    void Update()
    {
        LookAtCrosshair();
    }

    private void LookAtCrosshair()
    {
        var target = Input.mousePosition;
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        target -= pos;
        var angle = (Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg + 90);
        var desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, aimingSpeed * Time.deltaTime);
    }
}
