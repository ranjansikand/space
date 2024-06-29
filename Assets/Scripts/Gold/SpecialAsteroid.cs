// Asteroid that triggers play


using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialAsteroid : GoldAsteroid
{
    protected override void DestroyThis() {
        Invoke(nameof(ChangeScenes), 5f);
        
        gameObject.SetActive(false);
    }


    void ChangeScenes() {
        PlayerPrefs.SetInt("tutorial", 1);
        SceneManager.LoadScene("Play");
    }
}
