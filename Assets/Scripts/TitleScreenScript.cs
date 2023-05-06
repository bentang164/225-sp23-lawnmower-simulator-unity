using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public string playGame;

    public void playButton() {
        SceneManager.LoadScene(playGame);
    }

    public void quitButton() {
        Application.Quit();
    }
}
