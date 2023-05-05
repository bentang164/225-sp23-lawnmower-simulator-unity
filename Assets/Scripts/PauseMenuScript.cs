using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public string home;
    bool active = false;
    public GameObject controlPanel;
    public GameObject XButton;


    void Start()
    {
        pauseMenu.SetActive(false);
        controlPanel.SetActive(false);
        XButton.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            if (pauseMenu.activeSelf) {
                GameObject.Find("Main Camera").GetComponent<SoundManager>().PauseSounds();
                Time.timeScale = 0f;
                if (controlPanel.activeSelf && XButton.activeSelf) {
                    controlPanel.SetActive(!controlPanel.activeSelf);
                    XButton.SetActive(!XButton.activeSelf);
                    active = false;
                }
            } else {
                GameObject.Find("Main Camera").GetComponent<SoundManager>().ResumeSounds();
                Time.timeScale = 1f;
            }

        }
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<SoundManager>().PauseSounds();
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<SoundManager>().ResumeSounds();
        Time.timeScale = 1f;
    }

    public void goHome() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(home);
    }

    public bool ActiveState() {
        return pauseMenu.activeSelf;
    }


    public void OpenClosePopUp() {
        if (!active) {
            controlPanel.SetActive(true);
            XButton.SetActive(true);
            active = true;
            pauseMenu.SetActive(false);
        } else {
            controlPanel.SetActive(false);
            XButton.SetActive(false);
            pauseMenu.SetActive(true);
            active = false;

        }
    }
}
