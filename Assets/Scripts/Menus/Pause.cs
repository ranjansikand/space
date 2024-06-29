// Pause menu panel


using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Slider sfx, music, screenshake;


    private void OnEnable() {
        Time.timeScale = 0;

        sfx.value = PlayerData.maxSFXVolume;
        // music
        screenshake.value = Screenshake.shakeScaling;
    }

    private void OnDisable() {
        Time.timeScale = 1;
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void UpdateSFX(float value) {
        PlayerData.maxSFXVolume = value;
        PlayerPrefs.SetFloat("sfx", value);
    }

    public void UpdateMusic(float value) {
        Music.volume = value;
    }

    public void UpdateScreenshake(float value) {
        Screenshake.shakeScaling = value;
        PlayerPrefs.SetFloat("shake", value);
    }
}
