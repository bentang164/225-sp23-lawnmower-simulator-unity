using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpScript : MonoBehaviour
{
    public GameObject controlPanel;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        // controlPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void popUpButtonClick() {
    //     // SceneManager.LoadScene(loadScene);
    //     controlPanel.SetActive(true);
    // }

    public void OpenclosePopUp() {
        // controlPanel.SetActive(false);
        if (!active) {
            controlPanel.transform.gameObject.SetActive(true);
            active = true;
        } else {
            controlPanel.transform.gameObject.SetActive(false);
            active = false;
        }
    }
}
