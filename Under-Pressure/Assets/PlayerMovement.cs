using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // deeted start method for this movement script

    // variable to control our movement speed set to 5 by default
    public float moveSpeed = 5f;
    // this is a reference to our rigidbody2D component
    public Rigidbody2D rigidbody;

    public Camera cam;

    // variable for jolding movement input
    Vector2 movement;

    Vector2 mousePosition;

    // when doing this style of movement in unity I'm splitting it into two functions below

    // Update() function will trigger the player's movement
    // Update is called once per frame
    void Update()
    {
        // store this input into a variable so it can be accessed in FixedUpdate
        // gathers the input onto the x and the y
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // this converts mouse position from pixel coordinates to world units if to aim/shoot with mouse rather than keys
        // then it assigns our input of mouse position to mousePosition Vector
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // FixedUpdate() will move our player based on that input in Update()
    void FixedUpdate()
    {
        // accesses rb (rigidbody) with MovePosition function
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);

        // subtracting the two vectors of mouse position and player's position
        // now it aims in direction of where mouse is
        Vector2 lookDirection = mousePosition - rigidbody.position;
        // Atan2 returns the angle from the x axis to the directional vector thats's pointing from player to mouse position
        // Rad2Deg converts Atan2 results to degrees and "- 90f" subtracts 90 degress
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        rigidbody.rotation = angle;
    }
}
