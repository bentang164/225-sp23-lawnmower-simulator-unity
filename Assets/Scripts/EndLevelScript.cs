using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndLevelScript : MonoBehaviour
{
    public string level;
    TMP_Text prevBestText;
    TMP_Text bestText;

    // Start is called before the first frame update
    void Start()
    {
        prevBestText = GameObject.Find("PrevBestText").GetComponent<TMP_Text>();
        bestText = GameObject.Find("NewBestText").GetComponent<TMP_Text>();

        changeBestText(DataTracker.NewBestBool);
    }

    public void nextScene() {
        SceneManager.LoadScene(level);
    }

    public void changeBestText(bool NewBestBool)
    {
        string level = DataTracker.CurrentLevelName;

        if (NewBestBool)
        {
            prevBestText.SetText("Previous Best: " + (int) DataTracker.PrevBestTimes[level]);
            bestText.SetText("New Best: " + (int) DataTracker.BestTimes[level]);
        } else
        {
            //just sets the text of the new best text to blank; this is to avoid dealing with deactivating and reactivating it
            bestText.SetText("");

            //Uses prevBestText to display the Current Best instead; this is done to avoid having an entirely separate unneeded text object
            prevBestText.SetText("Current Best: " + (int) DataTracker.BestTimes[level]);
        }
    }

}
