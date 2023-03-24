using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrassMowing : MonoBehaviour
{
    public GameObject mower;
    SpriteRenderer spriteRenderer;

    Texture2D texture;

    Color[] colors = new Color[100];
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        for (int i = 0; i < 100; i++) {
            colors[i] = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        mower = GameObject.Find("Player");
        Rigidbody2D mowerBody = mower.GetComponent<Rigidbody2D>();
        Vector3Int vector = new Vector3Int((int) mowerBody.position.x, (int) mowerBody.position.y, 0);

        texture = spriteRenderer.sprite.texture;

        texture.SetPixels((int) mowerBody.position.x, (int) mowerBody.position.y, 10, 10, colors, 0);

        texture.Apply(false);

        spriteRenderer.sprite = Sprite.Create(texture, new Rect(), new Vector2(0,0));
    }
}
