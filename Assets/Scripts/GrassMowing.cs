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
    public static readonly int chunkSize = 400;
    Texture2D basicTex;

    Color[] colors = new Color[chunkSize];
    // Start is called before the first frame update
    void Start()
    {
        //basicTex = basicSprite.texture;
        //basicTex.Apply(true);

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = Sprite.Create(basicTex, new Rect(-256.0f, -256.0f, 256.0f, 256.0f), new Vector2(0.0f, 0.0f));

        for (int i = 0; i < chunkSize; i++) {
            colors[i] = Color.green;
        }
        print(colors.Length);
    }

    // Update is called once per frame
    void Update()
    {
        mower = GameObject.Find("Player");
        Rigidbody2D mowerBody = mower.GetComponent<Rigidbody2D>();

        print(mowerBody.position.x);
        print(mowerBody.position.y);


        texture = spriteRenderer.sprite.texture;

        texture.SetPixels((int) mowerBody.position.x, (int) mowerBody.position.y, (int)Mathf.Sqrt(chunkSize), (int)Mathf.Sqrt(chunkSize), colors, 0);
        //texture.SetPixels(colors, 0);

        texture.Apply(true);

        //spriteRenderer.sprite = Sprite.Create(texture, new Rect(0f, 0f, 100f, 100f), new Vector2(.5f,.5f));
        
    }
}
