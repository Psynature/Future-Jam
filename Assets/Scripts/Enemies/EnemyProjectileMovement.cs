using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    float projectileSpeed;
    Rigidbody2D rb;
    public void SetProjectileSpeed(float speed)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        projectileSpeed = speed;
        rb.AddRelativeForce(-Vector2.up * projectileSpeed);
    }
    // Update is called once per frame
    void Update()
    {		
     //   transform.Translate(-Vector3.up * projectileSpeed * Time.deltaTime );
    }
}
