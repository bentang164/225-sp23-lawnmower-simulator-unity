using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MowGrass : MonoBehaviour
{
    private GameObject player = null;
    private readonly int defaultZ = 0;

    [SerializeField]
    private Tilemap unmowed;

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
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;

        Mow(new Vector3Int((int) playerX - 1, (int) playerY - 1, defaultZ));
    }

    public void Mow(Vector3Int position)
    {
        if (unmowed.GetTile(position) != null)
        {
            unmowed.SetTile(position, null);
        }
    }
}
