using System.Globalization;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectCompletion : MonoBehaviour
{
    public string nextScene;

    private int mowedTiles = 0;

    private bool levelComplete;

    public GameObject endLevelButton;
    public GameObject jobCompleteText;
    private GameObject player = null;
    private Slider progressBar;

    private readonly int DEFAULT_Z = 0;

    [SerializeField]
    private Tilemap completionTilemap;

    [SerializeField]
    private int threshold; 

    //Start is called before the first frame update
    void Start()
    {       
        endLevelButton.SetActive(false);
        jobCompleteText.SetActive(false);
        levelComplete = false;

        progressBar = GameObject.Find("ProgressBar").GetComponent<Slider>();

        DataTracker.CurrentLevelName = SceneManager.GetActiveScene().name;

        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //detects and handles completion
        if (mowedTiles >= threshold)
        {
            GameObject.Find("Timer").GetComponent<TimerFunction>().StopCounting();

            levelComplete = true;
            if (levelComplete) {
                endLevelButton.SetActive(true);
                jobCompleteText.SetActive(true);
            }
            
        }

        // Pull raw x and y coordinates for the player's position
        float playerRawX = player.transform.position.x;
        float playerRawY = player.transform.position.y;

        //Mows lawn tiles in a 4x4 square centered on the lawnmower 
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
            completionTilemap.SetTile(position, null);
            mowedTiles++;

            progressBar.value += 1;
        }
    }
}
