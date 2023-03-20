using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class addColliderToEachTile : MonoBehaviour
{
    public Tilemap uncutGrass;

    // Start is called before the first frame update    
    void Start()
    {
        // foreach (Vector3Int pos in uncutGrass.cellBounds.allPositionsWithin) {
        //     TileBase tile = uncutGrass.GetTile(pos);
        //     if (tile != null) {
        //         // Create a new GameObject to hold the collider
        //         GameObject colliderObj = new GameObject("Collider");
        //         colliderObj.transform.parent = transform;

        //         // Add a BoxCollider2D component to the GameObject
        //         BoxCollider2D collider = colliderObj.AddComponent<BoxCollider2D>();

        //         // Set the size of the collider to match the tile size
        //         collider.size = new Vector2(uncutGrass.cellSize.x, uncutGrass.cellSize.y);

        //         // Set the offset of the collider to match the tile position
        //         collider.offset = uncutGrass.GetCellCenterWorld(pos);
        //     }
        // }

        // Iterate over all grass tiles in the tilemap
        for (int x = uncutGrass.cellBounds.min.x; x < uncutGrass.cellBounds.max.x; x++)
        {
            for (int y = uncutGrass.cellBounds.min.y; y < uncutGrass.cellBounds.max.y; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                TileBase tile = uncutGrass.GetTile(pos);
                if (tile != null)
                {
                    // Create a new grass object at the position of the tile
                    GameObject grassObject = new GameObject("Grass");
                    grassObject.transform.position = uncutGrass.GetCellCenterWorld(pos);

                    // Add a BoxCollider2D component to the grass object and set it to trigger
                    BoxCollider2D grassCollider = grassObject.AddComponent<BoxCollider2D>();
                    grassCollider.size = new Vector2(1, 1);
                    grassCollider.isTrigger = true;

                    // Add a Rigidbody2D component to the grass object
                    Rigidbody2D grassRigidbody = grassObject.AddComponent<Rigidbody2D>();
                    grassRigidbody.bodyType = RigidbodyType2D.Static;
                    grassRigidbody.isKinematic = true;
                    grassRigidbody.gravityScale = 0;

                    // Set the grass object as a child of the tilemap
                    grassObject.transform.parent = transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
