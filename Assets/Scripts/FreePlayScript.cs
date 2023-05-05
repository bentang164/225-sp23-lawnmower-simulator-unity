using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreePlayScript : MonoBehaviour
{
    [SerializeField]
    private string nextScene;
    
    public void completeLevel() {
        SceneManager.LoadScene(nextScene);
    }
}
