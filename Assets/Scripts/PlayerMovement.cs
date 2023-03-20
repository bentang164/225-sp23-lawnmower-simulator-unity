//using System.Collections;
//using System.Collections.Generic;
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

    public Tile uncutGrassTile;
    public Tilemap uncutGrass;

    // Start is called before the first frame update
    void Start()
    {
        // We don't need to do anything here.

        // attachColliderstoTiles();

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

    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }

    // /*OnCollisionEnter2D checks if the collider of the lawnmower interacts with a tile map collider. if so, 
    // then set the tile to null. May want to change to OnCollisionExit so when lawnmower goes PAST the tile, the method
    // body runs*/
    // void OnCollisionEnter2D(Collision2D col) { // Put this method in the update method. Figure out what goes in as the parameter
    //     Vector3 contactPoint = col.GetContact(0).point;
    //     Vector3Int cellPosition = uncutGrass.WorldToCell(contactPoint);
    //     TileBase tile = uncutGrass.GetTile(cellPosition);
    //     if (tile != null) {
    //         uncutGrass.SetTile(cellPosition, null);
    //     }
    // }


    // void attachColliderstoTiles() {
    //     foreach (Vector3Int pos in uncutGrass.cellBounds.allPositionsWithin) {
    //         TileBase tile = uncutGrass.GetTile(pos);
    //         if (tile != null) {
    //             // Create a new GameObject to hold the collider
    //             GameObject colliderObj = new GameObject("Collider");
    //             colliderObj.transform.parent = transform;

    //             // Add a BoxCollider2D component to the GameObject
    //             BoxCollider2D collider = colliderObj.AddComponent<BoxCollider2D>();

    //             // Set the size of the collider to match the tile size
    //             collider.size = new Vector2(uncutGrass.cellSize.x, uncutGrass.cellSize.y);

    //             // Set the offset of the collider to match the tile position
    //             collider.offset = uncutGrass.GetCellCenterWorld(pos);
    //         }
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D lawnmower)
    {
        if (lawnmower.CompareTag("Grass"))
        {
            UnityEngine.Debug.Log("Triggered");
        }
    }
    

    
}
