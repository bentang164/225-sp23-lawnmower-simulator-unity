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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenClosePopUp() {
        if (!active) {
            controlPanel.transform.gameObject.SetActive(true);
            XButton.transform.gameObject.SetActive(true);
            active = true;
        } else {
            controlPanel.transform.gameObject.SetActive(false);
            XButton.transform.gameObject.SetActive(false);
            active = false;
        }
    }
}
