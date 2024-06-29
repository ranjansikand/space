// Title screen script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void StartGame() {
        int tutorialComplete = PlayerPrefs.GetInt("tutorial", 0);
        if (tutorialComplete == 0) {
            SceneManager.LoadScene("Tutorial");
        } else
        SceneManager.LoadScene("Play");
    }
}
