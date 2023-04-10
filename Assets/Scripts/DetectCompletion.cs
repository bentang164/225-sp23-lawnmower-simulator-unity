using System.Globalization;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DetectCompletion : MonoBehaviour
{
    private GameObject player = null;
    private int mowedTiles = 0;
    
    private int NUM_TILES = 11200; // 160x70 tilemap.
    private readonly int DEFAULT_Z = 0;

    [SerializeField]
    private Tilemap completionTilemap;

    [SerializeField]
    private int threshold; // Default: 90% of NUM_TILES, 8415 for level 2, 

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
        if (mowedTiles >= threshold)
        {
            print("Completion threshold exceeded");
        }

        // Pull raw x and y coordinates for the player's position
        float playerRawX = player.transform.position.x;
        float playerRawY = player.transform.position.y;

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                Mow(new Vector3Int(Mathf.RoundToInt(playerRawX - 2 + i), Mathf.RoundToInt(playerRawY - 2 + j), DEFAULT_Z));
            }
        }
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
        }
    }
}
