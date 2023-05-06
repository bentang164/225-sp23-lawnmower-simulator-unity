using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectCompletion : MonoBehaviour
{
    [SerializeField]
    private string nextScene;

    private int mowedTiles = 0;

    private GameObject player;

    [SerializeField]
    private GameObject endLevelButton;

    [SerializeField]
    private GameObject jobCompleteText;

    private Slider progressBar;

    private readonly int DEFAULT_Z = 0;

    [SerializeField]
    private Tilemap completionTilemap;

    [SerializeField]
    private int threshold; // Default: 90% of NUM_TILES

    //Start is called before the first frame update
    void Start()
    {       
        endLevelButton.SetActive(false);
        jobCompleteText.SetActive(false);

        DataTracker.CurrentLevelName = SceneManager.GetActiveScene().name;

        progressBar = GameObject.Find("ProgressBar").GetComponent<Slider>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (mowedTiles >= threshold)
        {
            GameObject.Find("Timer").GetComponent<TimerFunction>().StopCounting();
            endLevelButton.SetActive(true);
            jobCompleteText.SetActive(true);
        
        }

        // Pull raw x and y coordinates for the player's position
        float playerRawX = player.transform.position.x;
        float playerRawY = player.transform.position.y;

        //Mows a 4x4 square of tiles centered on the lawnmower center
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                Mow(new Vector3Int(Mathf.RoundToInt(playerRawX - 2 + i), Mathf.RoundToInt(playerRawY - 2 + j), DEFAULT_Z));
            }
        }
    }

    public void completeLevel() {
        GameObject.Find("Timer").GetComponent<TimerFunction>().SetBestTime();

        SceneManager.LoadScene(nextScene);
        endLevelButton.SetActive(false);
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
            progressBar.value++;
        }
    }
}
