using System.Globalization;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectCompletion : MonoBehaviour
{
    public string nextScene;
    private GameObject player = null;
    private int mowedTiles = 0;
    private bool levelComplete;
    public GameObject endLevelButton;
    public GameObject jobCompleteText;
    
    private int NUM_TILES = 7000; // 20x14 tilemap.
    private readonly int DEFAULT_Z = 0;

    [SerializeField]
    private Tilemap completionTilemap;

    [SerializeField]
    private int threshold; // Default: 90% of NUM_TILES

    //Start is called before the first frame update
    void Start()
    {
        DataTracker.CurrentLevelName = SceneManager.GetActiveScene().name;
       
        endLevelButton.SetActive(false);
        jobCompleteText.SetActive(false);
        levelComplete = false;

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
            GameObject.Find("Timer").GetComponent<TimerFunction>().StopCounting();
            levelComplete = true;
            if (levelComplete) {
                endLevelButton.SetActive(true);
                jobCompleteText.SetActive(true);
            }
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

    public void completeLevel() {
        GameObject.Find("Timer").GetComponent<TimerFunction>().SetBestTime();
        SceneManager.LoadScene(nextScene);
        levelComplete = false;
        endLevelButton.SetActive(false);
    }

    public void Mow(Vector3Int position)
    {
        if (completionTilemap.GetTile(position) != null)
        {
            // Modifies tiles on the mowed grass/completion tilemap. Not visible to the player.
            // Exists mostly for position debugging purposes.
            // To disable, remove the below line.
            GameObject.Find("ProgressBar").GetComponent<Slider>().value += 1;
            completionTilemap.SetTile(position, null);
            mowedTiles++;
        }
    }
}
