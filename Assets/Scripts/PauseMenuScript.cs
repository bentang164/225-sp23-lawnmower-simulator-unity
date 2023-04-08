using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public string home;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void goHome() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(home);
    }
}
