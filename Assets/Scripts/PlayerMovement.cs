//using System.Collections;
//using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Tilemaps;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlayerMovement : MonoBehaviour
{
    // We need the SerializeField tag so that these fields become visible in the Unity Inspector
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    public SpriteMask spriteMask;
    public Transform lawnmower; // Transform refers to the position, rotation and scale of the lawnmower.
    private Vector2 previousPosition;
    public float spawnInterval = 0.0f;
    public float timer = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        // We don't need to do anything here.
    }

    // Update is called once per frame
    void Update()
    {
        // Defining two variables that get player input (W/S or Up/Down; A/D or Left/Right).
        // WASD or the arrow keys are both acceptable input built into Unity.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Creating new Vector2 with the input defined above
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);

        // Gets magnitude of the movement and 'clamps' its value so that it's between 0 and 1.
        // This value is then normalized so that it's of length 1.
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        // Moves the lawnmower/player in the direction specified, multiplied by the speed, inputMagnitude, and delta time.
        // We want it to be multiplied by delta time so that it's framerate independent.
        // Finally, we specify that this movement is to occur in world (not local) space.
        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        // If the player is moving:
        if (movementDirection != Vector2.zero)
        {
            // Create a new Quaternion 'toRotation' which calculates the angle the lawnmower sprite needs to rotate by to face movementDirection.
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);

            // Finally, we smoothly rotate the sprite at the rate specified by rotationSpeed by the angle defined in toRotation. 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        spawnMask();

    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }


    private void OnTriggerEnter2D(Collider2D lawnmower)
    {
        if (lawnmower.CompareTag("Grass")) {

            UnityEngine.Debug.Log("Triggered");
        }
    }

    /*Spawns a spriteMask to reveal what is underneath the grass layer. A timer is set to where after a specific
    amount of time, a sprite mask appears and the timer is reset. Because this happens in update, the method is
    called every frame of animation.*/
    private void spawnMask() {

        // Get the current position of the lawnmower
        Vector2 currentPosition = lawnmower.position;

        // Increment the timer
        timer += Time.deltaTime;

        // If the interval has passed, place a new mask on the ground (ex. spawn interval is 1 sec, so a new mask will spawn after 1 sec)
        if (timer >= spawnInterval) {
            //Instantiate allows us to spawn a new game object as the code runs
            SpriteMask mask = Instantiate(spriteMask);

            // The masks are positioned to spawn at the lawnmower's location, which is why transform is used
            mask.transform.position = currentPosition;

            // Update the previous position of the lawnmower to the current position
            previousPosition = currentPosition;

            // Reset the timer
            timer = 0.0f;

        }
    }
    

    
}
