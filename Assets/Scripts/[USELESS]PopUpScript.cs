using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpScript : MonoBehaviour
{
    public GameObject controlPanel;
    public GameObject XButton;
    bool active;    
    
    // Start is called before the first frame update
    void Start()
    {
        controlPanel.SetActive(false);
        XButton.SetActive(false);
        active = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (flag) {
        //     closeControls();
        // }

        // if (Input.GetKeyDown(KeyCode.Escape)) {
        //     controlPanel.transform.gameObject.SetActive(!controlPanel.gameObject.activeSelf);
        // }
    }

    // public void closeControls() {
    //     if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) {
    //         flag = false;
    //         OpenClosePopUp();
    //     }
    // }


    public void OpenClosePopUp() {
        // if (!active) {
        //     controlPanel.transform.gameObject.SetActive(true);
        //     XButton.transform.gameObject.SetActive(true);
        //     active = true;
        // } else {
        //     if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))) {
        //         controlPanel.transform.gameObject.SetActive(false);
        //         XButton.transform.gameObject.SetActive(false);
        //         active = false;
        //     }

        // }
        if (!active) {
            // controlPanel.transform.gameObject.SetActive(true);
            controlPanel.SetActive(true);
            // XButton.transform.gameObject.SetActive(true);
            XButton.SetActive(true);
            active = true;
        } else {
            // controlPanel.transform.gameObject.SetActive(false);
            controlPanel.SetActive(false);
            // XButton.transform.gameObject.SetActive(false);
            XButton.SetActive(false);
            active = false;
        }

    }
}
