//using System.Collections;
//using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlayerMovement : MonoBehaviour
{
    // We need the SerializeField tag so that these fields become visible in the Unity Inspector
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float forceSpeed;

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
        //Vector2 movementDirection = new Vector2(horizontalInput, forwardBackInput);

        // Gets magnitude of the movement and 'clamps' its value so that it's between 0 and 1.
        // This value is then normalized so that it's of length 1.
        //float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        //movementDirection.Normalize();

        // Moves the lawnmower/player in the direction specified, multiplied by the speed, inputMagnitude, and delta time.
        // We want it to be multiplied by delta time so that it's framerate independent.
        // Finally, we specify that this movement is to occur in world (not local) space.
        

        //code partially yoinked from: https://answers.unity.com/questions/785479/how-to-create-an-asteroids-style-moving-in-2d-mode.html
        //transform.Translate(new Vector2(0, 1) * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 1) * Time.deltaTime * Input.GetAxis("Vertical") * forceSpeed);

        //decelerates mower quicker to simulate the operator stopping it
        if (Input.GetAxis("Vertical") == 0 && GetComponent<Rigidbody2D>().velocity != null) 
        {
            print(Input.GetAxis("Vertical"));
            GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 1) * Time.deltaTime * - GetComponent<Rigidbody2D>().velocity * GetComponent<Rigidbody2D>().mass);
        }

        //code yoinked from: https://gamecodeschool.com/unity/building-asteroids-arcade-game-in-unity/
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        // If the player is moving:
        /*
        if (movementDirection != Vector2.zero)
        {
            // Create a new Quaternion 'toRotation' which calculates the angle the lawnmower sprite needs to rotate by to face movementDirection.
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);

            // Finally, we smoothly rotate the sprite at the rate specified by rotationSpeed by the angle defined in toRotation. 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        */
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
