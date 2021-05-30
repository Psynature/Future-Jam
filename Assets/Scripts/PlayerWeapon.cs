using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : Player
{
    CustomFixedUpdate customFixedUpdate;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected float projectileFiringPeriod = 0.2f;
    [SerializeField] protected int projectileDamage = 10;
    [SerializeField] protected float aimingSpeed = 10;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform weaponPosition;
     
    void Start ()
    {
        customFixedUpdate = new CustomFixedUpdate(projectileFiringPeriod, OnFixedUpdate);
    }

    // Update is called once per frame
    void Update()
    {
        LookAtCrosshair();
        customFixedUpdate.Update();
    }

    void OnFixedUpdate(float dt)
    {
        FireWeapon();
    }

    void FireWeapon()
    {
        if (Input.GetButton("Fire1"))
        {
            GameObject projectile;
            InstantiateProjectile(out projectile);
            AddForceToProjectile(projectile);
        }
    }

    void InstantiateProjectile(out GameObject projectile)
    {
        projectile = Instantiate(
            projectilePrefab,
            weaponPosition.position,
            transform.rotation)
            as GameObject;
        projectile.GetComponent<DamageDealer>().SetDamage(projectileDamage);
    }

    void AddForceToProjectile(GameObject projectile)
    {
        projectile.GetComponent<Rigidbody2D>().AddForce(
            weaponPosition.up * projectileSpeed);
    }

    private void LookAtCrosshair()
    {
        var target = Input.mousePosition;
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        target -= pos;
        var angle = (Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 90);
        var desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, aimingSpeed * Time.deltaTime);
    }
}
