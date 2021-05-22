using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Vector2 playerSize; 

    [SerializeField]
    private float playerPadding;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private Camera gameCamera;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerSize = this.GetComponent<Renderer>().bounds.size;
        gameCamera = Camera.main;
        MovementBoundaries();
    }

    private void Update()
    {
        // Get  movement input from our controller / keyboard
        movement = new Vector2 (Input.GetAxis("Horizontal"),
                                        Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        PlayerMove(movement);
    }

    public void PlayerMove(Vector2 direction)
    {
        // Get the position of the player
        var newXpos = Mathf.Clamp(transform.position.x, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y, yMin, yMax);

        // Add force to the rigidbody of the player
        rb.AddForce(new Vector2(direction.x * movementSpeed * Time.deltaTime,
                                        direction.y * movementSpeed * Time.deltaTime));
        // Ensure the player stays within the bounds of the screen                                
        rb.MovePosition(new Vector2(
            newXpos,
            newYpos
        ));
    }

    private void MovementBoundaries()
    {
        // Set the boundaries of where the player can travel
        playerSize = playerSize / playerPadding;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + (playerSize.x);
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - (playerSize.x);
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + (playerSize.y);
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - (playerSize.y);
    }
}
