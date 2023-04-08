using System.Globalization;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DetectCompletion : MonoBehaviour
{
    private GameObject player = null;
    private int mowedTiles = 0;
    private readonly int THRESHOLD = 9450; // Default: 90% of NUM_TILES
    private readonly int NUM_TILES = 10500; // 30x14 tilemap. Eventually should be made a SerializeField and not readonly to account for non-grass stuff (building, fountain, etc.)
    private readonly int DEFAULT_Z = 0;

    [SerializeField]
    private Tilemap completionTilemap;

    //Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has mowed enough tiles, stop everything
        // Another way we could do this is with a proportion/percentage:
            // Let THRESHOLD/NUM_TILES be the percentage the player needs to mow, visible to the player as "Target"
            // Include an overall percentage in the level: mowedTiles/NUM_TILES, visible to the player as "Progress"
            // Should the level immediately end when the threshold is hit, or allow the player to continue mowing until time runs out?
            // We can also scale the difficulty by making THRESHOLD a SerializeField that can be modified from within the Unity Editor.
        if (mowedTiles >= THRESHOLD)
        {
            print("Completion threshold exceeded");
        }

        // Pull raw x and y coordinates for the player's position
        float playerRawX = player.transform.position.x;
        float playerRawY = player.transform.position.y;

        //Mow(new Vector3Int((int) (playerRawX - 2 * Mathf.Cos(player.GetComponent<Rigidbody2D>().rotation)), (int) (playerRawY - 2 * Mathf.Sin(player.GetComponent<Rigidbody2D>().rotation)), DEFAULT_Z));
        //Mow(new Vector3Int((int) (playerRawX - 1 * Mathf.Cos(player.GetComponent<Rigidbody2D>().rotation)), (int) (playerRawY - 1 * Mathf.Sin(player.GetComponent<Rigidbody2D>().rotation)), DEFAULT_Z));
        //Mow(new Vector3Int((int)playerRawX, (int)playerRawY, DEFAULT_Z));
        //Mow(new Vector3Int((int) (playerRawX + 1 * Mathf.Cos(player.GetComponent<Rigidbody2D>().rotation)), (int) (playerRawY + 1 * Mathf.Sin(player.GetComponent<Rigidbody2D>().rotation)), DEFAULT_Z));
        //Mow(new Vector3Int((int) (playerRawX + 2 * Mathf.Cos(player.GetComponent<Rigidbody2D>().rotation)), (int) (playerRawY + 2 * Mathf.Sin(player.GetComponent<Rigidbody2D>().rotation)), DEFAULT_Z));

        //Mow(new Vector3Int(Mathf.RoundToInt(playerRawX - 2), Mathf.RoundToInt(playerRawY - 2), DEFAULT_Z));
        //Mow(new Vector3Int(Mathf.RoundToInt(playerRawX - 1), Mathf.RoundToInt(playerRawY - 1), DEFAULT_Z));
        //Mow(new Vector3Int(Mathf.RoundToInt(playerRawX), Mathf.RoundToInt(playerRawY), DEFAULT_Z));
        //Mow(new Vector3Int(Mathf.RoundToInt(playerRawX + 1), Mathf.RoundToInt(playerRawY + 1), DEFAULT_Z));
        //Mow(new Vector3Int(Mathf.RoundToInt(playerRawX + 2), Mathf.RoundToInt(playerRawY + 2), DEFAULT_Z));

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                Mow(new Vector3Int(Mathf.RoundToInt(playerRawX - 2 + i), Mathf.RoundToInt(playerRawY - 2 + j), DEFAULT_Z));
            }
        }

        /*
        if (Time.frameCount % 180 == 0) {
            print("left side raw: " + (playerRawX - 2) + ", " + (playerRawY - 2));
            //print("left side int: " + (int)(playerRawX - 2) + ", " + (int)(playerRawY - 2));
            //print("right side int: " + (int)(playerRawX + 2) + ", " + (int)(playerRawY+ 2));
            print("right side raw: " + (playerRawX + 2) + ", " + (playerRawY + 2));

            print("center " + playerRawX + ", " + playerRawY);

        }
        */

        // Update the completion tilemap at the player's x and y coordinates, based on position.
        // This will NOT WORK if the size of the tilemap is changed from default scale!
        //if (playerRawY < 0 && playerRawX < 0)
        //{
        //    Mow(new Vector3Int((int) playerRawX - 1, (int) playerRawY - 1, DEFAULT_Z));
        //} else if (playerRawY > 0 && playerRawX < 0)
        //{
        //    Mow(new Vector3Int((int) playerRawX - 1, (int) playerRawY, DEFAULT_Z));
        //} else if (playerRawY < 0 && playerRawX > 0)
        //{
        //    Mow(new Vector3Int((int) playerRawX, (int) playerRawY - 1, DEFAULT_Z));
        //}
        //else
        //{
        //    Mow(new Vector3Int((int) playerRawX, (int) playerRawY, DEFAULT_Z));
        //}
    }

    public void Mow(Vector3Int position)
    {
        if (completionTilemap.GetTile(position) != null)
        {
            // Modifies tiles on the mowed grass/completion tilemap. Not visible to the player.
            // Exists mostly for position debugging purposes.
            // To disable, remove the below line.
            completionTilemap.SetTile(position, null);
            mowedTiles++;

            //print(mowedTiles);
        }
    }
}
