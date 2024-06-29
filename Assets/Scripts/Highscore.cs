// DIsplays high score


using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    [SerializeField] TMP_Text highscore;

    void Start() {
        highscore.text = PlayerPrefs.GetInt("high", 0).ToString();
    }

}
