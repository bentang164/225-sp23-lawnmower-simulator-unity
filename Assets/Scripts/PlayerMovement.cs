//using System.Collections;
//using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlayerMovement : MonoBehaviour
{
    // We need the SerializeField tag so that these fields become visible in the Unity Inspector
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        // Defining two variables that get player input (W/S or Up/Down; A/D or Left/Right).
        // WASD or the arrow keys are both acceptable input built into Unity.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        

        //code partially yoinked from: https://answers.unity.com/questions/785479/how-to-create-an-asteroids-style-moving-in-2d-mode.html
        GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 1) * Time.deltaTime * Input.GetAxis("Vertical") * speed);

        //decelerates mower quicker to simulate the operator stopping it
        if (Input.GetAxis("Vertical") == 0 && GetComponent<Rigidbody2D>().velocity != null) 
        {
            print(Input.GetAxis("Vertical"));
            GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 1) * Time.deltaTime * - GetComponent<Rigidbody2D>().velocity * GetComponent<Rigidbody2D>().mass);
        }

        //code yoinked from: https://gamecodeschool.com/unity/building-asteroids-arcade-game-in-unity/
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
