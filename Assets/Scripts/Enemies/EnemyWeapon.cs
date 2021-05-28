using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Enemy
{
    [SerializeField] private Transform weaponPosition;
    private float canfire;
    public void SetEnemyWeapon(WaveConfigurator waveConfigurator)
    {
        this.waveConfigurator = waveConfigurator;
        enemyIsAimer = waveConfigurator.GetEnemyAimer();
        playerObject = GameObject.Find("Player").gameObject;
        firingSpeed = waveConfigurator.GetEnemyFiringSpeed();
        aimingSpeed = waveConfigurator.GetEnemyAimingSpeed();
        projectileSpeed = waveConfigurator.GetEnemyProjectileSpeed();
        projectileDamage = waveConfigurator.GetEnemyProjectileDamage();
        projectilePrefab = waveConfigurator.GetEnemyProjectilePrefab();
        canfire = firingSpeed;
    }
    // Update is called once per frame
    void Update()
    {   
        if (enemyIsAimer)
        {
            AimAtPlayer();
        }
        if (Time.time > canfire)
        {
            GameObject projectile;
            InstantiateProjectile(out projectile);
            AddForceToProjectile(projectile);
            canfire = Time.time + firingSpeed;
        }
    }

    private void AimAtPlayer()
    {
        var target = playerObject.transform.position - transform.position;
        var angle = (Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg + 90);
        var desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, aimingSpeed * Time.deltaTime);
    }

    void InstantiateProjectile(out GameObject projectile)
    {

        projectile = Instantiate(
            projectilePrefab,
            weaponPosition.position,
            weaponPosition.rotation)
            as GameObject;
        Component[] damageDealers = projectile.GetComponentsInChildren(typeof(DamageDealer));
        foreach(DamageDealer damageDealer in damageDealers)
        {
            damageDealer.SetDamage(projectileDamage);
        }
     //   projectile.GetComponentsInChildren<DamageDealer>().SetDamage(projectileDamage);
    }
    void AddForceToProjectile(GameObject projectile)
    {
     //   Big oof! finally figured out I need to use AddRelativeForce not simply AddForce
        Component[] rigidBodies = projectile.GetComponentsInChildren(typeof(Rigidbody2D));
        foreach(Rigidbody2D rigidbody in rigidBodies)
        {
            rigidbody.AddRelativeForce(-Vector2.up * projectileSpeed);
        }

    /*
        Component[] speedScripts = projectile.GetComponentsInChildren(typeof(EnemyProjectileMovement));
        foreach(EnemyProjectileMovement speedScript in speedScripts)
        {
            speedScript.SetProjectileSpeed(projectileSpeed);
        }

        */
    }

}
