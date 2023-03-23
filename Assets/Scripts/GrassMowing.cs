using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMowing : MonoBehaviour
{
    Texture2D texture;
    Color[] colors = new Color[100];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++) {
            colors[i] = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D mower = Player.GetComponent<Rigidbody2D>;

        texture = this.GetSprite(mower.position);
        texture.setPixels(mower.position.x, mower.position.y, 10, 10, colors, 0);

        texture.Apply(false);
    }
}
