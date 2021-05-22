using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    [SerializeField]
    private float movementSpeed = 10;
    private Vector2 movement;
    private Rigidbody2D rb;

    [SerializeField]
    private float playerPadding;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    private void Start()
    {
        // Get the rigidbody of our player object
        rb = this.GetComponent<Rigidbody2D>();
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
        // we use FixedUpdate to control movement because we're applying force to our object
        // and Update is called once per frame, however this is called at fixed intervals so will not vary
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
