using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrassMowing : MonoBehaviour
{
    public GameObject mower;
    SpriteRenderer spriteRenderer;

    Texture2D texture;

    public Sprite basicSprite;
    Texture2D basicTex;

    Color[] colors = new Color[100];
    // Start is called before the first frame update
    void Start()
    {
        //basicTex = basicSprite.texture;
        //basicTex.Apply(true);

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = Sprite.Create(basicTex, new Rect(-256.0f, -256.0f, 256.0f, 256.0f), new Vector2(0.0f, 0.0f));

        for (int i = 0; i < 100; i++) {
            colors[i] = Color.green;
        }
        print(colors.Length);
    }

    // Update is called once per frame
    void Update()
    {
        mower = GameObject.Find("Player");
        Rigidbody2D mowerBody = mower.GetComponent<Rigidbody2D>();
        Vector3Int vector = new Vector3Int((int) mowerBody.position.x, (int) mowerBody.position.y, 0);

        print(mowerBody.position.x);
        print(mowerBody.position.y);
        print((int)mowerBody.position.x);
        print((int)mowerBody.position.y);


        texture = spriteRenderer.sprite.texture;

        texture.SetPixels((int) mowerBody.position.x, (int) mowerBody.position.y, 10, 10, colors, 0);
        //texture.SetPixels(colors, 0);

        texture.Apply(true);

        spriteRenderer.sprite = Sprite.Create(texture, new Rect(-8.0f, -8.0f, 256f, 256f), new Vector2(.5f,.5f));
        
    }
}
